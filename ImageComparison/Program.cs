using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ImageComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            string imageToCompare = @"D:\User\Darbvisma\20170814_134511.jpg";

            string[] imageGroup = { @"D:\User\Darbvisma\comparison\20170814_134511.jpg",
                                    @"D:\User\Darbvisma\comparison\20170814_134527.jpg",
                                    @"D:\User\Darbvisma\comparison\20170814_134529.jpg"
            };

            ComparisonProfile profile = new ComparisonProfile(imageToCompare, imageGroup);

            List<string> imagesThatCompare = Compare.CompareImages(profile);

            for (int i = 0; i < imagesThatCompare.Count; i++) {
                Console.WriteLine(imagesThatCompare[i]);
            }

            Console.WriteLine("\nDone!");
            Console.ReadLine();
        }
    }
}
