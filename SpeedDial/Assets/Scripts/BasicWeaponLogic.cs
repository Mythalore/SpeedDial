using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeaponLogic : MonoBehaviour {
    public GameObject bullet;
    private float time = 0.0f;
    private float timeBetweenBullet = 0.5f;
	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
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
