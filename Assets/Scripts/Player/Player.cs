using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    static Player instance;
    public static Player Instance
    {
        get
        {
            if(instance == null)
                instance = FindObjectOfType<Player>();
            return instance;
        }
    }

    public StringIntDict items = new StringIntDict();


    public float health = 100f;
    public float maxHealth = 100f;
    public float healthRegen = 1f;

    public float mana = 100f;
    public float maxMana = 100f;
    public float conversionCost = 20f;
    public float conversionResult = 40f;



    public bool wasDeadLastFrame;


    public UnityEvent e_OnDeath = new UnityEvent();
    public UnityEvent e_itemsChanged = new UnityEvent();

    public bool IsDead
    {
        get
        {
            return health <= 0.0f;
        }
    }

    public StringIntDict Items
    {
        get { return items; }
        set { items = value; e_itemsChanged.Invoke(); }
    }

    void Awake()
    {
        health = maxHealth;
        wasDeadLastFrame = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player was hit by: " + other.name);

        //if (other.tag == "Enemy")was needed to prevent water from giving an error on collision
        if (other.tag == "Enemy")
        {
            var enemy = other.attachedRigidbody.GetComponent<Enemy>();
            if (enemy != null)
            {
                TakeDamage(enemy.dmg);
            }

            Destroy(other.attachedRigidbody.gameObject);
        }

        
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
        if (IsDead && !wasDeadLastFrame)
        {
            e_OnDeath.Invoke();
            Debug.LogWarning("Player Died");
            
        }
        wasDeadLastFrame = IsDead;

        if (wasDeadLastFrame)
        {
            //This is for the animator
            GetComponent<Animator>().SetTrigger("death");
        }
    }
    public void RegenHealth()
    {
        health += healthRegen * Time.deltaTime;
        health = Mathf.Clamp(health, 0, maxHealth);
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);
        Debug.Log("Player took " + dmg + " damage");
    }
    public void RemoveMana(float amount)
    {
        mana -= amount;
        mana = Mathf.Clamp(mana, 0, maxMana);
    }
    public void AddMana(float amount)
    {
        mana += amount;
        mana = Mathf.Clamp(mana, 0, maxMana);
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
    public void AddItem(string itemName)
    {
        AddItem(itemName, 1);
    }
    public void AddItem(string itemName, int amount)
    {
        if (!Items.ContainsKey(itemName))
        {
            Items.Add(itemName, 0);
        }
        Items[itemName] += amount;
        e_itemsChanged.Invoke();
    }
    public void RemoveItem(string itemName, int amount)
    {
        if(itemName == "HEALTH")
        {
            TakeDamage(amount);
        }
        else
        {
            if (!Items.ContainsKey(itemName))
            {
                Items.Add(itemName, 0);
            }
            Items[itemName] -= amount;
            if (Items[itemName] == 0)
            {
                Items.Remove(itemName);
            }
            e_itemsChanged.Invoke();
        }
    }
    public void RemoveItems(StringIntDict cost)
    {
        foreach(var entry in cost)
        {
            RemoveItem(entry.Key, entry.Value);
        }
    }
    public void LogItems()
    {
        string log = "";
        foreach(var entry in Items)
        {
            log += (entry.Key + ": " + entry.Value) + "\n";
        }
        Debug.Log(log);
    }

    public bool HasResources(StringIntDict cost)
    {
        foreach(var entry in cost)
        {
            if(entry.Key == "HEALTH")
            {
                continue;
            }
            if(!items.ContainsKey(entry.Key) || items[entry.Key] < entry.Value)
            {
                return false;
            }        
        }
        return true;
    }
}
