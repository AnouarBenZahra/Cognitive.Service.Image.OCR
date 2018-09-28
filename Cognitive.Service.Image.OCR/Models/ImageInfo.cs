using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.Service.Image.OCR.Models
{
    public class ImageInfo
    {
        public string language { get; set; }
        public string orientation { get; set; }
        public int textAngle { get; set; }
        public List<Region> regions { get; set; }
    }
}
