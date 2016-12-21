using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubmissionDojo.Models
{
    public class JudoDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Difficulty { get; set; }
        public string Type { get; set; }
    }
}