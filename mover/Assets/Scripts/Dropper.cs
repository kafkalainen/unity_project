using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer mesh;
    Rigidbody rb;
    [SerializeField] float timeToWait;

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void Update()
    {
        if (Time.time > timeToWait)
        {
            mesh.enabled = true;
            rb.useGravity = true;
        }
    }
}
