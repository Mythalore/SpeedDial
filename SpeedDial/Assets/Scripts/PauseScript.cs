using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
    bool isPaused;
    bool isGraphicOn = true;
    int framesPassed = 120;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonDown("Pause"))
        {
            if(!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
                GetComponentInChildren<Image>().enabled = true;
                //show image
            }
            else
            {
                Time.timeScale = 1;
                GetComponentInChildren<Image>().enabled = false;

                isGraphicOn = true;
                //disable image
                isPaused = false;
            }
            

        }

       




	}
}
