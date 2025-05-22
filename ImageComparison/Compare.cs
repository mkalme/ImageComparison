using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace ImageComparison
{
    class Compare
    {
        public static List<string> CompareImages(ComparisonProfile profile)
        {
            Bitmap imageToCompare = new Bitmap(profile.ImageToCompare);
            List<string> imagesThatMatch = new List<string>();

            for (int i = 0; i < profile.ImageGroup.Length; i++)
            {
                bool compares = compare(imageToCompare, profile.ImageGroup[i]);

                if (compares) {
                    imagesThatMatch.Add(profile.ImageGroup[i]);
                }
            }

            return imagesThatMatch;
        }

        private static bool compare(Bitmap imageToCompare, string imageToCompareAgainst)
        {
            bool compares = false;

            Bitmap image = new Bitmap(imageToCompareAgainst);

            if (imageToCompare.Size == image.Size)
            {
                List<bool> iHash1 = GetHash(imageToCompare);
                List<bool> iHash2 = GetHash(image);

                //determine the number of equal pixel (x of 256)
                int equalElements = iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);

                if (equalElements == 256) {
                    compares = true;
                }
            }
            else {
                compares = false;
            }

            image.Dispose();

            return compares;
        }

        private static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            //create new image with 16x16 pixel
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }
    }
}
