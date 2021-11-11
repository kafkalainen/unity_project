using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
	private	bool				hasPackage = false;
	[SerializeField] float		pickupDelay = 0.5f;
	[SerializeField] Color32	hasPackageColour = new Color32(1, 1, 1, 1);
	[SerializeField] Color32	noPackageColour = new Color32(1, 1, 1, 1);
	SpriteRenderer				spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void	OnCollisionEnter2D()
	{
		Debug.Log("Hit a rigid body");
	}
	void	OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "SatellitePickup" && !hasPackage)
		{
			hasPackage = true;
			spriteRenderer.color = hasPackageColour;
			Destroy(other.gameObject, pickupDelay);
			Debug.Log("Picked it up!");
		}
		else if (other.tag == "MissionControl" && hasPackage)
		{
			hasPackage = false;
			spriteRenderer.color = noPackageColour;
			Debug.Log("Package received. Well done. Oxygen reserves are in");
		}
		else if (other.tag == "MissionControl" && !hasPackage)
		{
			Debug.Log("Where's that package? Stop wasting the fuel, we need that oxygen.");
		}
	}
}
