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

    public static Weapon Instance;

    private void Awake()
    {
        Instance = GetComponent<Weapon>();
    }

    void Update()
    {
        castCooldown = Mathf.Clamp01(castCooldown - Time.deltaTime);
    }

    public void castSpell()
    {
        if (castCooldown <= 0)
        {
            castCooldown = 1 / castSpeed;
            Instantiate(projectilePrefab, castPoint.position, castPoint.rotation);
        }
    }

    
}
