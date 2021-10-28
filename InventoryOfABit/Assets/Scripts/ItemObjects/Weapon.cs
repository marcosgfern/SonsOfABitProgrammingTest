using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory System/Items/Weapon")]
public class Weapon : Item, Sellable, Usable {

    public int dps;

    public bool usesResource;
    public Resource neededResource;

    public string useEffect;

    public int value;

    public void Initialize(Sprite itemSprite,
            string itemName,
            int weight,
            int dps,
            bool usesResource,
            Resource neededResource,
            string useEffect,
            int value) {
        base.Initialize(itemSprite, itemName, weight);
        this.dps = dps;
        this.usesResource = usesResource;
        this.neededResource = neededResource;
        this.useEffect = useEffect;
        this.value = value;
    }

    public override Item GetClone() {
        Weapon clone = CreateInstance<Weapon>();
        clone.Initialize(this.itemSprite,
            this.itemName,
            this.weight,
            this.dps,
            this.usesResource,
            this.neededResource,
            this.useEffect,
            this.value);

        return clone;
    }

    public int GetValue() {
        return this.value;
    }

    public string UseMessage() {
        return this.useEffect + " Damage: " + this.dps;
    }
}
