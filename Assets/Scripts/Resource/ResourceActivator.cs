using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceActivator : MonoBehaviour
{
    public List<GameObject> resources = new List<GameObject>();
    public int minResources = 1;
    public int maxResources = 10;


    private void Awake()
    {
        resources.Clear();
        var clickableObjects = GetComponentsInChildren<ClickableObject>();
        foreach(var clickableObj in clickableObjects)
        {
            resources.Add(clickableObj.gameObject);
            clickableObj.gameObject.SetActive(false);
        }
        maxResources = resources.Count;
    }

    [ContextMenu("GenerateRandom")]
    public void GenerateResources()
    {
        int amount = Random.Range(minResources, maxResources);
        GenerateResources(amount);
    }
    public void GenerateResources(int amount)
    {
        List<GameObject> inactiveResources = resources.Where(obj => obj.activeInHierarchy == false).ToList();
        
        amount = Mathf.Min(amount, inactiveResources.Count);

        for(int i = 0; i < amount; i++)
        {
            int id = Random.Range(0, inactiveResources.Count);
            inactiveResources[id].SetActive(true);
            inactiveResources.RemoveAt(id);
        }

        Debug.Log("Generated " + amount + " resources");
    }
}
