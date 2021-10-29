using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUIController : MonoBehaviour {

    public ItemElementPool itemElementPool;
    public TMP_Text totalWeight;

    public GameObject uiMessagePrefab;

    private Inventory inventory;

    private void Awake() {
        this.itemElementPool.SetUIController(this);
    }
    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
    }

    public void ShowMessage(string message) {
        UIMessage uiMessageComponent = Instantiate(uiMessagePrefab, this.transform).GetComponent<UIMessage>();
        uiMessageComponent.SetMessageText(message);
    }

    public void UpdateItemList() {
        this.itemElementPool.UpdateItemList(this.inventory.items);

        this.totalWeight.text = this.inventory.GetCurrentWeight() + "/" + this.inventory.maxWeight;
    }

    public void AdvanceTime() {
        this.inventory.AdvanceTime();
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
