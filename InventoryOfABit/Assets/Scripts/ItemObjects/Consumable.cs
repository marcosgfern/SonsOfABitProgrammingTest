using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory System/Items/Consumable")]
public class Consumable : Item, Deteriorable, Usable {
    public float deterioration = 0f;
    public float deteriorationRate;

    public string useEffect;

    public float Deteriorate() {
        return this.deterioration += this.deteriorationRate;
    }

    public void Use() {
        Debug.Log(this.useEffect);
    }
}
