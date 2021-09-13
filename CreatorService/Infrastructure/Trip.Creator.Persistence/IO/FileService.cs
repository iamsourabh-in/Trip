using System;
using System.IO;
using System.Threading.Tasks;
using Trip.Application.Common.FileManager;

namespace Trip.Creator.Persistence.IO
{
    public class FileService : IFileService
    {
        public byte[] ReadFileBytes(string filePath)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveFileAsync(string path, string fileNameWithExt,  string content)
        {
            var filepath = $"{path}\\{fileNameWithExt}";
            await File.WriteAllTextAsync(filepath, content);
            return filepath;
        }

        public async Task<string> SaveFileAsync(string path, string fileNameWithExt, byte[] bytes)
        {
            var filepath = $"{path}\\{fileNameWithExt}";
            await File.WriteAllBytesAsync(filepath, bytes);
            return filepath;
        }
    }
}
