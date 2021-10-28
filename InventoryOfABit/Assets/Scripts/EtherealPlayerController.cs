using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtherealPlayerController : MonoBehaviour {

    public InventoryUIController inventoryUIController;
    public int inventoryMaxWeight;
    private Inventory inventory;

    private void Awake() {
        this.inventory = new Inventory(this.inventoryMaxWeight, this.inventoryUIController);
        this.inventoryUIController.SetInventory(this.inventory);
    }

}
