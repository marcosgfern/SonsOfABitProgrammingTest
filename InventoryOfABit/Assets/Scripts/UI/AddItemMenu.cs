using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemMenu : MonoBehaviour {

    public Item[] availableItems;
    public GameObject content;
    public GameObject itemSelectionElementPrefab;
    public InventoryUIController inventoryUIController;

    private void Start() {
        foreach (Item item in this.availableItems) {
            ItemSelectionElement itemSelectionElement = Instantiate(this.itemSelectionElementPrefab, this.content.transform).GetComponent<ItemSelectionElement>();

            itemSelectionElement.SetItemType(item);
            itemSelectionElement.SetAddItemMenu(this);
        }
    }

    public void AddItem(Item item) {
        this.inventoryUIController.AddItem(item);
    }
}
