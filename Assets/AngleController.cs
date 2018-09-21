using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleController : MonoBehaviour {

    Vector3 direction;

    // Use this for initialization
    void Start () {
        direction = transform.forward;
    
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Vector3.Angle(direction, transform.forward));
	}
}
