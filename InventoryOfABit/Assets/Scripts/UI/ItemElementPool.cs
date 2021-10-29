using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Class for pooling implementation on item list elements, which enhances performance,
 * (eventhough it's not necessary for this case).
 */
public class ItemElementPool : MonoBehaviour
{
    public GameObject itemListElementPrefab;

    [SerializeField] private int initialSize = 8;

    private InventoryUIController uiController;

    private void Start() {
        for (int i = 0; i < initialSize; i++) {
            AddItemListElementToPool();
        }
    }

    public void SetUIController(InventoryUIController uiController) {
        this.uiController = uiController;
    }

    public void UpdateItemList(List<Item> list) {
        foreach (Transform child in this.transform) {
            child.gameObject.SetActive(false);
        }

        for (int i = 0; i < list.Count; i++) {
            ResetItemListElement(GetItemListElement(), list[i], i);
        }
    }

    private void ResetItemListElement(ItemListElement itemListElement, Item item, int index) {
        itemListElement.SetIcon(item.itemSprite);
        itemListElement.SetItemName(item.itemName);
        itemListElement.SetWeight(item.weight);

        if (item is Sellable) {
            Sellable sellableItem = (Sellable)item;
            itemListElement.SetValue(sellableItem.GetValue());
        } else {
            itemListElement.SetValue(null);
        }

        if (item is Deteriorable) {
            Deteriorable deteriorableItem = (Deteriorable)item;
            itemListElement.SetDurability(deteriorableItem.GetDurability());
        } else {
            itemListElement.SetDurability(null);
        }

        itemListElement.SetUsable(item is Usable);
        itemListElement.SetItemIndex(index);

        itemListElement.gameObject.SetActive(true);
    }

    private ItemListElement GetItemListElement() {
        ItemListElement itemListElement = null;

        foreach(Transform child in this.transform) {
            if (!child.gameObject.activeSelf) {
                itemListElement = child.GetComponent<ItemListElement>();
                break;
            }
        }

        if(itemListElement == null) {
            return AddItemListElementToPool();
        } else {
            return itemListElement;
        }
    }

    private ItemListElement AddItemListElementToPool() {
        GameObject itemListElement = Instantiate(this.itemListElementPrefab, this.transform);
        itemListElement.SetActive(false);
        ItemListElement itemListElementComponent = itemListElement.GetComponent<ItemListElement>();
        itemListElementComponent.SetUIController(this.uiController);
        return itemListElementComponent;
    }
}
