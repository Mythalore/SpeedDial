using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedWeaponLogic : MonoBehaviour {
    public int weaponUses;
    private int weaponDamage;
    private float timer = 1.0f;
    public float timeBetweenShots = 0.0f;
    public GameObject rocketObj;
    public GameObject LaserObj;
    public GameObject JoustPoleObj;
    private string AttachedWeaponName;
    private Weapon wpnMan;
    private WeaponTargeting WpnTar;
    private LineRenderer line;



    private string Y;
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
       // WpnTar = gameObject.transform.parent.transform.GetComponentInChildren<WeaponTargeting>();
        weaponUses = 0;
        weaponDamage = 0;
        timeBetweenShots = 0.0f;
        attachState = AttachState.NoWeaponAttached;
        weaponState = WeaponState.Idle;
        timer = Time.time;
        wpnMan = gameObject.GetComponent<Weapon>();
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;

       if(gameObject.transform.parent.CompareTag("Player1"))
        {
            Y = "P1 Y";
        }
        if (gameObject.transform.parent.CompareTag("Player2"))
        {
            Y = "P2 Y";
        }
        if (gameObject.transform.parent.CompareTag("Player3"))
        {
            Y = "P3 Y";
        }
        if (gameObject.transform.parent.CompareTag("Player4"))
        {
            Y = "P4 Y";
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(Y) && attachState == AttachState.WeaponAttached)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenShots)
            {
                timer = 0.0f;
                if (AttachedWeaponName == "Rocket")
                    
                {
                    var newBullet = Instantiate(rocketObj, gameObject.transform.position, gameObject.transform.rotation);
                    newBullet.transform.parent = gameObject.transform.parent;
                    newBullet.GetComponent<CapsuleCollider>().isTrigger = false;
                    newBullet.GetComponent<AdvProjLogic>().setDamage(weaponDamage);
                    weaponUses--;
                }
                else if (AttachedWeaponName == "Joust")
                {
                    var newBullet = Instantiate(JoustPoleObj, gameObject.transform.position, gameObject.transform.rotation);
                    //newBullet.transform.parent = gameObject.transform.parent;
                    newBullet.GetComponent<CapsuleCollider>().isTrigger = false;
                    newBullet.GetComponent<AdvProjLogic>().setDamage(weaponDamage);
                    weaponUses--;
                }
                else if (AttachedWeaponName == "Laser")
                {
                    var newBullet = Instantiate(LaserObj, gameObject.transform.position, gameObject.transform.rotation);
                    //newBullet.transform.parent = gameObject.transform.parent;
                    newBullet.GetComponent<CapsuleCollider>().isTrigger = false;
                    newBullet.GetComponent<AdvProjLogic>().setDamage(weaponDamage);
                    weaponUses--;
                }
                if (weaponUses <= 0)
                {
                    removeWeapon();
                }

            }
        }
    }
    public void AttachedWeapon(string weaponType)
    {
        //attachState = AttachState.WeaponAttached;
        if (weaponType == "Rocket")
        {
            Rocket rocket = new Rocket();
            AttachedWeaponName = rocket.weaponName;
            weaponUses = rocket.weaponUses;
            print(rocket.weaponUses);
            weaponDamage = rocket.weaponDamage;
            timeBetweenShots = rocket.timeBetweenshots;
            timer = timeBetweenShots;
        }
        else if(weaponType == "Joust")
        {
            Joust joust = new Joust();
            AttachedWeaponName = joust.weaponName;
            weaponUses = joust.weaponUses;
            weaponDamage = joust.weaponDamage;
            timeBetweenShots = joust.timeBetweenshots;
        }
        else if(weaponType == "Laser")
        {
            Laser laser = new Laser();
            AttachedWeaponName = laser.weaponName;
            weaponUses = laser.weaponUses;
            weaponDamage = laser.weaponDamage;
            timeBetweenShots = laser.timeBetweenshots;
            timer = timeBetweenShots;
        }
        
    }
    private void removeWeapon()
    {
        attachState = AttachState.NoWeaponAttached;
        foreach (Transform child in transform)
        {
                Destroy(child.gameObject);
        }
    }
    public void setAttached()
    {
        attachState = AttachState.WeaponAttached;
    }
}
