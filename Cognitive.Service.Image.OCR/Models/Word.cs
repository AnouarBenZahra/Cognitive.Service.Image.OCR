using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.Service.Image.OCR.Models
{
    public class Word
    {
        public string boundingBox { get; set; }
        public string text { get; set; }
    }
}
