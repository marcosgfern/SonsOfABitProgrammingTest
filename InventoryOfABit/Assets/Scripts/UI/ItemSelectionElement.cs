using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/** Works as an initializer for UI item selection menu elements.
 */
public class ItemSelectionElement : MonoBehaviour {

    public Image itemIcon;
    public TMP_Text itemName;
    public TMP_Text weight;

    private Item itemType;
    private AddItemMenu addItemMenu;

    public void SetItemType(Item item) {
        this.itemType = item;

        this.itemIcon.sprite = item.itemSprite;
        this.itemName.text = item.itemName;
        this.weight.text = "Weight: " + item.weight;
    }

    public void SetAddItemMenu(AddItemMenu addItemMenu) {
        this.addItemMenu = addItemMenu;
    }

    public void SelectItem() {
        this.addItemMenu.AddItem(this.itemType);
    }
}
