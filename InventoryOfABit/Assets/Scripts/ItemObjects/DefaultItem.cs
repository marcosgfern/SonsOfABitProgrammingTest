using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Instantiable class for basic items with any extra attributes.
 */
[CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Items/Default Item")]
public class DefaultItem : Item {
    public override Item GetClone() {
        DefaultItem clone = CreateInstance<DefaultItem>();
        clone.Initialize(this.itemSprite, this.itemName, this.weight);
        return clone;
    }
}
