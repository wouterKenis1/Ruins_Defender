using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public ResourceList resources;


    public float health;
    public float maxHealth;
    public bool wasDeadLastFrame;


    public UnityEvent e_OnDeath = new UnityEvent();


    public bool IsDead
    {
        get
        {
            return health <= 0.0f;
        }
    }

    void Awake()
    {
        health = maxHealth;
        wasDeadLastFrame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        CheckDeath();
    }

    public void CheckDeath()
    {
        if(IsDead && !wasDeadLastFrame)
        {
            e_OnDeath.Invoke();
        }
        wasDeadLastFrame = IsDead;
    }

    public void AddResource(int type)
    {

    }
}
