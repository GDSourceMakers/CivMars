using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;

namespace CivMars
{
    class PreDeliveredCrate : BuildingWGUI, IInventory, IHasGui, IRegystratabe, ISaveble
    {
        new string name = "Pre-Delivered Crate";
        new public static string ID = CivMarsInit.BlockSpace + ".PreDeliveredCrate";
        Inventory inv = new Inventory(10);


        public void Start()
        {
            //inv.Add();
        }

        public void Update()
        {
            bool torol = true;
            for (int i = 0; i < 10; i++)
            {
                if (inv.Get(i) != null)
                {
                    torol = false;
                }
                if (torol == false)
                {
                    i = 10;
                }
            }
            if (torol==true)
            {

            }

        }




        #region IInventory
        public Item Add(Item i)
        {
            return i;
        }

        public string GetInventoryName()
        {
            return name;
        }

        public int GetInventorySize()
        {
            return 10;
        }

        public int GetInventoryStackLimit(int i)
        {
            throw new NotImplementedException();
        }

        public Item GetStackInSlot(int i)
        {
            throw new NotImplementedException();
        }

        public bool HasCustomInventoryName()
        {
            return true;
        }

        public bool IsItemValidForSlot(int slot, Item givenItem)
        {
            return false;
        }

        public bool IsUseableByPlayer(Player p_70300_1_)
        {
            return true;
        }


        public Item Remove(Item i)
        {
            return inv.Remove(i);
        }

        public void TransferItem(IInventory ToInv, int index)
        {
            inv.TransferItem(ToInv, index);
        }

        public void TransferItemAmount(IInventory Toinv, int fromindex, int transferingAmount)
        {
            inv.TransferItemAmount(Toinv, fromindex, transferingAmount);
        }
        #endregion
        #region IRegystrateable
        public void Regystrate()
        {
            GameRegystry.RegisterBuildableBuilding(ID, this);
        }
        #endregion
    }
}
