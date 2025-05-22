using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageComparison
{
    class ComparisonProfile
    {
        public string ImageToCompare { get; set; }
        public string[] ImageGroup { get; set; }

        public ComparisonProfile(string imageToCompare, string[] imageGroup)
        {
            this.ImageToCompare = imageToCompare;
            this.ImageGroup = imageGroup;
        }
    }
}
