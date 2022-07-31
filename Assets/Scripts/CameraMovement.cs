using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //private float distanceToCamera = 25f;

    private float speed = 3f;

    public Transform targetObject;

    void Start()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.y + distanceToCamera);
    }

    void Update()
    {
        MoveCamera();
    }

    //Move camera smooth after object
    private void MoveCamera()
    {
        Vector3 position = targetObject.position;

        position.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
