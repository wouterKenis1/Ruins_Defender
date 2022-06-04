using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public string itemName;

    public StringIntDict cost = new StringIntDict();
    public int creationAmount = 1;

    public Item(string name, StringIntDict cost, int amount)
    {
        this.itemName = name;
        this.cost = cost;
        this.creationAmount = amount;
    }
}
