using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    public UnityEvent e_OnClicked = new UnityEvent();
    public UnityEvent e_OnPlayerInRange = new UnityEvent();
    public UnityEvent e_OnPlayerLeftRange = new UnityEvent();

    public float maxPlayerRange = 5f;

    bool wasInrange = false;
    bool isInRange = false;

    private void Update()
    {
        isInRange = maxPlayerRange <= 0f || Vector3.Distance(transform.position, Player.Instance.transform.position) <= maxPlayerRange;
        if (wasInrange && !isInRange)
        {
            e_OnPlayerLeftRange.Invoke();
        }
        else if(!wasInrange && isInRange)
        {
            e_OnPlayerInRange.Invoke();
        }
        wasInrange = isInRange;
    }

    public virtual void Click()
    {
        // if maxRange less or equal to 0; any click will work
        // else, only invoke if player is in range
        if(isInRange)
        {
            e_OnClicked.Invoke();
        }
    }
}
