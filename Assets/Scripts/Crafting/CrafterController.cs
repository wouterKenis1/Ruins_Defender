using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrafterController : MonoBehaviour
{
    static CrafterController instance;
    public static CrafterController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<CrafterController>();
            }
            return instance;
        }
    }

    Player player;

    public List<Item> items;


    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void Craft(string itemName)
    {
        Item item = items.Where(entry => entry.itemName == itemName).FirstOrDefault();

        if(player.HasResources(item.cost))
        {
            player.RemoveItems(item.cost);
            player.AddItem(itemName,item.creationAmount);
        }
        else
        {
            Debug.LogWarning("Player does not have enough resources");
        }
    }

}
