using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory System/Items/Weapon")]
public class Weapon : Item, Sellable, Usable {

    public int dps;

    public bool usesResource;
    public Resource neededResource;

    public int value;

    public int GetValue() {
        return this.value;
    }

    public void Use() {

    }
}
