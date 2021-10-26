using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject {

    public GameObject uiPrefab;
    public string itemName;
    public int weight;

}

public interface Deteriorable {
    float Deteriorate();
}

public interface Sellable {
    int GetValue();
}

public interface Usable {
    void Use();
}
