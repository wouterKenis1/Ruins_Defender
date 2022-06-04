using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemListEntry : MonoBehaviour
{
    public string itemName;
    public int amount;

    public TMP_Text text;


    public void SetData(KeyValuePair<string,int> value)
    {
        itemName = value.Key;
        amount = value.Value;
        text.text = itemName + ":\t" + amount.ToString();
    }
}
