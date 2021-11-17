using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    [SerializeField] AudioClip bashSFX;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            if (gameObject.tag == "spinner")
            {
                GetComponentInChildren<MeshRenderer>().material.color = new Color(1.0f, 0.0f, 0.0f);
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.0f, 0.0f);
                gameObject.tag = "hit";
                other.gameObject.GetComponent<AudioSource>().PlayOneShot(bashSFX);
            }
        }
    }
}
