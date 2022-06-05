using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrafterListEntry : MonoBehaviour
{
    public TMP_Text text;
    public Button btn;

    Item data;
    public CrafterListView view;

    public void SetData(Item item)
    {
        data = item;
        text.text = item.itemName;
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        view.SetData(data);
    }
}
