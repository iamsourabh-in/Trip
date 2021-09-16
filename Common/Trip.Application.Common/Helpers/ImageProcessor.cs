using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Trip.Application.Common.Helpers
{
    public class ImageProcessor
    {
        public static void GenerateThumbnail(GenerateThumbnailRequest thumbReq)
        {
            try
            {
                using var image = Image.Load(thumbReq.originPath);
                image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
                image.Save(thumbReq.fileName);

            }
            catch (Exception e)
            {
                throw new ArgumentException("Image not valid to generate Thumbnail");
            }
        }
    }

    public class GenerateThumbnailRequest
    {
        public string originPath { get; set; }
        public string fileName { get; set; }
        public string size { get; set; } = "medium";
    }
}
