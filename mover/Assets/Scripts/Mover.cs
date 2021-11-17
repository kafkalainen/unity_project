using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 15.0f;

    Rigidbody player;
    Timer timer;
    float x = 0.0f;
    float z = 0.0f;
    // Update is called once per frame
    void Awake()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void MovePlayer()
    {
        x = Input.GetAxis("Horizontal") * speed;
        z = Input.GetAxis("Vertical") * speed;
        player.velocity = new Vector3(x, 0.0f, z);
    }

}
