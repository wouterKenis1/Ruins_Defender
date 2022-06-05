using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    Transform castPoint;

    [SerializeField]
    GameObject projectilePrefab;

    public float castSpeed = 2;
    public float castCooldown = 0;
    public float manaCost = 5;

    public static Weapon Instance;

    private void Awake()
    {
        Instance = GetComponent<Weapon>();
    }

    void Update()
    {
        castCooldown = Mathf.Max(castCooldown - Time.deltaTime,0);
    }

    public void castSpell()
    {
        if(Player.Instance.mana < manaCost)
        {
            return;
        }
        if (castCooldown <= 0)
        {
            Player.Instance.RemoveMana(manaCost);
            castCooldown = 1f / castSpeed;
            Instantiate(projectilePrefab, castPoint.position, castPoint.rotation);
        }
    }

    
}
