using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEntity
{
    public class ImageDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public long Size { get; set; }

        public string  ImageUrl { get; set; }
    }
}
