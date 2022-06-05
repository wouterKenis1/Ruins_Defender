using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrafterListView : MonoBehaviour
{
    Item data;

    public TMP_Text title;
    public ItemCostList costList;

    public void SetData(Item item)
    {
        data = item;
        Refresh();
    }

    private void Refresh()
    {
        title.text = data.itemName;
        costList.SetList(data.cost);
    }

    public void Craft()
    {
        CrafterController.Instance.Craft(data.itemName);
    }
}
