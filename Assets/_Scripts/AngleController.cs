using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleController : MonoBehaviour {

    Vector3 direction;
    public Text directionText;

    // Use this for initialization
    void Start () {
        direction = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(transform.forward.x);
      //  Debug.Log("rdirect" + (360 - Vector3.Angle(direction, transform.forward)));



        if (transform.forward.x < 0)
        {
            directionText.text = Vector3.Angle(direction, transform.forward).ToString("F0");
        } else
        {
            directionText.text = (360 - Vector3.Angle(direction, transform.forward)).ToString("F0");
        }


    }
}
