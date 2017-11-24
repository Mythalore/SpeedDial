using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joust : Weapon {

	// Use this for initialization
	public Joust () {
        weaponUses = 1;
        weaponName = "Joust";
        weaponDamage = 95;
        timeBetweenshots = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
