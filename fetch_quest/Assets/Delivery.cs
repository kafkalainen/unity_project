using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
	void	OnCollisionEnter2D()
	{
		Debug.Log("Hit a rigid body");
	}
	void	OnTriggerEnter2D()
	{
		Debug.Log("Picked it up!");
	}
}
