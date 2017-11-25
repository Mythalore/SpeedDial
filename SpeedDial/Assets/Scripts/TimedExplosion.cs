using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedExplosion : MonoBehaviour
{
	public ParticleSystem explosion;

    public float explode_force = 15.0f;

    private Rigidbody otherRig;
    private AudioSource source;
    private bool exploding = false;
    private List<GameObject> players = new List<GameObject>(4);

	// Use this for initialization
	void Start () {
		explosion = gameObject.GetComponentInChildren<ParticleSystem> ();
        source = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player1"))
        {           
			StartCoroutine(Explode ());
        }

    }

    void OnTriggerStay(Collider col)
    {
        
        if (col.gameObject.CompareTag("Player1"))
        {                            
            if(!players.Contains(col.gameObject))
            {
                players.Add(col.gameObject);
            }
            
        }     
    }


    IEnumerator Explode()
	{
		print ("exploding");
        source.Play();        
		yield return new WaitForSeconds (3.3f);
        explosion.Play ();
        ExplodePlayers();
		Destroy (gameObject);
	}


    void ExplodePlayers()
    {
        foreach (GameObject player in players)
        {
            print(player + " in range. applying force.");
            Vector3 dir = player.transform.position - transform.position;
            dir = dir.normalized;
            otherRig = player.gameObject.GetComponent<Rigidbody>();
            otherRig.AddForce(dir * explode_force, ForceMode.Impulse);
            //DO DAMAGE
        }
    }
}
