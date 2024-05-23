using System;
using System.IO;
using System.Linq;
using System.Text;

namespace FileRenamer
{
    class Program
    {
        private static StringBuilder sb = new StringBuilder();
        public int count = 0;
        public static void Main(string[] args)
        {
          
            Console.WriteLine("File Renamer");
   
            string path = @"C:\backup\stand-from-tarhely-2";
                if (File.Exists(path))
                {
                    // This path is a file
                    ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    ProcessDirectory(path);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", path);
                }
            File.AppendAllText("log.txt", sb.ToString());
            sb.Clear();
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // Insert logic for processing found files here.
        public static void ProcessFile(string path)
        {
            //Console.WriteLine("Processed file '{0}'.", path);
            FileInfo f = new FileInfo(path);
            string oldName = f.FullName;
            //Console.WriteLine( f.Name);
            /*Å‘ - ő
            Å± - ű
            Ãº - ú
            Ã© - é
            Ã¡ - á
            aÌ - á
            Ã¼ - ü
            Ã³ - ó
            Ã­ - í
            Ã¶ - ö*/
            string newName = oldName.Replace("â„¢", "™").Replace("Ã","Á").Replace("Å‘", "ő").Replace("oÌ‹", "ő").Replace("Å±", "ű").Replace("Ãº", "ú").Replace("Ã©", "é").Replace("e´","é").Replace("eÌ","é").Replace("Ã¡","á").Replace("aÌ", "á").Replace("Ã¼", "ü").Replace("Ã³", "ó").Replace("Ã¶", "ö").Replace("Ã–","Ö").Replace("o¨","ö").Replace("oÌˆ", "ö").Replace("Ã‰","É").Replace("Ã‰", "É").Replace("Ãš","Ú").Replace("Ãœ", "Ü").Replace("Ã“", "Ó").Replace("Ã•", "Ő").Replace("Ã›", "Ű").Replace("Ã-­", "í").Replace("i´","í").Replace("iÌ","í").Replace("Ã­", "í").Replace("", ""); 
           if (oldName != newName)
            {
                
                try
                {
                    System.IO.File.Move(oldName, newName);
                    Console.WriteLine("File renamed from: " + oldName + " to: " + newName);
                    sb.Append("File renamed from: " + oldName + " to: " + newName+'\n');
                } catch(Exception e)
                {
                    sb.Append("Error! Cannot rename File  from: " + oldName + " to: " + newName + e.Message + '\n');
                    Console.WriteLine("Error! Cannot rename File  from: " + oldName + " to: " + newName+ e.Message);
                }
            }
        }
    }
}
