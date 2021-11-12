using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem dustTrail;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
            dustTrail.Stop();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
            dustTrail.Stop();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            dustTrail.Play();
        }
    }
}
