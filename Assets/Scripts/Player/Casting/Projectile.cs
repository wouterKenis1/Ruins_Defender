using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 firingPoint;

    [SerializeField]
    private float projectileSpeed;

    private float projectileLife;
    private float projectileLifeExpectancy;

    //private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        firingPoint = transform.position;
        projectileLife = Time.time;
        projectileLifeExpectancy = Time.time + 5;
        
    }

    private void OnEnable()
    {
        //direction = CalculateTargetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        moveProjectile();

        if (projectileLife >= projectileLifeExpectancy)
        {
            Destroy(this.gameObject);
        }
        else
        {
            projectileLife += 1 * Time.deltaTime;
        }
    }

    Vector3 CalculateTargetDirection()
    {
        Vector3 targetDirection = new Vector3();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            targetDirection = hitInfo.point - transform.position;
        }
        
        return targetDirection;
    }

    void moveProjectile()
    {
        Vector3 direction = CalculateTargetDirection();
        transform.Translate(direction.normalized * projectileSpeed * Time.deltaTime);
    }


}
