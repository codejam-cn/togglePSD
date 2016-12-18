using System;
using System.IO;
using Microsoft.Win32;

namespace togglePSD
{
    internal class Program
    {
        private const string LogFilePath = @"E:\My\togglePSD\togglePSD\log.txt";

        private static void Main(string[] args)
        {
            Log.AddLog(LogFilePath, "service end" + DateTime.Now.ToString());

            //RegistryKey subKey = Registry.LocalMachine.OpenSubKey(@"HKEY_CLASSES_ROOT\Directory\Background\shell\TogglePSD");


            //if (subKey != null)
            //{
            //    object value = subKey.GetValue("toggle");

            //    Log.AddLog(LogFilePath, "service end" + value.ToString());
            //}


            //string curFolderPath = Directory.GetCurrentDirectory();
            //string[] files = Directory.GetFiles(curFolderPath);

            //for (int i = 0; i < files.Length; i++)
            //{
            //    string extend = Path.GetExtension(files[i]).ToLower();
            //    string path = files[i];

            //    if (extend == ".psd")
            //    {
            //        FileAttributes attributes = File.GetAttributes(path);
            //        if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            //        {
            //            attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
            //            File.SetAttributes(path, attributes);
            //        }
            //        else
            //        {
            //            File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
            //        }

            //    }
            //}
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