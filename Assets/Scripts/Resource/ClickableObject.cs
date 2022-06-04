using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    public UnityEvent e_OnClicked = new UnityEvent();

    public void Click()
    {
        e_OnClicked.Invoke();
    }
}
