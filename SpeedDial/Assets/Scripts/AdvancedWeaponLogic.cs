using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedWeaponLogic : MonoBehaviour {
    private int weaponUses;
    private int weaponDamage;
    private float timer = 1.0f;
    private float timeBetweenShots = 1.0f;
    public GameObject rocket;
    private string AttachedWeaponName;
    public enum AttachState
    {
        Idle,
        NoWeaponAttached,
        WeaponAttached
    }
    public enum WeaponState
    {
        Idle,
        Tracking,
        NotTracking,
        Firing
    }
    public AttachState attachState;
    public WeaponState weaponState;
	// Use this for initialization
	void Start () {
        weaponUses = 0;
        weaponDamage = 0;
        attachState = AttachState.NoWeaponAttached;
        weaponState = WeaponState.Idle;
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (attachState == AttachState.WeaponAttached)
        {
            LookAttarget();
        }
		if (Input.GetButton("AdvFire1") && attachState == AttachState.WeaponAttached)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenShots)
            {
                timer = 0.0f;
                if (AttachedWeaponName == "Rocket")
                {
                    var newBullet = Instantiate(rocket, gameObject.transform.position, this.transform.rotation);
                    newBullet.transform.parent = gameObject.transform.parent;
                    weaponUses--;
                }
                if (weaponUses == 0)
                {
                    removeWeapon();
                }
            }

        }
	}
    public void AttachedWeapon(string weaponType)
    {
        attachState = AttachState.WeaponAttached;
        if (weaponType == "Rocket")
        {
            AttachedWeaponName = "Rocket";
            weaponUses = 3;
            weaponDamage = 20;
        }
    }
    private void removeWeapon()
    {
        attachState = AttachState.NoWeaponAttached;
        Destroy(gameObject.transform.Find(AttachedWeaponName).gameObject);
    }
    private void LookAttarget()
    {

    }
}
