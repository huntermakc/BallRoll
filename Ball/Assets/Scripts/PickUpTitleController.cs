﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTitleController : MonoBehaviour {

		
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
        
    }
}