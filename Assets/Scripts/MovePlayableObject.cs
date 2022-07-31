using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayableObject : MonoBehaviour
{
    [SerializeField] private int pushForce;
    private Rigidbody rigidb;
    private SpringJoint sJoint;

    [Space(10)]

    [SerializeField] private int torque;
    private bool objectJoined = true;

    private void Awake()
    {
        rigidb = GetComponent<Rigidbody>();
        sJoint = GetComponent<SpringJoint>();
    }

    private void FixedUpdate()
    {
        PushHorizontal();
        PlayableObjectForceRotation();
    }

    //Push oblect left and right
    private void PushHorizontal()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rigidb.AddForce(new Vector3(-pushForce, 0f, 0f) * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rigidb.AddForce(new Vector3(pushForce, 0f, 0f) * Time.deltaTime);
        }
    }

    //Relize object with a torque
    private void PlayableObjectForceRotation()
    {
        if (Input.GetKeyDown(KeyCode.Space) && objectJoined)
        {
            Destroy(sJoint);
            rigidb.AddTorque(transform.forward * torque);
            objectJoined = false;
        }
    }
}
