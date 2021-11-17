using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody rb;

	AudioSource audioSource;
	[SerializeField] AudioClip thrusterSFX;
	[SerializeField] float thrusterForce = 15.0f;
	[SerializeField] float rotationSpeed = 30.0f;
	[SerializeField] ParticleSystem thrusterJet;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
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
			if (!audioSource.isPlaying)
			{
				audioSource.PlayOneShot(thrusterSFX);
			}
			if (!thrusterJet.isEmitting)
			{
				thrusterJet.Play();
			}
			rb.AddRelativeForce(Vector3.up * thrusterForce * Time.fixedDeltaTime);
		}
		else
		{
			thrusterJet.Stop();
			audioSource.Stop();
		}
	}

	/*
	**	Tried first to add Rotation as vectors on rigidbody,
	**	but switched this to force rotation using transform.
	**	Earlier version used Quaternion.
	**	Quaternion deltaRotation = Quaternion.Euler(
						Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
	**	rb.MoveRotation(rb.rotation * deltaRotation);
	** rb.freezeRotation = true;
	**	transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
	**	rb.freezeRotation = false;
	*/
	void ApplyRotation(float rotationThisFrame)
	{
		Quaternion deltaRotation = Quaternion.Euler(
						this.transform.forward * rotationThisFrame * Time.fixedDeltaTime);
		rb.MoveRotation(rb.rotation * deltaRotation);
	}
	void ProcessTurn()
	{
		if (Input.GetKey(KeyCode.A))
		{
			ApplyRotation(rotationSpeed);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			ApplyRotation(-rotationSpeed);
		}
	}


	void Update()
	{
		ProcessThrust();
		ProcessTurn();
	}
}
