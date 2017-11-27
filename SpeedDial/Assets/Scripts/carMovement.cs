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
    private autobounce autobounce;
    //	bool grounded = false;
    public GameObject[] skidTrails;
    public bool being_boosted = false;


    private string power_string = "";
    private string turn_string = "";
    private string player_name = "";

    // Use this for initialization
    void Start () 
	{
        carRigidbody = GetComponent<Rigidbody>();
		default_speed = speed_modifier;
        autobounce = gameObject.GetComponent<autobounce>();

        if(gameObject.tag == "Player1")
        {
            turn_string = "P1Turn";
            power_string = "P1Acc";
            player_name = "Player1";
        }
        if (gameObject.tag == "Player2")
        {
            turn_string = "P2Turn";
            power_string = "P2Acc";
            player_name = "Player2";
        }
        if (gameObject.tag == "Player3")
        {
            turn_string = "P3Turn";
            power_string = "P3Acc";
            player_name = "Player3";
        }
        if (gameObject.tag == "Player4")
        {
            turn_string = "P4Turn";
            power_string = "P4Acc";
            player_name = "Player4";
        }
    }
	
	// Update is called once per frame
	void Update () 
	{
        MoveCar();
		AddBoost ();
    }


    void MoveCar()
    {
        if (autobounce.grounded)
        {
            powerInput = Input.GetAxis(power_string) * speed_modifier;
            for(int i = 0; i < skidTrails.Length; i++)
            {
                skidTrails[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < skidTrails.Length; i++)
            {
                skidTrails[i].SetActive(false);
            }
        }

        
        turnInput = Input.GetAxis(turn_string) * turn_modifier;

        carRigidbody.AddRelativeForce(0f, 0f, powerInput, ForceMode.Acceleration);
        carRigidbody.AddRelativeTorque(0f, turnInput, 0f);
    }


	public void AddBoost()
	{
		if (being_boosted) 
		{
			time += Time.deltaTime;

			if (time < 3) 
			{
				//print ("SPEED");
				speed_modifier = 30;
			} 
			else 
			{
				//print ("finished");
				speed_modifier = default_speed;
				time = 0;
				being_boosted = false;
			}

		}
	}
}
