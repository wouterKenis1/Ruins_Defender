using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName;

    public Dictionary<int, int> cost = new Dictionary<int, int>();
    public int creationAmount = 1;

    public Item(string name, Dictionary<int,int> cost, int amount)
    {
        this.itemName = name;
        this.cost = cost;
        this.creationAmount = amount;
    }
}

public class Tower_Wood_1 : Item
{
    public Tower_Wood_1() 
        : base("Tower_Wood_1",new Dictionary<int, int>() { { 0, 1 } },1)
    { }
}

public enum ItemType
{
    tower_wood_1
}