using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeaponLogic : MonoBehaviour {
    public GameObject bullet;
    private float time = 0.0f;
    private float timeBetweenBullet = 0.5f;

    private string X;
	// Use this for initialization
	void Start () {
        time = Time.time;


        if (gameObject.transform.parent.CompareTag("Player1"))
        {
            X = "P1 X";
        }
        if (gameObject.transform.parent.CompareTag("Player2"))
        {
            X = "P2 X";
        }
        if (gameObject.transform.parent.CompareTag("Player3"))
        {
            X = "P3 X";
        }
        if (gameObject.transform.parent.CompareTag("Player4"))
        {
            X = "P4 X";
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(X))
        {
            time += Time.deltaTime;
            if (time >= timeBetweenBullet)
            {
                time = 0.0f;
                var newBullet = Instantiate(bullet, gameObject.transform.position, this.transform.rotation);
                newBullet.transform.parent = gameObject.transform.parent;
            }

        }
	}
}
