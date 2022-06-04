using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float dmg = 1.0f;
    public float speed;
    public Transform target;

    public float heightOffset = 1.5f;
    public float heightAmplitude = 0.5f;
    public float heightFrequency = 1.5f;


    private void Update()
    {
        if(target == null)
        {
            return;
        }
        // calculate position moving towards target
        Vector3 newPos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // bounce in air
        newPos.y = heightAmplitude * Mathf.Sin(Time.time * heightFrequency) + heightOffset;

        // set position
        transform.position = newPos;
    }


}
