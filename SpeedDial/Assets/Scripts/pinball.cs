using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinball : MonoBehaviour {
    private Rigidbody otherRig;
	public ParticleSystem explosion;
    public GameObject brokenBarrel;
    private AudioSource source;
    public float bumper_force = 10.0f;

	// Use this for initialization
	void Start () {
		//explosion = gameObject.GetComponentInChildren<ParticleSystem> ();
        //source = gameObject.GetComponent<AudioSource>();
	}


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player1"))
        {
            Vector3 dir = col.contacts[0].point - transform.position;
            dir = dir.normalized;
            dir.y *= 0.5f;
            otherRig = col.gameObject.GetComponent < Rigidbody >();
            otherRig.AddForce(dir* bumper_force, ForceMode.Impulse);
        }

    }



}
