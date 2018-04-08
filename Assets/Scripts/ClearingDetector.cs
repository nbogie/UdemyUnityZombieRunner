using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearingDetector : MonoBehaviour
{
    public float timeOfLastCollision;
    private int collisions;

    void Start()
    {
        timeOfLastCollision = Time.time;
        collisions = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        collisions--;
        if (collisions <= 0)
        {
            timeOfLastCollision = Time.time;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        collisions++;
    }

    public void Update()
    {
    }

    public float ClearDuration()
    {
        return (collisions == 0) ? (Time.time - timeOfLastCollision) : 0f;
    }
}
