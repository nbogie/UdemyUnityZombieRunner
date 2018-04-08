using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {

    private Camera eyesCam;
    private bool isZoomed;
    private float targetFOV;
    private float t;

    public float zoomStep = 0.5f;
    public float normalFOV = 60f;
    public float zoomedFOV = 20f;

    void Start () {
        eyesCam = GetComponent<Camera>();
        isZoomed = false;
        t = 0;
        targetFOV = normalFOV;
	}
	
	void Update () {
        if (Input.GetButtonDown("Zoom"))
        {
            ToggleZoom();
        }
        t += zoomStep * Time.deltaTime;
        if (t > 1f)
        {
            t = 1;
        }
        eyesCam.fieldOfView = Mathf.Lerp(eyesCam.fieldOfView, targetFOV, t);
	}

    void ToggleZoom()
    {
        t = 0;
        isZoomed = !isZoomed;
        targetFOV = isZoomed ? zoomedFOV: normalFOV;
    }
}
