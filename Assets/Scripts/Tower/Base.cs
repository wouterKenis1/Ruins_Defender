using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    string horizontal = "Horizontal";



    private void Test()
    {
        Input.GetAxis(horizontal);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Base was hit by: " + other.name);

        Destroy(other.gameObject);
    }
}
