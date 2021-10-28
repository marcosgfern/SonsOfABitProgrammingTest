using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    public List<Item> items;
    public int maxWeight;
    private InventoryUIController inventoryUIController;


    public Inventory(int maxWeight, InventoryUIController inventoryUIController) {
        this.items = new List<Item>();
        this.maxWeight = maxWeight;
        this.inventoryUIController = inventoryUIController;
    }

    public int GetCurrentWeight() {
        int currentWeight = 0;
        foreach (Item item in this.items) {
            currentWeight += item.weight;
        }

        return currentWeight;
    }

    public void Add(Item item) {
        if (item.weight + GetCurrentWeight() > this.maxWeight) {
            this.inventoryUIController.ShowMessage("Not enough space left.");
        } else {
            this.items.Add(item.GetClone());
            this.inventoryUIController.UpdateItemList();
        }
    }

    public void Delete(int index) {
        this.items.RemoveAt(index);
        this.inventoryUIController.UpdateItemList();
    }

    public void Use(int index) {
        try {
            Usable usableItem = (Usable) this.items[index];
            switch (usableItem) {
                case Consumable c:
                    this.inventoryUIController.ShowMessage(c.UseMessage());
                    Delete(index);
                    break;

                case Weapon w when (!w.usesResource):
                    this.inventoryUIController.ShowMessage(w.UseMessage());
                    break;

                case Weapon w when (w.usesResource):
                    if(w.neededResource == null) {
                        this.inventoryUIController.ShowMessage("This weapon is under development");
                    } else {
                        if (this.UseResource(w.neededResource)) {
                            this.inventoryUIController.ShowMessage(w.UseMessage());
                        } else {
                            this.inventoryUIController.ShowMessage("No " + w.neededResource.itemName.ToLower() + " left, friend.");
                        }
                    }
                    break;

                default:
                    this.inventoryUIController.ShowMessage("It does nothing");
                    break;
            }
        } catch (System.InvalidCastException) {
            this.inventoryUIController.ShowMessage("Those fools who dare to use this item, shall be punished!");
        }
    }

    private bool UseResource(Resource resource) {
        Resource resourceInInventory = (Resource) this.items.Find(r => r.itemName == resource.itemName);
        if (resourceInInventory == null) {
            return false;
        } else {
            this.items.Remove(resourceInInventory);
            this.inventoryUIController.UpdateItemList();
            return true;
        }
    }

    public void AdvanceTime() {
        for (int i = 0; i < this.items.Count; i++) {
            if (items[i] is Deteriorable) {
                Deteriorable deteriorableItem = (Deteriorable)items[i];
                items[i] = deteriorableItem.Deteriorate();
            }
        }

        this.inventoryUIController.UpdateItemList();
    }

}
