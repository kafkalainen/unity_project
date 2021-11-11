using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] GameObject objectToFollow;
    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + new Vector3(0.0f, 0.0f, -10.0f);
    }
}
