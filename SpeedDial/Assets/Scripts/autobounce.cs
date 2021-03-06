﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autobounce : MonoBehaviour {

    //public LayerMask player;
    public bool grounded = false;
    public float ray_distance = 1.5f;
    private bool return_value = true;

    public Vector3 start_pos;
    private string right_bumper = "";

    private float max_distance;
    private string aButton = "";
    // Use this for initialization
    void Start () {
        max_distance = gameObject.GetComponent<Collider>().bounds.size.y/2 + 0.3f;
        start_pos = transform.position;
        if (gameObject.tag == "Player1")
        {
            right_bumper = "P1RB";
        }
        if (gameObject.tag == "Player2")
        {
            right_bumper = "P2RB";
        }
        if (gameObject.tag == "Player3")
        {
            right_bumper = "P3RB";
        }
        if (gameObject.tag == "Player4")
        {
            right_bumper = "P4RB";
        }
        if (gameObject.tag == "Player1")
        {
            aButton = "P1 A";
        }
        if (gameObject.tag == "Player2")
        {
            aButton = "P2 A";
        }
        if (gameObject.tag == "Player3")
        {
            aButton = "P3 A";
        }
        if (gameObject.tag == "Player4")
        {
            aButton = "P4 A";
        }
    }

    // Update is called once per frame
    void Update () {
		if(RaycastDown())
        {
            grounded = true;
        }
        else
         grounded = false;            
        
        if(RaycastLeft() || RaycastRight() || RaycastUp())
        {
            StartCoroutine(flipTimer(Vector3.zero));
        }
        if (Input.GetButtonDown(right_bumper))
        {
            print("debug flip");
            StartCoroutine(flipTimer(start_pos));
        }
       
	}

    public void flipCar(Vector3 _desiredPos)
    {
        Vector3 desired_rotation = transform.rotation.eulerAngles;
        
        desired_rotation.z = 0;
        desired_rotation.x = 0;
        gameObject.transform.SetPositionAndRotation((_desiredPos + new Vector3(0, 1, 0)), Quaternion.Euler(desired_rotation));      

    }

    IEnumerator flipTimer(Vector3 _pos )
    {
        yield return new WaitForSecondsRealtime(1.0f);
        if(_pos != Vector3.zero)
        {
            flipCar(_pos);

        }
        else
        {
            if (RaycastLeft() || RaycastRight() || RaycastUp() || RaycastBackwards() || RaycastForward())
            {
                flipCar(transform.position);
            }
        }
    }


    bool RaycastDown()
    {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, -transform.up);
        if (Physics.Raycast(ray, out hit, max_distance/*, player*/))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Debug.DrawRay(gameObject.transform.position, -transform.up, Color.red);

                return_value = true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up, Color.blue);
            return_value = false;
        }
        return return_value;
    }

    bool RaycastUp()
    {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, transform.up);
        if (Physics.Raycast(ray, out hit, ray_distance/*, player*/))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                print("Roof hitting ground");
                Debug.DrawRay(gameObject.transform.position, transform.up, Color.red);

                return_value = true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up, Color.blue);
            return_value = false;
        }
        return return_value;

    }

    bool RaycastLeft()
    {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, -transform.right);
        if (Physics.Raycast(ray, out hit, ray_distance/*, player*/))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                print("Left hitting ground");
                Debug.DrawRay(gameObject.transform.position, -transform.right, Color.red);

                return_value = true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up, Color.blue);
            return_value = false;
        }
        return return_value;

    }

    bool RaycastRight()
    {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, -transform.right);
        if (Physics.Raycast(ray, out hit, ray_distance/*, player*/))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                print("Right hitting ground");
                Debug.DrawRay(gameObject.transform.position, transform.right, Color.red);

                return_value = true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up, Color.blue);
            return_value = false;
        }
        return return_value;
 
    }

    bool RaycastForward()
    {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, ray_distance/*, player*/))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                print("Front hitting ground");
                Debug.DrawRay(gameObject.transform.position, transform.right, Color.red);

                return_value = true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up, Color.blue);
            return_value = false;
        }
        return return_value;

    }

    bool RaycastBackwards()
    {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, -transform.forward);
        if (Physics.Raycast(ray, out hit, ray_distance/*, player*/))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                print("Rear hitting ground");
                Debug.DrawRay(gameObject.transform.position, transform.right, Color.red);

                return_value = true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up, Color.blue);
            return_value = false;
        }
        return return_value;

    }
}
