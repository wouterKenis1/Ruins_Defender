using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public GameObject prefab;
    public stringGoDictionary objDict = new stringGoDictionary();

    Player player;

    private void Awake()
    {
        player = Player.Instance;
        player.e_itemsChanged.AddListener(Refresh);
    }

    private void OnEnable()
    {
        Refresh();
    }

    private void Refresh()
    {
        List<string> prevValues = new List<string> ();
        foreach(string value in objDict.Keys)
        {
            prevValues.Add(value);
        }

        foreach(var entry in player.Items)
        {
            
            if(!objDict.ContainsKey(entry.Key))
            {
                var obj = GameObject.Instantiate(prefab,transform);
                obj.name = entry.Key;
                obj.SetActive(true);
                objDict.Add(entry.Key, obj);
            }
            SetData(objDict[entry.Key], entry);
            prevValues.Remove(entry.Key);
        }

        foreach(string value in prevValues)
        {
            Destroy(objDict[value]);
            objDict.Remove(value);
        }
    }

    private void SetData(GameObject go, KeyValuePair<string,int> value)
    {
        go.GetComponentInChildren<ItemListEntry>().SetData(value);
    }
}
