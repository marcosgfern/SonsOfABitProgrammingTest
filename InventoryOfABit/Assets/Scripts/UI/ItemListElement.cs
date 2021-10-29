using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/** Works as an initializer for the UI item list elements. 
 */
public class ItemListElement : MonoBehaviour {

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text weight;
    [SerializeField] private TMP_Text value;
    [SerializeField] private TMP_Text durability;
    [SerializeField] private Button useButton;
    private int itemIndex;
    private InventoryUIController uiController;

    public void SetIcon(Sprite sprite) {
        this.icon.sprite = sprite;
    }

    public void SetItemName(string name) {
        this.itemName.text = name;
    }

    public void SetWeight(int weight) {
        this.weight.text = "Weight: " + weight;
    }

    public void SetValue(int? value) {
        if (value == null) {
            this.value.enabled = false;
        } else {
            this.value.enabled = true;
            this.value.text = "Value: " + value;
        }
    }

    public void SetDurability(float? durability) {
        if (durability == null) {
            this.durability.enabled = false;
        } else {
            this.durability.enabled = true;
            this.durability.text = "Durability: " + (int)(durability*100) + "%";
        }
    }

    public void SetUsable(bool usable) {
        this.useButton.interactable = usable;
    }

    public void SetItemIndex(int index) {
        this.itemIndex = index;
    }

    public void SetUIController(InventoryUIController uiController) {
        this.uiController = uiController;
    }

    public void Use() {
        this.uiController.Use(this.itemIndex);
    }

    public void Delete() {
        this.uiController.Delete(this.itemIndex);
    }
}
