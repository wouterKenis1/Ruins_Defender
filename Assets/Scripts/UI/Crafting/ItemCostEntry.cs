using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCostEntry : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text amountText;
    internal void SetData(KeyValuePair<string, int> entry)
    {
        nameText.text = entry.Key;
        amountText.text = entry.Value.ToString();
    }
}
