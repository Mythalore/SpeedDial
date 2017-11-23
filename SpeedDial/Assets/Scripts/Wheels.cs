using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour {
    private Vector3 rotation_speed = new Vector3(0.0f,0.0f,2.0f);
    private GameObject[] wheels;

	// Use this for initialization
	void Start ()
    {
        wheels = GameObject.FindGameObjectsWithTag("Wheels");
	}
	
	// Update is called once per frame
	void Update () {
        //if acceleration down
        for(int i = 0; i < wheels.Length; i++)
        { 
            wheels[i].transform.Rotate(rotation_speed);
        }
	}
}
