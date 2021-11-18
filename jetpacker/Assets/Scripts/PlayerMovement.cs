using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody rb;

	AudioSource[] audioSources;
	[SerializeField] AudioClip thrusterSFX;
	[SerializeField] float thrusterForce = 15.0f;
	[SerializeField] float rotationSpeed = 30.0f;
	[SerializeField] ParticleSystem mainThruster;
	[SerializeField] ParticleSystem leftThruster;
	[SerializeField] ParticleSystem rightThruster;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		audioSources = GetComponents<AudioSource>();
	}

	void Update()
	{
		ProcessThrust();
		ProcessTurn();
		playThrustingAudio();
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
			StartThrusting();
		}
		else
		{
			mainThruster.Stop();
		}
	}

	void StartThrusting()
	{
		if (!mainThruster.isEmitting)
		{
			mainThruster.Play();
		}
		rb.AddRelativeForce(Vector3.up * thrusterForce * Time.fixedDeltaTime);
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
		else
		{
			DisableSideThrusters();
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
		ActivateThrusters(rotationThisFrame);
	}

	private void DisableSideThrusters()
	{
		leftThruster.Stop();
		rightThruster.Stop();
	}

	void playThrustingAudio()
	{
		if (mainThruster.isEmitting
			|| leftThruster.isEmitting
			|| rightThruster.isEmitting)
		{
			if (!audioSources[0].isPlaying)
			{
				audioSources[0].PlayOneShot(thrusterSFX);
			}
		}
		else
		{
			audioSources[0].Stop();
		}
	}

	void ActivateThrusters(float rotationThisFrame)
	{
		if (rotationThisFrame > 0)
		{
			if (!leftThruster.isEmitting)
				leftThruster.Play();
		}
		else
		{
			if (!rightThruster.isEmitting)
				rightThruster.Play();
		}
	}
}
