using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    Rigidbody rigidBody;

    [SerializeField] float rotationAngleSpeed = 15.0f;
    Vector3 angleVelocity;

    void Awake()
    {
       rigidBody = GetComponent<Rigidbody>();
       angleVelocity = new Vector3(0.0f, rotationAngleSpeed, 0.0f);
    }
    void Update()
    {
        Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.fixedDeltaTime);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }
}
