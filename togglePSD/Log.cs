using System.IO;

namespace togglePSD
{
    public class Log
    {
        public static void AddLog(string filePath, int msg)
        {
            AddLog(filePath, msg.ToString());
        }

        public static void AddLog(string filePath, string msg)
        {
            StreamWriter ss = File.AppendText(filePath);
            ss.Write(msg + "\r");
            ss.Close();
        }
 
    }
}