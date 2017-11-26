using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autobounce : MonoBehaviour {

    public LayerMask player;
    public bool grounded;
    public string direction_grounded = "";
    public float ray_distance = 1.5f;


    private string right_bumper = "";

    // Use this for initialization
    void Start () {
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
        {
            grounded = false;
            StartCoroutine(flipTimer());
        }

        if(Input.GetButtonDown(right_bumper))
        {
            StartCoroutine(flipTimer());
        }
       
	}

    void flipCar()
    {
        Vector3 desired_rotation = transform.rotation.eulerAngles;
        desired_rotation.z = 0;
        gameObject.transform.SetPositionAndRotation((transform.position + new Vector3(0, 1, 0)), Quaternion.Euler(desired_rotation));      

    }

    IEnumerator flipTimer( )
    {
        yield return new WaitForSecondsRealtime(2.0f);
        if(!RaycastDown())
        {
            flipCar();
        }
        else
        {
            print("debug flip");
           // flipCar();
        }
    }

    bool RaycastDown()
    {
        RaycastHit hit;
        bool return_value = true;
        Ray ray = new Ray(transform.position, -Vector3.up);
        if (Physics.Raycast(ray, out hit, ray_distance, player))
        {
            Debug.DrawRay(transform.position, -Vector3.up, Color.red);
            return_value = true;
        }
        else
        {
            Debug.DrawRay(transform.position, -Vector3.up, Color.blue);
            return_value = false;
        }
        return return_value;
    }
    bool RaycastUp()
    {
        RaycastHit hit;
        bool return_value = true;
        Ray ray = new Ray(transform.position, Vector3.up);
        if (Physics.Raycast(ray, out hit, ray_distance, player))
        {
            Debug.DrawRay(transform.position, Vector3.up, Color.red);
            //if (hit.transform.CompareTag("Ground"))
            //{
                return_value = true;
            //}
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.up, Color.blue);
            return_value = false;
        }
        return return_value;
    }
    bool RaycastLeft()
    {
        RaycastHit hit;
        bool return_value = true;
        Ray ray = new Ray(transform.position, Vector3.up);
        if (Physics.Raycast(ray, out hit, ray_distance, player))
        {
            Debug.DrawRay(transform.position, Vector3.up, Color.red);
            return_value = true;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.up, Color.blue);
            return_value = false;
        }
        return return_value;
    }
    bool RaycastRight()
    {
        RaycastHit hit;
        bool return_value = true;
        Ray ray = new Ray(transform.position, Vector3.up);
        if (Physics.Raycast(ray, out hit, ray_distance, player))
        {
            Debug.DrawRay(transform.position, Vector3.up, Color.red);
            return_value = true;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.up, Color.blue);
            return_value = false;
        }
        return return_value;
    }
}
