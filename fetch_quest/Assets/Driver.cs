using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
	//TurnSpeed is 90 degrees / second
	private float	turnSpeed = 90.0f;
	private float	velocity = 0.0f;
	private float	thrusterPower = 0.05f;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	// CSharp cannot evaluate floats as booleans.
	// Multiplying Input.GetAxis with turnSpeed we are normalizing the turning speed.
	// transform.Rotate is in degrees.
	// transform and translate are relative to the object space.
	void Update()
	{
		float	time = Time.deltaTime;
		float	steerAmount = Input.GetAxis("Horizontal") * turnSpeed * time;
		float	acceleration = Input.GetAxis("Vertical") * thrusterPower * time;
		velocity += acceleration;
		transform.Rotate(0.0f, 0.0f, -steerAmount);
		transform.Translate(0.0f, velocity, 0.0f);
	}
}
