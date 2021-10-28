using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUIController : MonoBehaviour {

    public GameObject itemListElementPrefab;
    public GameObject content;
    public TMP_Text totalWeight;

    public GameObject uiMessagePrefab;

    private Inventory inventory;

    public void ShowMessage(string message) {
        UIMessage uiMessageComponent = Instantiate(uiMessagePrefab, this.transform).GetComponent<UIMessage>();
        uiMessageComponent.SetMessageText(message);
    }

    public void AdvanceTime() {
        this.inventory.AdvanceTime();
    }


    //Item list --------------------------------------------

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
    }

    public void UpdateItemList() {
        foreach (Transform child in this.content.transform) {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < this.inventory.items.Count; i++) {
            InstantiateNewItemListElement(this.inventory.items[i], i);
        }

        this.totalWeight.text = this.inventory.GetCurrentWeight() + "/" + this.inventory.maxWeight;
    }

    private void InstantiateNewItemListElement(Item item, int index) {
        GameObject itemListElement = Instantiate(this.itemListElementPrefab, this.content.transform);
        ItemListElementDisplay itemListElementDisplay = itemListElement.GetComponent<ItemListElementDisplay>();

        itemListElementDisplay.SetIcon(item.itemSprite);
        itemListElementDisplay.SetItemName(item.itemName);
        itemListElementDisplay.SetWeight(item.weight);

        if (item is Sellable) {
            Sellable sellableItem = (Sellable) item;
            itemListElementDisplay.SetValue(sellableItem.GetValue());
        } else {
            itemListElementDisplay.SetValue(null);
        }

        if (item is Deteriorable) {
            Deteriorable deteriorableItem = (Deteriorable)item;
            itemListElementDisplay.SetDurability(deteriorableItem.GetDurability());
        } else {
            itemListElementDisplay.SetDurability(null);
        }

        itemListElementDisplay.SetUsable(item is Usable);

        itemListElementDisplay.SetItemIndex(index);

        itemListElementDisplay.SetUIController(this);
    }

    public void Use(int index) {
        this.inventory.Use(index);
    }

    public void Delete(int index) {
        this.inventory.Delete(index);
    }

    public void AddItem(Item item) {
        this.inventory.Add(item);
    }


}
