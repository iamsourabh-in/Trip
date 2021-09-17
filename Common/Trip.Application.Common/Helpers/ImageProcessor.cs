using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;

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
                image.Save(Path.Combine(@"D:\Work\Trip\Trip\vCloud", thumbReq.size, thumbReq.fileName));
            }
            catch (Exception e)
            {
                throw new ArgumentException("Image not valid to generate Thumbnail");
            }
        }
        public static async Task GenerateVideoThumbnail(GenerateThumbnailRequest thumbReq)
        {
            try
            {
                string output = Path.Combine(@"D:\Work\Trip\Trip\vCloud", thumbReq.size, Guid.NewGuid().ToString() + ".png");
                await FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official, @"D:\Work\Trip\Trip\CreatorService\Trip.Creator.Api\bin\Debug\net5.0")
                FFmpeg.SetExecutablesPath(@"D:\Work\Trip\Trip\CreatorService\Trip.Creator.Api\bin\Debug\net5.0");
                IConversion conversion = await FFmpeg.Conversions.FromSnippet.Snapshot(thumbReq.originPath, output,
                TimeSpan.FromSeconds(0));
                IConversionResult result = await conversion.Start();

            }
            catch (Exception e)
            {
                throw new ArgumentException("Image not valid to generate Thumbnail");
            }
        }

        public static bool IsImage(string fileName)
        {
            var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };
            var ext = Path.GetExtension(fileName);
            return supportedTypes.Any(supportedType => supportedType == ext);
        }

        public static bool IsVideo(string fileName)
        {
            var supportedTypes = new[] { ".mp4" };
            var ext = Path.GetExtension(fileName);
            return supportedTypes.Any(supportedType => supportedType == ext);
        }

    }

    public class GenerateThumbnailRequest
    {
        public string originPath { get; set; }
        public string fileName { get; set; }
        public string size { get; set; } = "medium";
    }
}
