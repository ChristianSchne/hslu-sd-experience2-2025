﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Q)) {
			ScreenCapture.CaptureScreenshot((System.DateTime.Now.ToString("yy MM dd HH.mm.ss " + Screen.width + "x" + Screen.height) + ".png"), 3);
		}
        if(Input.GetButtonDown("Fire2")){ //Oculus Quest Button B
            ScreenCapture.CaptureScreenshot((System.DateTime.Now.ToString("yy MM dd HH.mm.ss " + Screen.width + "x" + Screen.height) + ".png"), 3);

        }
    }
}
