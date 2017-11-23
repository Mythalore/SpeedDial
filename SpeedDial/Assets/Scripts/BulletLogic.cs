using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour {
    private float speed = 30.0f;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.forward * speed;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != transform.parent.tag)
        {
            if (col.CompareTag("Ground") || col.CompareTag("Barrel"))
            {
                Destroy(gameObject);
            }
            else
            {
                //Damage that player
            }

        }
    }

}
