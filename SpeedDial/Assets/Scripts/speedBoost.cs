using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBoost : MonoBehaviour {

	// Use this for initialization

	carMovement player;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.CompareTag("Player1") || col.gameObject.CompareTag("Player2") || col.gameObject.CompareTag("Player3") || col.gameObject.CompareTag("Player4"))
		{
			player = col.gameObject.GetComponent<carMovement>();
			player.being_boosted = true;
		}
	}
}
