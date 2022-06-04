using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    //public Transform target;
    //public Vector3 offset;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Transform target;

    private Vector3 previousPosition;

    // Update is called once per frame
    void Update()
    {
        
        //transform.position = target.position + offset;

        
        if (Input.GetMouseButtonDown(2))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = target.position;

            //cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180); //without this code the Y access is locked
            cam.transform.Rotate(new Vector3(0, 1, 0), direction.x * 180, Space.World);
            cam.transform.Translate(new Vector3(0, 0, -10));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);

        }
        else
        {
            transform.position = target.position;
            transform.Translate(new Vector3(0, 0, -10)); // + cam.transform.Translate(new Vector3(0, 0, -10));
        }

    }
}
