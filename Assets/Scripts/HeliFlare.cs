using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliFlare : MonoBehaviour {
    private Rigidbody rb;

    public float flareSpeed;
    public float parachuteDrag;
    public float initialDrag;


    private bool openedParachute;

	void Start () {
        rb = GetComponent<Rigidbody>();
    
        Launch();
	}

	void Update () {
        
        if (rb.velocity.y < -3f)
        {
            if (!openedParachute)
            {
                OpenParachute();
            }
        }
	}

    private void OpenParachute()
    {
        openedParachute = true;
        rb.drag = parachuteDrag;
    }
    private void Launch()
    {
        Vector3 vel = new Vector3(Random.Range(-0.2f, 0.2f), 1, Random.Range(-0.2f, 0.2f)).normalized * flareSpeed;
        rb.velocity = vel;
        rb.drag = initialDrag;
        openedParachute = false;
        Destroy(gameObject, 30);


    }
}
