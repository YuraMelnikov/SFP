using Entities.Models;
using System;
using System.IO;
using System.Net;

namespace ParserApp
{
    public class ImageParser
    {
        private string link;
        private string folder;
        RepositoryParcer repository;

        public ImageParser(string link, string folder)
        {
            this.link = link;
            this.folder = folder;
            repository = new RepositoryParcer();
        }
        public Guid SaveObject()
        {
            WebClient godLikeClient = new WebClient();
            godLikeClient.DownloadFile(link, Path.Combine(@"C:\Users\Zianon\source\repos\SFP\ParserApp\" + folder, Path.GetFileName(link)));
            Image image = new Image();
            image.Link = folder + Path.GetFileName(link);
            repository.Images.Add(image);
            repository.SaveChanges();
            return image.Id;
        }
    }
}
