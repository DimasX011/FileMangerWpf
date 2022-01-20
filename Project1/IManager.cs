using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project1
{
    internal interface IManager
    {
        void Create(string name, string path);

        void CreateDirectory(string name, string path);

        List<string> ShowCatalog(string nameCatalog);

        void Delete(string path, string name);

        void Deletefld(string path, string name);

        void ReName(string path, string name, string newname);

        void RanameFolder(string path, string name, string newname);

        void Copy(string olderpath, string newpath, string name);

        void folderCopy(string olderpath, string newpath, string name);

        long CalculateFile(string path);

        long FolderCalculateFile(string path);

        string Search(string path, string name);

        string FolderSearch(string path, string name);



        void Rewrite(string folderpath, string newpath);

        int Strings(string path, string name);

        int Words(string path, string name);

        int Symbol(string path, string name);

        int SymbolProb(string path, string name);









    }
}
