using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float dmg = 1.0f;
    public float speed;
    public Transform target;

    public float heightOffset = 1.5f;
    public float heightAmplitude = 0.5f;
    public float heightFrequency = 1.5f;

    NavMeshAgent agent;
    NavMeshPath path ;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        path = agent.path;
    }
    private void Update()
    {
        agent.baseOffset = heightAmplitude * Mathf.Sin(Time.time * heightFrequency) + heightOffset;
        
        if (target == null)
        {
            return;
        }
        UpdatePath();
        agent.speed = speed;
    }
    public void UpdatePath()
    {
        if(agent.CalculatePath(target.position,path))
        {
            agent.SetPath(path);
        }
    }
}
