﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour {

	public VRController[] points;
	public int currentPoint = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < points.Length ; i++) {
			points[i].isNext = false;
		}
		points[0].isNext = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (currentPoint < points.Length)
        {
            if (points[currentPoint].isDestroyed)
            {
                currentPoint++;
                points[currentPoint].isNext = true;
            }
        }


    }
}
