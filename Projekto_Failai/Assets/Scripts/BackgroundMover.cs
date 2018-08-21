﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundMover : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(-Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
