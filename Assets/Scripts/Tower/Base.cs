using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = Player.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Base was hit by: " + other.name);

        var enemy = other.GetComponent<Enemy>();
        if(enemy != null)
        {
            player.TakeDamage(enemy.dmg);
        }

        Destroy(other.gameObject);
    }




}
