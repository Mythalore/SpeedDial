using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodingBarrel : MonoBehaviour {
    private Rigidbody otherRig;
	public ParticleSystem explosion;
    public GameObject brokenBarrel;
    private AudioSource source;
    public float explode_force = 10.0f;
    private Mesh mesh;
    private bool exploding = false;

	// Use this for initialization
	void Start () {
		explosion = gameObject.GetComponentInChildren<ParticleSystem> ();
        source = gameObject.GetComponent<AudioSource>();
        mesh = gameObject.GetComponent<Mesh>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    void OnCollisionEnter(Collision col)
    {
        
        if(col.gameObject.CompareTag("Player1") || col.gameObject.CompareTag("Player2") || col.gameObject.CompareTag("Player3") || col.gameObject.CompareTag("Player4"))
        {
            Vector3 dir = col.contacts[0].point - transform.position;
            dir = dir.normalized;
            otherRig = col.gameObject.GetComponent < Rigidbody >();
            otherRig.AddForce(dir*explode_force, ForceMode.Impulse);
			StartCoroutine(Explode ());
            exploding = true;
            col.gameObject.GetComponent<Damage>().TakeDamage(20, "");

        }

        

    }


	IEnumerator Explode()
	{
		print ("exploding");
        //DO DAMAGE
		explosion.Play ();
        source.Play();
        Instantiate(brokenBarrel);
        if(brokenBarrel.transform.position != transform.position)
        {
            brokenBarrel.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);
        }
		//explosion.enabled = true;
		yield return new WaitForSeconds (0.3f);
		Destroy (gameObject);
	}
}
