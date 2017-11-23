using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour {

    public float speed_modifier = 20;
    public float turn_modifier = 10;
	public float threshold = 0;
	public float dist_to_ground = 0.5f;
    
	private float powerInput;
    private float turnInput;
	private Rigidbody carRigidbody;
    private LayerMask player = 8;
	private float time = 0.0f;
	private float default_speed = 0;
	bool grounded = false;

	public bool being_boosted = false;

    // Use this for initialization
    void Start () 
	{
        carRigidbody = GetComponentInChildren<Rigidbody>();
		default_speed = speed_modifier;
    }
	
	// Update is called once per frame
	void Update () 
	{
        MoveCar();
		AddBoost ();
    }


    void MoveCar()
    {
        
        RaycastHit hit;

		//if (Physics.Raycast (transform.position, -Vector3.up, out hit, dist_to_ground, player)) 
		//{
		//	grounded = true;
		//} 
		//else 
		//{
		//	grounded = false;
		//}

        powerInput = Input.GetAxis("P1Acc") * speed_modifier;
		//powerInput = Input.GetAxis ("Vertical") * speed_modifier;
        turnInput = Input.GetAxis("Horizontal") * turn_modifier;

        if (powerInput < threshold)
        {
            turnInput *= 0.1f;
        }

		if (!grounded) 
		{
			powerInput *= 0.1f;
			turnInput *= 0.1f;
		}
        

        carRigidbody.AddRelativeForce(0f, 0f, powerInput);
        carRigidbody.AddRelativeTorque(0f, turnInput, 0f);

    }

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.CompareTag("Ground"))
		{
			grounded = true;
			print(":)");
		}
	}

	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.CompareTag("Ground"))
		{
			grounded = false;
			print(":(");

		}
	}
		
	public void AddBoost()
	{
		if (being_boosted) 
		{
			time += Time.deltaTime;

			if (time < 3) 
			{
				print ("SPEEEEEEEEED");
				speed_modifier = 30;
			} 
			else 
			{
				print ("finished");
				speed_modifier = default_speed;
				time = 0;
				being_boosted = false;
			}

		}
	}
}
