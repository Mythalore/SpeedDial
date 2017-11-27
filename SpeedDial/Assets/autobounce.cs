using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autobounce : MonoBehaviour {

    //public LayerMask player;
    public bool grounded;
    public string direction_grounded = "";
    public float ray_distance = 1.5f;
    private bool return_value = true;

    private Vector3 start_pos;
    private string right_bumper = "";

    // Use this for initialization
    void Start () {
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
            StartCoroutine(flipTimer(transform.position));
        }
        if (Input.GetButtonDown(right_bumper))
        {
            StartCoroutine(flipTimer(start_pos));
        }
       
	}

    void flipCar(Vector3 _desiredPos)
    {
        Vector3 desired_rotation = transform.rotation.eulerAngles;
        
        desired_rotation.z = 0;
        gameObject.transform.SetPositionAndRotation((_desiredPos + new Vector3(0, 1, 0)), Quaternion.Euler(desired_rotation));      

    }

    IEnumerator flipTimer(Vector3 _pos )
    {
        yield return new WaitForSecondsRealtime(3.0f);
        if (RaycastLeft() || RaycastRight() || RaycastUp())
        {
            flipCar(_pos);
        }
    }


    bool RaycastDown()
    {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, -transform.up);
        if (Physics.Raycast(ray, out hit, ray_distance/*, player*/))
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
}
