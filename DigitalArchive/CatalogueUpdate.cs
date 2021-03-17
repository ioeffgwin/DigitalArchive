using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalArchive
{
    public class CatalogueUpdate 
    {

        public static void Main()
        {
            int itemID; //blank if new item //all others blank for deletetion
            DateTime itemAdded;
            string itemAddedBy;
            string itemName;
            string itemPath;
            string itemChecksum;
            DateTime itemLastChange;
            string itemOwner;
            Boolean itemCopyright;
            Boolean itemGDPR;

            

        }
        public CatalogueUpdate()
        {

        }

        public Boolean AddItem(string newItem)
        {
            Boolean bAddSuccess = false;
            // add things to tblItems and tblItemMeta

            return bAddSuccess;
        }

        public Boolean ChangeItem(int item)
        {
            Boolean bChangeSuccess = false;
            // change things in tblItems. Maybe delete, change or add in tblItemMeta

            return bChangeSuccess;

        }

        public Boolean DeleteItem(int item)
        {
            Boolean bDeleteSuccess = false;
            // delete things from tblItems and tblItemMeta

            return bDeleteSuccess;

        }


    }
}
