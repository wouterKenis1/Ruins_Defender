using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    [SerializeField] private GameObject playerReference;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "Player")
        {
            Player.Instance.health = 0;
        }
            
    }
}

