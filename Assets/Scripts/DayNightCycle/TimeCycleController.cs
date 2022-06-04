using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeCycleController : MonoBehaviour
{
    public float cycleDuration = 60f;
    public Transform skysphere;

    public float timeOfCycle = 0;

    public bool wasDayLastFrame = false;
    public bool wasNightLastFrame = false;

    public UnityEvent e_OnDayStart = new UnityEvent();
    public UnityEvent e_OnNightStart = new UnityEvent();

    public bool IsDay
    {
        get
        {
            return timeOfCycle <= cycleDuration / 2f;
        }
    }
    public bool IsNight
    {
        get
        {
            return timeOfCycle > cycleDuration / 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeOfCycle += Time.deltaTime;
        timeOfCycle = timeOfCycle % cycleDuration;
        

        if(skysphere != null)
        {
            var rot = skysphere.rotation.eulerAngles;
            rot.z = timeOfCycle / cycleDuration * 360;
            skysphere.rotation = Quaternion.Euler(rot);
        }

        CheckDayInvoke();
    }

    private void CheckDayInvoke()
    {
        if(wasDayLastFrame && IsNight)
        {
            e_OnNightStart.Invoke();
        }
        else if(!wasDayLastFrame && IsDay)
        {
            e_OnDayStart.Invoke();
        }
        wasDayLastFrame = IsDay;
    }
}
