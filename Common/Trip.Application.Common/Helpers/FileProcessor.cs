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
    public class FileProcessor
    {
        private const string FFmpegToolPath = @"D:\Work\Trip\Trip\CreatorService\Trip.Creator.Api\bin\Debug\net5.0";
        public static async Task<string> GenerateThumbnail(GenerateThumbnailRequest thumbReq)
        {
            if (thumbReq is null)
            {
                throw new ArgumentNullException(typeof(GenerateThumbnailRequest).Name);
            }
            try
            {
                var outputPath = String.Empty;
                using var image = await Image.LoadAsync(thumbReq.originalFullPath);

                if (thumbReq.size == FileProcessorSizeEnum.Medium)
                {
                    outputPath = Path.Combine(thumbReq.outputPath, thumbReq.fileName);
                    image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
                }
                if (thumbReq.size == FileProcessorSizeEnum.Small)
                {
                    outputPath = Path.Combine(thumbReq.outputPath, thumbReq.fileName);
                    image.Mutate(x => x.Resize(image.Width / 4, image.Height / 4));
                }

                image.Save(outputPath);
                return outputPath;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        public static async Task<string> GenerateVideoThumbnail(GenerateThumbnailRequest thumbReq)
        {
            try
            {
                var snapnotFileName = thumbReq.fileName.Split('.')[0];
                string outputPath = Path.Combine(thumbReq.outputPath, Guid.NewGuid().ToString() + ".png");
                await FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official, FFmpegToolPath);
                FFmpeg.SetExecutablesPath(FFmpegToolPath);
                IConversion conversion = await FFmpeg.Conversions.FromSnippet.Snapshot(thumbReq.originalFullPath, outputPath,
                TimeSpan.FromSeconds(0));
                IConversionResult result = await conversion.Start();
                return outputPath;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Image not valid to generate Thumbnail");
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
        public string originalFullPath { get; set; }
        public string fileName { get; set; }
        public string outputPath { get; set; }
        public FileProcessorSizeEnum size { get; set; }
    }
}
