using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour {

	public GameObject rocket;
	public GameObject joust;
	public GameObject machinegun;
	private bool occupied = true;
	private float timer = 0.0f;

	private GameObject powerup;

	// Use this for initialization
	void Start () {
		assignPowerUp ();
	}
	
	// Update is called once per frame
	void Update () {





		if (!occupied) {
			timer += Time.deltaTime;
		}



		if (timer >= 10) {
			timer = 0.0f;
			occupied = false;

			assignPowerUp ();
		}



	}



	void assignPowerUp()
	{
		int weapon = Random.Range (0, 2);
		weapon = 1;
		if (weapon == 0) {
			powerup = Instantiate (rocket, gameObject.transform.position, rocket.transform.rotation);
			powerup.transform.parent = gameObject.transform;
			powerup.transform.position = new Vector3 (0.0f, 0.026f, 0.15f);
		} else if (weapon == 1) {
			powerup = Instantiate (joust, gameObject.transform.position, joust.transform.rotation);
			powerup.transform.parent = gameObject.transform;
			powerup.transform.position = new Vector3 (0.0f, 0.026f, 0.15f);
		} else if (weapon == 2) {
			powerup = Instantiate (machinegun, gameObject.transform.position, machinegun.transform.rotation);
			powerup.transform.parent = gameObject.transform;
			powerup.transform.position = new Vector3 (-19.88f, 0.084f, 53.882f);
		}

	}

}
