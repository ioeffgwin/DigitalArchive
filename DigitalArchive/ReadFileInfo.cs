using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System.IO;
//using MetadataExtractor;
//using MetadataExtractor.Formats.Exif;


namespace DigitalArchive
{

    /*
     * Jeff Vincent v1
     * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-get-information-about-files-folders-and-drives
     * 
     * 
     * 
     * 
     */


    public class ReadFileInfo
    {


        //filename
        public void GetFileInfo(string filePath)
        {
            if( filePath.Length == 0) filePath = @"D:\temp\example.jpg";
            FileAttributes attributes = File.GetAttributes(filePath);
            //Is it a directory
            Boolean fileDir = false;
            if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                fileDir = true;
            }
            //is it a system file
            Boolean fileSystem = false;
            if ((attributes & FileAttributes.System) == FileAttributes.System)
            {
                fileSystem = true;
            }
            // Read and Write:
            string fileReadOnly;
            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                fileReadOnly = "Yes";
            }
            else
            {
                fileReadOnly = "No";
            }
            string fileHidden;
            if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                fileHidden = "Yes";
            }
            else
            {
                fileHidden = "No";
            }

            string fileLocation = Path.GetDirectoryName(filePath);

            var file = ShellFile.FromFilePath(filePath);
            string fileDateCreated = file.Properties.System.DateCreated.Value.ToString();
            string fileDateModified = file.Properties.System.DateModified.Value.ToString();
            string fileType = file.Properties.System.FileExtension.Value;
            string fileName = file.Properties.System.FileName.Value;
            string fileSize = file.Properties.System.Size.Value.ToString();
            string fileDateTaken = file.Properties.System.ItemDate.Value.ToString();
            string fileHash = file.Properties.System.GetHashCode().ToString();

            /* this will only work for pics and movies
            var directories = ImageMetadataReader.ReadMetadata(filePath);
            var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            var dateTime = subIfdDirectory?.GetDescription(ExifDirectoryBase.TagDateTime);
            */
            /* this doesn't work. Not sure why
            string[] fileKeywords = file.Properties.System.Keywords.Value; //null
            string fileKeyword = String.Join(",", fileKeywords);
            string[] fileAuthors = file.Properties.System.Author.Value;
            string fileAuthor = String.Join(",", fileAuthors);
            */

            //hashing and chceksum - what value etc?



        }

        //filepath


        //size


        //checksum


        //metadata


        public static void ReadFiles()
        {
            string myDrive = @"D:\Public\Photos\Cosmeston";


            // You can also use System.Environment.GetLogicalDrives to
            // obtain names of all logical drives on the computer.
            System.IO.DriveInfo di = new System.IO.DriveInfo(myDrive);
            Console.WriteLine(di.TotalFreeSpace);
            Console.WriteLine(di.VolumeLabel);

            // Get the root directory and print out some information about it.
            System.IO.DirectoryInfo dirInfo = di.RootDirectory;
            Console.WriteLine(dirInfo.Attributes.ToString());

            // Get the files in the directory and print out some information about them.
            System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.*");

            foreach (System.IO.FileInfo fi in fileNames)
            {
                Console.WriteLine("{0}: {1}: {2}", fi.Name, fi.LastAccessTime, fi.Length);
            }

            // Get the subdirectories directly that is under the root.
            // See "How to: Iterate Through a Directory Tree" for an example of how to
            // iterate through an entire tree.
            System.IO.DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");

            foreach (System.IO.DirectoryInfo d in dirInfos)
            {
                Console.WriteLine(d.Name);
            }

            // The Directory and File classes provide several static methods
            // for accessing files and directories.

            // Get the current application directory.
            string currentDirName = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirName);

            // Get an array of file names as strings rather than FileInfo objects.
            // Use this method when storage space is an issue, and when you might
            // hold on to the file name reference for a while before you try to access
            // the file.
            //string[] files = System.IO.Directory.GetFiles(currentDirName, "*.*");
            string[] files = System.IO.Directory.GetFiles(myDrive, "*.*");

            foreach (string s in files)
            {
                // Create the FileInfo object only when needed to ensure
                // the information is as current as possible.
                System.IO.FileInfo fi = null;
                try
                {
                    fi = new System.IO.FileInfo(s);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    // To inform the user and continue is
                    // sufficient for this demonstration.
                    // Your application may require different behavior.
                    Console.WriteLine(e.Message);
                    continue;
                }
                Console.WriteLine("{0} : {1}", fi.Name, fi.Directory);
            }

            // Change the directory. In this case, first check to see
            // whether it already exists, and create it if it does not.
            // If this is not appropriate for your application, you can
            // handle the System.IO.IOException that will be raised if the
            // directory cannot be found.
            if (!System.IO.Directory.Exists(myDrive))
            {
                System.IO.Directory.CreateDirectory(myDrive);
            }

            System.IO.Directory.SetCurrentDirectory(myDrive);

            currentDirName = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirName);

        }
    }



    
}
