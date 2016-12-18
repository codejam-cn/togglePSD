using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace togglePSD
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //RegistryKey subKey = Registry.LocalMachine.OpenSubKey(@"HKEY_CLASSES_ROOT\Directory\Background\shell\TogglePSD");
            //if (subKey != null)
            //{
            //    object value = subKey.GetValue("toggle");
            //    Log.AddLog(LogFilePath, "service end" + value.ToString());
            //}
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");

            try
            {
                var curFolderPath = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
                var files = Directory.GetFiles(curFolderPath);
                if (files.Length > 0)
                {
                    foreach (string t in files)
                    {
                        var extension = Path.GetExtension(t);
                        if (extension != null)
                        {
                            var extend = extension.ToLower();
                            var path = t;
                            if (extend == ".psd")
                            {
                                var attributes = File.GetAttributes(path);
                                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                                {
                                    attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
                                    File.SetAttributes(path, attributes);
                                }
                                else
                                {
                                    File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                                }
                            }
                        }
                    }
                }
               
            }
            catch (Exception e)
            {
                Debug.Assert(e.InnerException != null, "e.InnerException != null");
                Log.AddLog(logFilePath,DateTime.Now.ToString(CultureInfo.CurrentCulture) + "\t" +  e.InnerException);
                throw;
            }
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