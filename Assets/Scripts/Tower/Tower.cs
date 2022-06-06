using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform rangeCollider;
    public LineRenderer lr;

    public float shotsPerSecond = 1f;
    public float range = 10f;
    public float lineWidthMax = 1f;

    private float cooldownRemaining;
    List<Enemy> enemiesInRange = new List<Enemy>();

    
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.attachedRigidbody.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemiesInRange.Add(enemy);
        }
        RemoveNullFromEnemyList();
        Debug.Log("enemy in range");
    }
    private void OnTriggerExit(Collider other)
    {
        var enemy = other.attachedRigidbody.GetComponent<Enemy>();
        if (enemy != null && enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Remove(enemy);
        }
        RemoveNullFromEnemyList();
        Debug.Log("enemy left range");
    }
    public void RemoveNullFromEnemyList()
    {
        enemiesInRange = enemiesInRange.Where(enemy => enemy != null).ToList();
    }

    private void Update()
    {
        rangeCollider.localScale = Vector3.one * range;
        if (lr != null)
        {
            lr.SetPosition(0, rangeCollider.position);
        }
        // if ready
        if (cooldownRemaining <= 0f)
        {
            if(enemiesInRange.Count > 0)
            {
                // get target
                Enemy target = enemiesInRange[0];

                // shoot
                Shoot(target);
            }
        }
        // on cooldown
        else
        {
            cooldownRemaining -= Time.deltaTime;    
            cooldownRemaining = Mathf.Max(cooldownRemaining, 0f);
        }
        UpdateLineRenderer();
    }

    

    public void Shoot(Enemy enemy)
    {
        cooldownRemaining = 1 / shotsPerSecond;
        enemiesInRange.Remove(enemy);
        Destroy(enemy.gameObject);
        Debug.Log("Shot enemy");
        if(lr != null)
        {
            lr.SetPosition(1, enemy.transform.position);
        }
    }

    public void UpdateLineRenderer()
    {
        float width = lineWidthMax * (cooldownRemaining * shotsPerSecond);
        width = Mathf.Clamp01(width);
        lr.startWidth = width;
        lr.endWidth = width;

    }
}
