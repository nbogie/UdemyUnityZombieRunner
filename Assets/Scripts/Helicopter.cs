using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private GameObject player;
    public GameObject landingArea;
    private Rigidbody rb;
    public float speed;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TeleportToPlayer();
        }
        if (landingArea)
        {
            if (Vector3.Distance(landingArea.transform.position, transform.position) < 12f)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
    void TeleportToPlayer()
    {
        transform.position = Vector3.up * 6f + player.transform.position;
    }

    internal void SetLandingArea(GameObject area)
    {
        this.landingArea = area;

        Vector3 targetPos = landingArea.transform.position;
        Vector3 diff = targetPos - transform.position;
        Vector3 vel = diff.normalized * speed;
        rb.velocity = vel;
        transform.LookAt(targetPos);
    }
}
