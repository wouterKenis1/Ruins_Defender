using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafterList : MonoBehaviour
{
    public GameObject prefab;
    public stringGoDictionary objDict = new stringGoDictionary();
    List<GameObject> objList = new List<GameObject> ();

    CrafterController crafter;


    private void Awake()
    {
        crafter = FindObjectOfType<CrafterController>();
    }

    private void OnEnable()
    {
        Refresh();
    }

    private void Refresh()
    {
        int prevAmount = objList.Count;
        for (int i = 0; i < prevAmount; i++)
        {
            Destroy(objList[0]);
            objList.RemoveAt(0);
        }
        foreach (Item item in crafter.items)
        {        
            var obj = GameObject.Instantiate(prefab, transform);
            obj.name =item.itemName;
            obj.SetActive(true);
            SetData(obj, item);
            objList.Add(obj);
        }
    }

    private void SetData(GameObject go, Item value)
    {
        go.GetComponentInChildren<CrafterListEntry>().SetData(value);
    }
}
