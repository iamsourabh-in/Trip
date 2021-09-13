using System.IO;
using System.Threading.Tasks;

namespace Trip.Application.Common.FileManager
{
    public interface IFileService
    {
        public Task<bool> SaveFile(string fileNameWithExt, string path, Stream stream);

        public bool ReadFileBytes(string fileNameWithExt, string path);
    }
}
