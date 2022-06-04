using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manabar : MonoBehaviour
{
    MaskableGraphic graphic;
    Player player;

    private void Awake()
    {
        graphic = GetComponent<MaskableGraphic>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        float ratio = player.mana / player.maxMana;
        transform.localScale = new Vector3(ratio, 1, 1);
    }
}
