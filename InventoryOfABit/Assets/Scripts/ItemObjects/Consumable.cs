using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory System/Items/Consumable")]
public class Consumable : Item, Deteriorable, Usable {
    public float deterioration = 0f;
    public float deteriorationRate;

    public string useEffect;

    public Item garbageItem;

    public void Initialize(Sprite itemSprite,
            string itemName,
            int weight,
            float deterioration,
            float deteriorationRate,
            string useEffect, 
            Item garbageItem){
        base.Initialize(itemSprite, itemName, weight);
        this.deterioration = deterioration;
        this.deteriorationRate = deteriorationRate;
        this.useEffect = useEffect;
        this.garbageItem = garbageItem;

    }

    public override Item GetClone() {
        Consumable clone = CreateInstance<Consumable>();
        clone.Initialize(this.itemSprite,
            this.itemName,
            this.weight,
            this.deterioration,
            this.deteriorationRate,
            this.useEffect,
            this.garbageItem);

        return clone;
    }

    public Item Deteriorate() {
        this.deterioration += this.deteriorationRate;

        if (this.deterioration >= 1) {
            DefaultItem garbage = (DefaultItem) this.garbageItem.GetClone();
            garbage.weight = this.weight;
            return garbage;
        } else {
            return this;
        }
    }

    public float GetDurability() {
        return 1 - this.deterioration;
    }

    public string UseMessage() {
        return this.useEffect;
    }
}
