using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    //[SerializeField] private GameObject playerReference;
    //[SerializeField] private float drown;


    private void OnTriggerEnter(Collider water)
    {
        Player.Instance.health = 0;
    }
}

