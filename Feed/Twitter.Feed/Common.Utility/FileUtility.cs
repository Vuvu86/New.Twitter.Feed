
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace Common.Utility
{
    public static class FileUtility
    {
     

        public static void EnsureDirectoryExists(string filePath)
        {
            try
            {
                if (Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static IEnumerable<string> GetFileNames(string fileName, string filePath)
        {
            try
            {
                var files = Directory.GetFiles(filePath, $"{fileName}*.*");
                var fileNames = new List<string>();
                fileNames.AddRange(files);
                return fileNames;
            }

            catch (Exception ex) { throw ex; }
        }

        public static string[] ReadFile(string fileName)
        {
            List<string> lines = new List<string>();
            try
            {
                string path = Environment.CurrentDirectory + @"\bin\Resources\" + fileName;
               
                EnsureDirectoryExists(path);

                foreach (var line in File.ReadAllLines(path))
                {
                    lines.Add(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            return lines.ToArray();
        }
        public static void UpdateFile(string fileName, string line)
        {
            try
            {
                string path = Environment.CurrentDirectory + @"\bin\Resources\" + fileName;
                EnsureDirectoryExists(path);

                using (StreamWriter sw = new StreamWriter(path,true))
                {
                    sw.Write(line);
                    sw.Close();
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    } 
}
