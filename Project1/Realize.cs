using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Windows;

namespace Project1
{
    class Realize : IManager
    {
        int i = 0;
        int c = 0;
        bool firstsearch = false;

        public long CalculateFile(string path)
        {
            FileInfo file = new FileInfo(path);
            long value = file.Length;
            return value;
        }

        public long FolderCalculateFile(string path)
        {
            long value = 0;

            foreach( var file in Directory.GetFiles(path))
            {
                value = value + file.Length;
            }
            foreach(var folder in Directory.GetDirectories(path))
            {
                FolderCalculateFile(path);
            }


            return value;
        }

        public void Create(string name, string path)
        {
            FileInfo file= new FileInfo(path + "\\" + name + ".txt");
            if (file.Exists)
            {
                file = new FileInfo(path + "\\" + name +$"({i})" + ".txt");
                file.Create();
                i++;
            }
            FileStream fstream = new FileStream(path + "\\" + name + ".txt", FileMode.OpenOrCreate);
            fstream.Close();
        }

        public void CreateDirectory(string name, string path)
        {
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path + "\\" + name + $"({i})");
                i++;
            }
            Directory.CreateDirectory(path + "\\" + name);
        }

        public void Delete(string path, string name)
        {
            string fullfolder = path + "\\" + name + ".txt";
            File.Delete(fullfolder);
        }

        public void Deletefld(string path, string name)
        {
            string fullfolder = path + "\\" + name;
            Directory.Delete(fullfolder);
        }

        public void Copy(string olderpath, string newpath, string name)
        {
            if (olderpath == newpath)
            {
                try
                {
                    i++;
                    File.Copy(olderpath + "\\" + name + ".txt", newpath + "\\" + name + "v" + i + ".txt", false);
                    return;
                }
                catch (IOException)
                {
                    Copy(olderpath, newpath, name);
                }
                return;
            }
            File.Copy(olderpath + "\\" + name + ".txt", newpath + "\\" + name + ".txt", false);
        }


        public void folderCopy(string olderpath, string newpath, string name)
        {
            if (Directory.Exists(newpath + "\\" + name))
            {
                try 
                {
                    while(Directory.Exists(newpath + "\\" + name))
                    {
                        newpath = olderpath + "\\" + name + $"({i})";
                        i++;
                    }
                    olderpath = olderpath + "\\" + name;
                    Directory.CreateDirectory(newpath);
                    Rewrite(olderpath, newpath);
                    return;
                }
                catch
                {
                    folderCopy(olderpath,  newpath, name);
                }
             
            }
            olderpath = olderpath + "\\" + name;
            Directory.CreateDirectory(newpath + "\\" + name);
            Rewrite(olderpath, newpath);
            return;
        }

        public void Rewrite(string source, string dest)
        {
            if (String.IsNullOrEmpty(source) || String.IsNullOrEmpty(dest)) return;
            Directory.CreateDirectory(dest);
            foreach (string fn in Directory.GetFiles(source))
            {
                File.Copy(fn, Path.Combine(dest, Path.GetFileName(fn)), true);
            }
            foreach (string dir_fn in Directory.GetDirectories(source))
            {
                Rewrite(dir_fn, Path.Combine(dest, Path.GetFileName(dir_fn)));
            }
        }

        public void RanameFolder(string path, string name, string newname)
        {
            Directory.Move(path + "\\" + name, path + "\\" + newname);
        }

        public void ReName(string path, string name, string newname)
        {
            File.Move(path + "\\" + name + ".txt", path + "\\" + newname + ".txt");
        }

        public List<string> ShowCatalog(string nameCatalog)
        {
            throw new System.NotImplementedException();
        }

        public string Search(string path, string name)
        {
            string pathtosearch = "";
            foreach(var c in Directory.EnumerateFiles(path, name + ".txt", SearchOption.AllDirectories))
            {
                FileInfo file = new FileInfo(c);
                pathtosearch = file.FullName;
            }
            return pathtosearch;

        }

        public string FolderSearch(string path, string name)
        {
            string pathtosearch = "";
            foreach (var c in Directory.EnumerateDirectories(path, name, SearchOption.AllDirectories))
            {
                DirectoryInfo file = new DirectoryInfo(c);
                pathtosearch = file.FullName;
            }
            return pathtosearch;
        }

        public int Strings(string path, string name)
        {
            int count = 0;
            List<string> vs = new List<string>();
            string[] vs1 = File.ReadAllLines(path + "\\" + name + ".txt");
            count = vs1.Length;
            return count;
        }


        public int Words(string path, string name)
        {
            int count = 0;
            List<string> vs = new List<string>();
            string[] vs1 = File.ReadAllLines(path + "\\" + name + ".txt");
            foreach (var c in vs1)
            {
                string op = c;
                string[] vs2 = op.Split(' ');
                count = count + vs2.Length;
            }
            return count;
        }

        public int Symbol(string path, string name)
        {
            int count = 0;
            List<string> vs = new List<string>();
            string[] vs1 = File.ReadAllLines(path + "\\" + name + ".txt");
            foreach (var c in vs1)
            {
                string op = c;
                string[] vs2 = op.Split(' ');
                foreach (var a in vs2)
                {
                    count = count + a.Length;
                }
            }
            return count;
        }

        public int SymbolProb(string path, string name)
        {
            int count = 0;
            List<string> vs = new List<string>();
            string[] vs1 = File.ReadAllLines(path + "\\" + name + ".txt");
            count = vs1.Length;
            foreach (var c in vs1)
            {
                count = count + c.Length;
            }
            return count;
        }
    }
}