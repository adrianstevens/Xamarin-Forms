using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio
{
    public interface IFileHelper
    {
        Task<string> LoadLocalFileAsync(string filename);
        Task<bool> SaveLocalFileAsync(string filename, string data);

        string GetNameWithPath(string filename);
    }
}
