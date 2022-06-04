using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
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
        float ratio = player.health / player.maxHealth;
        transform.localScale = new Vector3(ratio, 1,1);
    }
}
