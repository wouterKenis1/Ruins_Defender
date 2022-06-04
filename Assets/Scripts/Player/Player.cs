using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public ResourceList resources;
    public Dictionary<Item, int> items = new Dictionary<Item, int>();


    public float health = 100f;
    public float maxHealth = 100f;
    public float healthRegen = 1f;

    public float mana = 100f;
    public float maxMana = 100f;
    public float conversionCost = 20f;
    public float conversionResult = 40f;

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
        resources.ClearResources();
    }

    private void Update()
    {
    }


    private void LateUpdate()
    {
        CheckDeath();

        if (!IsDead)
        {
            RegenHealth();
        }
    }

    public void CheckDeath()
    {
        if(IsDead && !wasDeadLastFrame)
        {
            e_OnDeath.Invoke();
            Debug.LogWarning("Player Died");
        }
        wasDeadLastFrame = IsDead;
    }

    public void AddResource(int type)
    {
        resources.AddRecource((Resource)type);
    }

    public void RegenHealth()
    {
        health += healthRegen * Time.deltaTime;
        health = Mathf.Clamp(health,0,maxHealth);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        health = Mathf.Clamp(health, 0,maxHealth);
        Debug.Log("Player took " + dmg + " damage");
    }

    public void ConvertHealthToMana()
    {
        TakeDamage(conversionCost);
        GainMana(conversionResult);
    }

    private void GainMana(float gain)
    {
        mana += gain;
        mana = Mathf.Clamp(mana, 0, maxMana);
    }




    public void LogItems()
    {
        string log = "";
        foreach(var entry in items)
        {
            log += (entry.Key.itemName + ": " + entry.Value) + "\n";
        }
        Debug.Log(log);
    }
}
