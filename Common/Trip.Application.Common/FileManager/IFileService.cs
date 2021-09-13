using System.IO;
using System.Threading.Tasks;

namespace Trip.Application.Common.FileManager
{
    public interface IFileService
    {
        public Task<string> SaveFileAsync(string path, string fileNameWithExt, byte[] bytes);
        public Task<string> SaveFileAsync(string fileNameWithExt, string path, string content);

        public bool ReadFileBytes(string fileNameWithExt, string path);
    }
}
