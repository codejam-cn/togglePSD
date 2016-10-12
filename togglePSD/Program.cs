using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace togglePSD
{
    class Program
    {
        static void Main(string[] args)
        {         


            string curFolderPath = Directory.GetCurrentDirectory();

            string[] files = Directory.GetFiles(curFolderPath);

            for (int i = 0; i < files.Length; i++)
            {
                string extend = Path.GetExtension(files[i]).ToLower();
                string path = files[i];

                if (extend == ".psd")
                {
                    FileAttributes attributes = File.GetAttributes(path);

                    if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    {
                        // Show the file.
                        attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
                        File.SetAttributes(path, attributes);
//                        Console.WriteLine("The {0} file is no longer hidden.", path);
                    }
                    else
                    {
                        // Hide the file.
                        File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
//                        Console.WriteLine("The {0} file is now hidden.", path);
                    }

                }
            }

            Console.ReadLine();
        }

        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
    }
}


/*
   public enum FileAttributes
  {
    ReadOnly = 1,
    Hidden = 2,
    System = 4,
    Directory = 16,
    Archive = 32,
    Device = 64,
    Normal = 128,
    Temporary = 256,
    SparseFile = 512,
    ReparsePoint = 1024,
    Compressed = 2048,
    Offline = 4096,
    NotContentIndexed = 8192,
    Encrypted = 16384,
    [ComVisible(false)] IntegrityStream = 32768,
    [ComVisible(false)] NoScrubData = 131072,
  }
 
 
 */