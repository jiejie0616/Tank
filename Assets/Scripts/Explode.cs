﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1.6f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
