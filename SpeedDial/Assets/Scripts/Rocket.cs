using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Weapon {

	// Use this for initialization
	public Rocket () {
        weaponUses = 3;
        weaponName = "Rocket";
        weaponDamage = 30;
        timeBetweenshots = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
