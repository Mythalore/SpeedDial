using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour {
    private float speed = 3000.0f;
    private Rigidbody rb;
	private float timerDelta;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		//timerDelta = Time.deltaTime * 1000;
	}
	
	// Update is called once per frame
	void Update () {
		timerDelta = Time.deltaTime * 10;
		rb.velocity = (transform.forward * speed) * Time.fixedDeltaTime;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != transform.parent.tag && col.gameObject.tag != "Ignore")
        {
            if(col.gameObject.CompareTag("Player1") || col.gameObject.CompareTag("Player2")|| col.gameObject.CompareTag("Player3")|| col.gameObject.CompareTag("Player4"))
            {
                col.GetComponent<Damage>().TakeDamage(10, transform.parent.name);
                print(col.gameObject.tag + " hit for 2");
            }
            Destroy(gameObject);
        }
    }

}
