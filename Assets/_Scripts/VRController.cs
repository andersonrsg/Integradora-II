using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRController : MonoBehaviour {

	public bool isNext = false;
	public bool isDestroyed = false;

	Rigidbody rigidbody;
	// Collider collider2;

        //Fetch the Renderer from the GameObject
    Renderer rend; 

    private float hoverForce = 11f;

	private float startTime;
    private float elapsedTime;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rigidbody = GetComponent<Rigidbody>(); 
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isNext) {
			//Set the main Color of the Material to green
	        rend.material.shader = Shader.Find("_Color");
    	    rend.material.SetColor("_Color", Color.red);
    	    //Find the Specular shader and change its Color to red
        	rend.material.shader = Shader.Find("Specular");
        	rend.material.SetColor("_SpecColor", Color.red);
		} else {
			rend.material.shader = Shader.Find("_Color");
    	    rend.material.SetColor("_Color", Color.green);

        	rend.material.shader = Shader.Find("Specular");
        	rend.material.SetColor("_SpecColor", Color.green);
		}
	}

	void FixedUpdate() {
		// elapsedTime = Time.time - startTime;

		// if (elapsedTime < 2) {
		// 	rigidbody.AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
		// } else {//if (elapsedTime > 2.5) {
		// 	// elapsedTime = 0;
		// 	// rigidbody.AddForce(Vector3.down * hoverForce, ForceMode.Acceleration);
		// }// else {
			// rigidbody.AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
	//	}
	}

	void OnTriggerEnter(Collider other) {
		if (isNext) {
			if(other.tag == "Car") {
				isDestroyed = true;
				Destroy(this.gameObject);
			}
		}
	}

	void OnTriggerStay(Collider other) {
		Debug.Log("spherererere");
		if (other.tag == "BoxForSphere") {
			Debug.Log("spherererere");
			// rigidbody.AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
		}
	}
}
