using System;
using System.IO;
using System.Threading.Tasks;
using Trip.Application.Common.FileManager;

namespace Trip.Creator.Persistence.IO
{
    public class FileService : IFileService
    {
        public bool ReadFileBytes(string fileNameWithExt, string path)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveFile(string fileNameWithExt, string path, Stream stream)
        {
            throw new NotImplementedException();

            //using (var strm = System.IO.File.Create(path))
            //{
            //    await formFile.CopyToAsync(strm);
            //}
        }
    }
}
