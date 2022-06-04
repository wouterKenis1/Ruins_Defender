using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafterController : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void Craft(int type)
    {
        Craft((ItemType)type);
    }
    public void Craft(ItemType type)
    {

    }

}
