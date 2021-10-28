using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "Inventory System/Items/Resource")]
public class Resource : Item, Deteriorable, Sellable {
    public float deterioration = 0f;
    public float deteriorationRate;

    public int initialValue;

    public void Initialize(Sprite itemSprite,
            string itemName,
            int weight,
            float deterioration,
            float deteriorationRate,
            int initialValue) {
        base.Initialize(itemSprite, itemName, weight);
        this.deterioration = deterioration;
        this.deteriorationRate = deteriorationRate;
        this.initialValue = initialValue;
    }

    public override Item GetClone() {
        Resource clone = CreateInstance<Resource>();
        clone.Initialize(this.itemSprite,
            this.itemName,
            this.weight,
            this.deterioration,
            this.deteriorationRate,
            this.initialValue);

        return clone;
    }

    public Item Deteriorate() {
        this.deterioration += this.deteriorationRate;
        if (this.deterioration > 1f) {
            this.deterioration = 1f;
        }

        return this;
    }

    public float GetDurability() {
        return 1 - this.deterioration;
    }

    public int GetValue() {
        if(this.deterioration == 1) {
            return 1;
        } else {
            return (int)(this.initialValue * (1f - this.deterioration));
        }
    }
}
