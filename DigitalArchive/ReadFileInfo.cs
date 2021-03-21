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
     * Jeff Vincent 
     * get meta info from files
     * 
     * 
     * 
     * 
     * 
     */


    public class ReadFileInfo
    {
        /*
         * J Vincent
         * Read the meta data from the file 
         * 
         * not all data yet available so default values set on some
         * for meta items if null they won't be added to catalogue
         * 
         * 
         */

        public Boolean fileDir; //is it a directory - no need to save if true
        public Boolean fileSystem; //is it a system file - no need to save if true

        public string fileName; // file.Properties.System.FileName.Value;  //tblItems
        public string fileLocation; //path of the file - should be from root of catalogue //tblItems
        public string fileHash; // file.Properties.System.GetHashCode().ToString();  //tblItems
        public string fileOwner = ""; // this is not a mandatory field but an empty string may handle better than null  //tblItems
        public Boolean fileCopyright = default; // is the file subject to copyright default false  //tblItems
        public Boolean fileGDPR = default; // is the file subject to GDPR default false  //tblItems

        public string fileMetaReadOnly; // Yes or No
        public string fileMetaHidden; //Yes or No
        public string fileMetaDateCreated; //file.Properties.System.DateCreated.Value.ToString();
        public string fileMetaDateModified; // file.Properties.System.DateModified.Value.ToString();
        public string fileMetaType; // file.Properties.System.FileExtension.Value;
        public string fileMetaSize; //file.Properties.System.Size.Value.ToString();
        public string fileMetaDateTaken; // file.Properties.System.ItemDate.Value.ToString();
        public string fileMetaAuthor; //ideally from author keyword
        public string fileMetaKeyword; // string with comma delimted keywords. ideally from file keywords




        public void GetFileInfo(string filePath)
        {
            try
            {


                //Is it a valid file
                if (File.Exists(filePath))
                {
                    FileAttributes attributes = File.GetAttributes(filePath);

                    //Is it a directory
                    this.fileDir = false;
                    if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        this.fileDir = true;
                    }
                    //is it a system file
                    this.fileSystem = false;
                    if ((attributes & FileAttributes.System) == FileAttributes.System)
                    {
                        this.fileSystem = true;
                    }
                    if (this.fileDir == false)
                    {
                        // Read and Write:
                        if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        {
                            this.fileMetaReadOnly = "Yes";
                        }
                        else
                        {
                            this.fileMetaReadOnly = "No";
                        }
                        // hidden file
                        if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                        {
                            this.fileMetaHidden = "Yes";
                        }
                        else
                        {
                            this.fileMetaHidden = "No";
                        }

                        // this needs to be the path relative to the catalogue

                        this.fileLocation = Path.GetDirectoryName(filePath).Replace(Globals.curCatPath, "");

                        var file = ShellFile.FromFilePath(filePath);
                        //date created
                        this.fileMetaDateCreated = file.Properties.System.DateCreated.Value.ToString();
                        //date modified
                        this.fileMetaDateModified = file.Properties.System.DateModified.Value.ToString();
                        //type of file (extension)
                        this.fileMetaType = file.Properties.System.FileExtension.Value;
                        //filename
                        this.fileName = file.Properties.System.FileName.Value;
                        //filesize in bytes
                        this.fileMetaSize = file.Properties.System.Size.Value.ToString();
                        //date taken (might be null)
                        this.fileMetaDateTaken = file.Properties.System.ItemDate.Value.ToString();
                        //file hash sha-256
                        this.fileHash = CheckSum.Main(filePath);

                        /* this will only work for pics and movies
                        var directories = ImageMetadataReader.ReadMetadata(filePath);
                        var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
                        var dateTime = subIfdDirectory?.GetDescription(ExifDirectoryBase.TagDateTime);
                        */

                        //file authors
                        //file keywords

                        /* this doesn't work. Not sure why
                        string[] fileMetaKeywords = file.Properties.System.Keywords.Value; //null
                        this.fileMetaKeyword = String.Join(",", fileKeywords);
                        string[] fileMetaAuthors = file.Properties.System.Author.Value;
                        this.fileMetaAuthor = String.Join(",", fileMetaAuthors);
                        */
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }




        }

    }




}
