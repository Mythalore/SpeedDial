using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon {

	// Use this for initialization
	public Laser () {
        weaponUses = 50;
        weaponName = "Laser";
        weaponDamage = 2;
        timeBetweenshots = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
