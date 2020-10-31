using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Entities.Models;
using System.Linq;

namespace ParserApp
{
    /*legalese code - refactoring*/

    public class ChassiLoad
    {
        string name;
        int linkImage;

        public ChassiLoad(string name, int linkImage)
        {
            this.Name = name;
            this.LinkImage = linkImage;
        }

        public string Name { get => name; set => name = value; }
        public int LinkImage { get => linkImage; set => linkImage = value; }
    }

    public class ManufacturingAndChassie
    {
        public ManufacturingAndChassie()
        {
            repository = new RepositoryParcer();
        }

        protected Guid firstIdImages = Guid.Parse("7785471e-79af-4892-bd56-07ea29f5e8a2");
        protected Guid firstIdImagesLivery = Guid.Parse("7785471e-79af-4892-bd56-07ea29f5e8a2");

        protected RepositoryParcer repository;


        WebClient godLikeClient = new WebClient();
        HtmlDocument godLikeHTML = new HtmlDocument();
        protected string startPagesSite = "https://wildsoft.motorsport.com/";
        Encoding encoding = CodePagesEncodingProvider.Instance.GetEncoding(1251);

        public WebClient GodLikeClient { get => godLikeClient; set => godLikeClient = value; }
        public HtmlDocument GodLikeHTML { get => godLikeHTML; set => godLikeHTML = value; }
        public string StartPagesSite { get => startPagesSite; set => startPagesSite = value; }
        public Encoding Encoding { get => encoding; set => encoding = value; }

        protected string GetScrDataNode(string xPath)
        {
            try
            {
                return GodLikeHTML.DocumentNode.SelectNodes(xPath).First().Attributes.First().DeEntitizeValue;
            }
            catch
            {
                return "";
            }

        }

        protected void SaveFileToServer(string scrFile, string folderUpload)
        {
            GodLikeClient.DownloadFile(startPagesSite + scrFile, Path.Combine(folderUpload, Path.GetFileName(scrFile)));
        }

        protected Image SaveImage(string link)
        {
            Image image = new Image
            {
                Link = link.Replace("wwwroot", "")
            };
            repository.Images.Add(image);
            repository.SaveChanges();
            return image;
        }

        protected Manufacturer CreateManufacturer(string name, Guid idImageGp)
        {
            if (repository.Manufacturers.Count(d => d.Name == name) == 0)
            {
                Manufacturer manufacturer = new Manufacturer
                {
                    IdCountry = Guid.Parse("693d467c-16c7-4b15-86e9-5780daa398f4"),
                    Name = name,
                    IdImage = idImageGp
                };
                repository.Manufacturers.Add(manufacturer);
                repository.SaveChanges();
                return manufacturer;
            }
            else
            {
                return repository.Manufacturers.First(d => d.Name == name);
            }
        }

        protected string GetTextDataNode(string xPath)
        {
            return GodLikeHTML.DocumentNode.SelectNodes(xPath).First().InnerText;
        }

        protected virtual string IndexLink { get; } = "https://wildsoft.motorsport.com/cha.php?l=";
        protected string xPathLinkData1 = "html[1]/body[1]/center[1]/div[3]/div[1]/table[1]/tr[2]/td[1]/div[1]/div[";
        protected string xPathLinkData2 = "]/a[1]/@href[1]";
        protected string xPathMName = "/html[1]/body[1]/center[1]/div[3]/div[2]/table[1]/tr[1]/td[1]/p[1]/h1[1]";

        protected virtual string XPathMImage { get; } =
            "/html[1]/body[1]/center[1]/div[3]/div[1]/table[1]/tr[2]/td[1]/div[1]/div[1]/img[1]";

        protected string folderImageManuf = @"wwwroot/img/";

        protected virtual string XPathCName { get; } =
            "//html[1]/body[1]/center[1]/div[3]/div[2]/table[3]/tr[1]/td[1]/b[1]/td[1]/b[1]/td[1]/b[1]/td[1]/b[1]/tr/td[2]";

        protected virtual string FolderImageLivery { get; } = @"wwwroot/livery/";

        public virtual void SaveData()
        {
            List<string> linksList = GetListLink();
            foreach (var DATA in linksList)
            {
                GodLikeHTML.Load(GodLikeClient.OpenRead(DATA), Encoding);
                try
                {
                    SaveFileToServer(GetScrDataNode(XPathMImage), folderImageManuf);
                }
                catch
                {

                }
                Image imageGP = SaveImage(folderImageManuf + GetScrDataNode(XPathMImage).Replace("img/cha/small/", "").Replace("wwwroot", ""));
                string mName = GetTextDataNode(xPathMName);
                Manufacturer manufacturer = CreateManufacturer(mName, imageGP.Id);
                List<ChassiLoad> listChassis = GetChassiLoads(mName, manufacturer.Id);
            }
        }

        protected virtual List<ChassiLoad> GetChassiLoads(string mName, Guid idM)
        {
            List<ChassiLoad> listChassis = new List<ChassiLoad>();
            var collectionNames = GodLikeHTML.DocumentNode.SelectNodes(XPathCName).Where(d => d.InnerHtml != d.InnerText);
            foreach (var DATA in collectionNames)
            {
                if (listChassis.All(d => d.Name != DATA.InnerText.Replace(mName + " ", "")))
                {
                    string linkImage = "";
                    Guid idImageLiver = firstIdImagesLivery;
                    try
                    {
                        linkImage = DATA.ChildNodes.Where(d => d.Name == "img").First().Attributes.First().DeEntitizeValue;
                    }
                    catch
                    {

                    }
                    if (linkImage != "")
                    {
                        SaveFileToServer(linkImage, FolderImageLivery);
                        Image image = SaveimageLiver(FolderImageLivery + linkImage.Replace("img/cha/mod/", "").Replace("wwwroot", ""));
                        idImageLiver = image.Id;
                    }

                    Chassis chassi = new Chassis
                    {
                        IdManufacturer = idM,
                        IdImage = firstIdImages,
                        IdLivery = idImageLiver, 
                        Name = DATA.InnerText.Replace(mName + " ", "")
                    };
                    repository.Chassis.Add(chassi);
                    repository.SaveChanges();
                }
            }
            return listChassis;
        }

        private Image SaveimageLiver(string link)
        {
            Image image = new Image();
            image.Link = link;
            repository.Images.Add(image);
            repository.SaveChanges();
            return image;
        }

        protected List<string> GetListLink()
        {
            List<string> listLink = new List<string>();
            for (int i = 65; i <= 90; i++) //90
            {
                bool correct = false;
                int counterStep = 1;
                string tmp = Convert.ToChar(i).ToString();
                GodLikeHTML.Load(GodLikeClient.OpenRead(IndexLink + Convert.ToChar(i).ToString()), Encoding);
                while (correct != true)
                {
                    try
                    {
                        string linkManufacture = GodLikeHTML.DocumentNode.SelectNodes(xPathLinkData1 + counterStep + xPathLinkData2).First().Attributes.First().DeEntitizeValue;
                        listLink.Add(StartPagesSite + linkManufacture);
                        counterStep++;
                    }
                    catch
                    {
                        correct = true;
                    }
                }
            }
            return listLink;
        }

        private Image SaveImageGPLiver(string link)
        {
            Image imageGp = new Image { Link = link };
            repository.Images.Add(imageGp);
            repository.SaveChanges();
            return imageGp;
        }
    }
}
