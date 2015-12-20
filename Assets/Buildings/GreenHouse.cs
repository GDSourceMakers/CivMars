using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GreenHouse : Building, IInventory, IHasGui, IBuildable, IRegystratabe
{
    Inventory storage = new Inventory(5);
    public Sprite icon;
    Item[] x = { new IronPlate(1), new GlassPlane(1), new Sapling(1) };
    string ID = "CivMars.GreenHouse";
    float timeleft = 6000;
    bool onoff = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onoff == true)
        {
            timeleft -= Time.deltaTime;
            if (timeleft <= 0)
            {
                storage.Add(new Wood(10));
                storage.Add(new Sapling(3));
                if (storage.Remove(new Sapling(1)) != null)
                {
                    timeleft = 6000;

                }

            }
        }



    }

    #region IInventory

    public Item Add(Item i)
    {
        return storage.Add(i);
    }

    public string GetInventoryName()
    {
        throw new NotImplementedException();
    }

    public int GetInventorySize()
    {
        return storage.size;
    }

    public int GetInventoryStackLimit(int i)
    {
        throw new NotImplementedException();
    }

    public Item GetStackInSlot(int i)
    {
        return storage.Get(i);
    }

    public bool HasCustomInventoryName()
    {
        throw new NotImplementedException();
    }

    public bool IsItemValidForSlot(int slot, Item givenItem)
    {
        if (givenItem is Sapling || givenItem is Wood)
        {
            return true;
        }
        return false;
    }

    public bool IsUseableByPlayer(Player p_70300_1_)
    {
        return true;
    }

    public Item Remove(Item i)
    {
        return storage.Remove(i);
    }

    public void TransferItem(IInventory ToInv, int index)
    {
        storage.TransferItem(ToInv, index);
    }

    public void TransferItemAmount(IInventory Toinv, int fromindex, int transferingAmount)
    {
        storage.TransferItemAmount(Toinv, fromindex, transferingAmount);
    }


    #endregion

    #region IBuildable

    public float GetBuildtime()
    {
        return 10;
    }

    public Sprite GetImage()
    {
        return icon;
    }

    public GameObject GetPrefab()
    {
        return this.gameObject;
    }

    public Image GetBuildedState()
    {
        throw new NotImplementedException();
    }

    public Item[] GetNeededMaterials()
    {
        return x;
    }

    public void Setup()
    {
        throw new NotImplementedException();
    }


    #endregion

    #region IRegystratable

    public void Regystrate()
    {
		base.ID = this.ID;
		GameRegystry.RegisterBuildableBuilding(ID, this);
    }

    #endregion




}
