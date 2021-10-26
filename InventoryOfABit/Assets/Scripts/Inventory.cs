using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    private List<Item> items;
    private int maxWeight;

    public Inventory(int maxWeight) {
        this.maxWeight = maxWeight;
    }
}
