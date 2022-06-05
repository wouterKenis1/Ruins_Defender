using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private CharacterController _input;
    private Rigidbody rb;
    [SerializeField]
    private float forceMulti;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private bool rotationalMovement;

    [SerializeField]
    private Camera camCam;

    [SerializeField]
    private LayerMask lookMask;

    /*
    [SerializeField]
    private float dashCooldownTotal = 2;
    private float dashCooldownCurrent;
    private float dashLimit;
    [SerializeField]
    private float dashLimitTotal = 2;
    */


    private void Awake()
    {
        _input = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        var movementVector = MoveTowardTarget(targetVector);
        if (rotationalMovement)
        {
            RotateTowardMovementVector(movementVector);
        }
        else
        {
            RotateTowardMouseVector();
        }

        ClickDetection();


        /*
        //THIS NEEDS TO COST MANA - ADD MANA COST  - ADD MANA COST - ADD MANA COST!!!
        if (Input.GetButton("Jump") && (dashCooldownCurrent <= 0 || dashLimit < dashLimitTotal))
        {
            dashCooldownCurrent = dashCooldownTotal;
            dashLimit += Time.deltaTime;

            rb.AddForce(transform.forward * forceMulti * Time.deltaTime);

        }
        else
        {
            rb.velocity = Vector3.zero;

            if (dashCooldownCurrent == 0)
            {
                dashLimit = 0;
            }
        }
        if (dashCooldownCurrent > 0)
        {
            dashCooldownCurrent -= Time.deltaTime;
            dashCooldownCurrent = Mathf.Max(dashCooldownCurrent, 0);
        }
        */


    }

    private void ClickDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camCam.ScreenPointToRay(_input.MousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
            {
                //if (hitInfo.collider != null)
                //{
                var whatAmIHitting = hitInfo.collider.gameObject;
                Debug.Log(whatAmIHitting.name);
                castSpell();

                var clickable = whatAmIHitting.GetComponentInChildren<ClickableObject>();
                 
                   if (clickable != null)
                    {
                        clickable.Click();
                    }
                //}
            }
        }
    }

    void castSpell()
    {
        Weapon.Instance.castSpell();
    }

    private void RotateTowardMouseVector()
    {
        Ray ray = camCam.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 300f, lookMask))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);

            //if (hitInfo.collider != null)
            //{
            //    var whatAmIHitting = hitInfo.collider.gameObject;
            //  Debug.Log(whatAmIHitting.name);
            //}
        }
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if(movementVector.magnitude == 0)
        {
            return;
        }
        
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, camCam.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }
}
