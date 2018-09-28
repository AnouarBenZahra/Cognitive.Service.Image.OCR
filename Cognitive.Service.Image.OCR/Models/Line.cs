using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.Service.Image.OCR.Models
{
    public class Line
    {
        public string boundingBox { get; set; }
        public List<Word> words { get; set; }
    }
}
