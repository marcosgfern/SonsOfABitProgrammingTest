using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Abstract superclass for every type of item.
 * ScriptableObjects created in the editor will work as templates.
 */
public abstract class Item : ScriptableObject {

    public Sprite itemSprite;
    public string itemName;
    public int weight;

    public void Initialize(Sprite itemSprite, string itemName, int weight) {
        this.itemSprite = itemSprite;
        this.itemName = itemName;
        this.weight = weight;
    }

    /** Returns a copy of the item.
     * It used for the ScriptableObjects to work as templates.
     */
    public abstract Item GetClone();
}

public interface Deteriorable {
    Item Deteriorate();

    ///Should return a value between 0 and 1.
    float GetDurability();
}

public interface Sellable {
    int GetValue();
}

public interface Usable {
    string UseMessage();
}
