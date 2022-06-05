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
    private float lastTimeCast = 0;

    public static Weapon Instance;

    private void Awake()
    {
        Instance = GetComponent<Weapon>();
    }

    void Update()
    {
       
    }

    public void castSpell()
    {
        if (lastTimeCast + castSpeed <= Time.time)
        {
            lastTimeCast = Time.time;
            Instantiate(projectilePrefab, castPoint.position, castPoint.rotation);
        }
    }

    
}
