using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    TimeCycleController cycleController;
    public GameObject prefab;
    public Vector3 spawnOffset;
    public Transform target;
    public int spawnAmount;

    private void Awake()
    {
        cycleController = FindObjectOfType<TimeCycleController>();
        cycleController.e_OnNightStart.AddListener(Spawn);
    }

    [ContextMenu("Spawn")]
    private void Spawn()
    {
        for(int i = 0; i < spawnAmount; i++)
        {
            GameObject go = Instantiate(prefab, transform);
            go.GetComponent<Enemy>().target = target;
            go.transform.position = transform.position + spawnOffset;
        }
    }

}
