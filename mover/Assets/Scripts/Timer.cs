using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float time = 30.0f;
    public bool setVisibility = true;
    void Update()
    {
        if (time > 0.0f)
            time -= Time.deltaTime;
        if (time <= 0)
            setVisibility = false;
    }

    public void SetTime(float t)
    {
        time = t;
    }

    public float GetTime()
    {
        return (time);
    }
}
