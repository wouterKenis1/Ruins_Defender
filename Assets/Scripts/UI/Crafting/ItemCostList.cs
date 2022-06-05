using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCostList : MonoBehaviour
{
    public GameObject prefab;

    StringIntDict dict = new StringIntDict();
    List<GameObject> objList = new List<GameObject> ();
    public void SetList(StringIntDict cost)
    {
        dict = cost;
        Refresh();
    }

    void Refresh()
    {
        int prevAmount = objList.Count;
        for(int i = 0; i < prevAmount; i++)
        {
            Destroy(objList[0]);
            objList.RemoveAt(0);
        }
        foreach(var entry in dict)
        {
            GameObject go = GameObject.Instantiate(prefab,transform);
            go.GetComponent<ItemCostEntry>().SetData(entry);
            go.SetActive(true);
            objList.Add(go);
        }

    }
}
