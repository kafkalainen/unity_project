using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrusterForce = 15.0f;
    [SerializeField] float rotationSpeed = 30.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /*
    ** It is possible also to use up right forward vectors.
    ** rb.AddForce(this.transform.up * thrusterForce);
    ** or use Vector3.up
    ** rb.AddRelativeForce(Vector3.up);
    */
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrusterForce * Time.fixedDeltaTime);
        }
    }
	Quaternion ApplyRotation(float rotationThisFrame)
	{
		return (Quaternion.Euler(
						Vector3.forward * rotationThisFrame * Time.fixedDeltaTime));
	}
    void ProcessTurn()
    {
        if (Input.GetKey(KeyCode.A))
		{
			Quaternion deltaRotation = ApplyRotation(rotationSpeed);
			rb.MoveRotation(rb.rotation * deltaRotation);
		}
		else if (Input.GetKey(KeyCode.D))
        {
            Quaternion deltaRotation = ApplyRotation(-rotationSpeed);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }


	void Update()
    {
        ProcessThrust();
        ProcessTurn();
    }
}
