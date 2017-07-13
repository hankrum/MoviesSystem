using System;

namespace MS.Services.FileManager
{
    public interface IFileManager
    {
        byte[] ReadFile(string path);

        Tuple<bool, string> WriteFile(byte[] file, string directory, string fileName);
    }
}
