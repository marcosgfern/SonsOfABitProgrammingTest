using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Component for the adding items menu.
 * @availableItems: contains every item's ScriptableObject to use as templates.
 */
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
