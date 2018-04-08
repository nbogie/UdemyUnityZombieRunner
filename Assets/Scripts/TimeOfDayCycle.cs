using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDayCycle : MonoBehaviour {
    public float secondsInOneDay = 60f;

    void Start () {
		
	}
	
	void Update () {
        float rotateSpeed = 360f / secondsInOneDay * Time.deltaTime;
        transform.Rotate(Vector3.right * rotateSpeed);
		
	}
}
