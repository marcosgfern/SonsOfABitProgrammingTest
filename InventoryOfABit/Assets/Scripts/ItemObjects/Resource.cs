using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "Inventory System/Items/Resource")]
public class Resource : Item, Deteriorable, Sellable {
    public float deterioration = 0f;
    public float deteriorationRate;

    public int initialValue;

    public float Deteriorate() {
        this.deterioration += this.deteriorationRate;
        if (this.deterioration > 1f) {
            this.deterioration = 1f;
        }

        return this.deterioration;
    }

    public int GetValue() {
        if(this.deterioration == 1) {
            return 1;
        } else {
            return (int)(this.initialValue * (1f - this.deterioration));
        }
    }
}
