using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTargeting : MonoBehaviour {

    public float view_radius = 5.0f;
    [Range(0, 360)]
    public float view_angle;

    public LayerMask acceptMask;

    public Collider[] playersInRadius;
    public List<Collider> seenPlayersInRadius;

    public Vector3 closestPlayer = Vector3.zero;
    private LayerMask me = 10;
	// Use this for initialization
	void Start () {
        seenPlayersInRadius = new List<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForPlayers();
	}
    void CheckForPlayers()
    {
        seenPlayersInRadius.Clear();
        playersInRadius = Physics.OverlapSphere(transform.position, view_radius, acceptMask);

        foreach (Collider player in playersInRadius)
        {
            if (player.tag != gameObject.transform.parent.tag)
            {
                //print("First step");
                Transform target = player.transform;

                Vector3 ray_direction = (player.transform.position - transform.position);

                if (Vector3.Angle(transform.forward, ray_direction) < view_angle / 2) //Finds the angle
                {
                    //print("Inside the angle");
                    if (!Physics.Raycast(transform.position, ray_direction, 50.0f, me))
                    {
                        //print("Can see 'em");
                        Debug.DrawLine(transform.position, target.transform.position, Color.green);
                        seenPlayersInRadius.Add(player);
                    }
                }

            }



        }
        rangeChecker();
    }
    void rangeChecker()
    {
        closestPlayer = Vector3.zero;
        foreach (Collider player in seenPlayersInRadius)
        {
            if (closestPlayer == Vector3.zero)
            {
                closestPlayer = player.transform.position;
                print(player.gameObject.name);
            }
            //tempStore = player.transform.position;
            else if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= Vector3.Distance(closestPlayer, gameObject.transform.position))
            {
                closestPlayer = player.transform.position;
            }

        }
    }
}
