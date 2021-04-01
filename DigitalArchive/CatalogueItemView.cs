using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DigitalArchive
{
    class CatalogueItemView
    {
        /*
         * J Vincent
         * View catalogue items and associated metadata
         * 
         * 
         * 
         * 
         */


        //from tblItems
        public int itemID;
        public DateTime itemAdded;
        public string itemAddedBy;
        public string itemName;
        public string itemPath;
        public string itemChecksum;
        public DateTime itemLastChange;
        public string itemOwner;
        public Boolean itemCopyright;
        public Boolean itemGDPR;
        //from tblItemMeta
        public string itemType;//meta data type of file (extension)
        public int itemSize; //meta data size of file in bytes (need to convert from string in DB)
        public string itemCreated; //metadata of date item created
        public string itemLastModified; //MetadataExtractor of date item last modified
        public string itemReadOnly; //metadata (as yes or no) if item set to read only
        public string itemHidden; //metadata (as yes or no) if item set to hidden (might be useful as a search if user can't see hidden files)
        public string itemDateTaken; //mainly only used in photos so could be null
        public string itemKeywords; //in addition to keywords retrieved from file user can add new to catalogue.
                                    //All need to be put together as comma delimited string
        public string itemLocaton; //data extracted as meta data file location when item originally added to catalogue


        public List<int> CatalogueItems(string searchStr)
        {
            /*
             * J Vincent
             * Return list of catalogue ItemIDs obtained from running query passed into method
             * 
             * 
             */

            //search string will either be for a specified item and return one item 
            //or a use a where clause to find a group of items by keyword etc
            List<int> SelectedItems = new List<int>();




            return SelectedItems;
        }


        public void CatalogueItem(int itemID)
        {
            /*
             * J Vincent
             * 
             * return details of item from catalogue
             * 
             * 
             */

            //"SELECT * FROM tblItems WHERE itemID = @itemID"

            //"SELECT * FROM tblItemMeta WHERE itemID = @itemID AND MetaTitle ='@Type'"
            //The following Metadata atributes may have been obtained
            //@Type can be one of the following: TYPE OF FILE, NAME, SIZE, CREATED, MODIFIED, READ ONLY, LOCATION, HIDDEN, DATE TAKEN, KEYWORDS
            //there may be more than one record with keyword so these will need to be concatinated with comma dividers
            //




            //assign values to public variables

        }






    }
}




