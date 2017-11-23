using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour {

    public float speed = 90f;
    public float turnSpeed = 5f;

    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidbody;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        //carRigidbody.AddForce(appliedForce, ForceMode.Acceleration);
        // carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
        //carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
    }


    void MoveCar()
    {
        //if(grounded)
        //apply drag
        //else
        //thrust *= 0.1
        //turnvalue *= 0.1
    }
}
