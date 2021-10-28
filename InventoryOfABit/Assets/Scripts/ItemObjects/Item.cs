using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject {

    public Sprite itemSprite;
    public string itemName;
    public int weight;

    public void Initialize(Sprite itemSprite, string itemName, int weight) {
        this.itemSprite = itemSprite;
        this.itemName = itemName;
        this.weight = weight;
    }

    public abstract Item GetClone();
}

public interface Deteriorable {
    Item Deteriorate();

    float GetDurability();
}

public interface Sellable {
    int GetValue();
}

public interface Usable {
    string UseMessage();
}
