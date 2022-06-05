using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    public UnityEvent e_OnClicked = new UnityEvent();
    public float maxPlayerRange = 5f;

    public void Click()
    {
        // if maxRange less or equal to 0; any click will work
        // else, only invoke if player is in range
        if(maxPlayerRange <= 0f || Vector3.Distance(transform.position,Player.Instance.transform.position) <= maxPlayerRange)
        {
            e_OnClicked.Invoke();
        }
    }
}
