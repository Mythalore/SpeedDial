using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour {

    public float speed_modifier = 20;
    public float turn_modifier = 10;
    private float powerInput;
    private float turnInput;
    public Rigidbody carRigidbody;
    public float threshold = 0;
    public float dist_to_ground = 0.5f;
    private LayerMask player = 8;
    // Use this for initialization
    void Start () {
        carRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        MoveCar();
    }


    void MoveCar()
    {
        Vector3 down = -Vector3.up;
        RaycastHit hit;
        bool grounded = false;

        if(Physics.Raycast(transform.position, down, out hit, player))
        {
            grounded = true;

        }
        powerInput = Input.GetAxis("P1Acc") * speed_modifier;
        print(powerInput);
        turnInput = Input.GetAxis("Horizontal") * turn_modifier;

        if (powerInput < threshold)
        {
            turnInput *= 0.1f;
        }

        if (grounded)
        {
            carRigidbody.AddRelativeForce(0f, 0f, powerInput);
        }

            carRigidbody.AddRelativeTorque(0f, turnInput, 0f);


    }
}
