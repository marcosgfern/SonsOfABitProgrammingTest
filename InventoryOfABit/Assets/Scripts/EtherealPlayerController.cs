using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Class for inventory initialization.
 * Used as a component for a dull player game object.
 */
public class EtherealPlayerController : MonoBehaviour {

    public InventoryUIController inventoryUIController;
    public int inventoryMaxWeight;
    private Inventory inventory;

    private void Awake() {
        this.inventory = new Inventory(this.inventoryMaxWeight, this.inventoryUIController);
        this.inventoryUIController.SetInventory(this.inventory);
    }

}
