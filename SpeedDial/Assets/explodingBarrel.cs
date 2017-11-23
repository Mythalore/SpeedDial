using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodingBarrel : MonoBehaviour {
    private Rigidbody otherRig;
    public float explode_force = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player1"))
        {
            Vector3 dir = col.contacts[0].point - transform.position;
            dir = -dir.normalized;
            otherRig = col.gameObject.GetComponent < Rigidbody >();
            otherRig.AddForce(dir*explode_force, ForceMode.Impulse);
            //otherRig.AddForceAtPosition(force_direction * explode_force, col.ClosestPoint(transform.position));
        }

    }
}
