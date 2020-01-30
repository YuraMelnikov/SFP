using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace WebApiTests.Fake
{
    public class ImageServiceFake
    {
        private readonly List<Image> _images;

        public ImageServiceFake()
        {
            _images = new List<Image>()
            {
                new Image() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Description = "desc1", Link = "/1/2/3"},
                new Image() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"), Description = "desc2", Link = "/4/5/6"},
                new Image() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"), Description = "desc3", Link = "/7"}
            };
        }
    }
}
