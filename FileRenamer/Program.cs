using System;
using System.IO;
using System.Linq;

namespace FileRenamer
{
    class Program
    {
        public int count = 0;
        public static void Main(string[] args)
        {
          
            Console.WriteLine("File Renamer");
            string path = @"C:\backup\uploads";
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
            Ã¼ - ü
            Ã³ - ó
            Ã­ - í
            Ã¶ - ö*/
            string newName = oldName.Replace("Å‘", "ő").Replace("Å±", "ű").Replace("Ãº", "ú").Replace("Ã©", "é").Replace("Ã¡","á").Replace("Ã¼", "ü").Replace("Ã³", "ó").Replace("Ã¶", "ö").Replace("Ã", "í");
           if(oldName != newName)
            {
                Console.WriteLine("File renamed from: "+oldName+" to: "+newName);
                System.IO.File.Move(oldName, newName);
            }
        }
    }
}
