using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for recieving damage
/// NOTE : Currently particle system is being set active each frame, this needs to change
/// </summary>
public class Damage : MonoBehaviour
{

    public int health = 100;
    public GameObject fire;
    public GameObject smoke;
    public GameObject explosion;

    private autobounce _ab;
    // Use this for initialization
    void Start () {
        _ab = gameObject.GetComponent<autobounce>();
        //huge_Fire = GetComponentInChildren<GameObject>(small_Fire);
        fire.SetActive(false);
        smoke.SetActive(false);
        explosion.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        HealthIndicator();
	}


    public void TakeDamage(int _weaponDamage)
    {
        health -= _weaponDamage;
    }

    void HealthIndicator()
    {
        if(health > 75 && health <= 100)
        {
            return;
        }
        if (health > 50 && health <= 75)
        {
            
            smoke.SetActive(true);
            //smoke.transform.localScale = new Vector3(1, 1, 1);
        }
        if (health > 25 && health <= 50)
        {
            fire.gameObject.SetActive(true);

        }
        if (health > 10 && health <= 25)
        {
            fire.transform.localScale = new Vector3(1, 1, 1);

        }
        if (health > 0 && health <= 10)
        {
            fire.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if(health <= 0)
        {
            DestroyCar();               
        }
    }

    void DestroyCar()
    {
        explosion.SetActive(true);
        
        _ab.flipCar(_ab.start_pos);
        fire.SetActive(false);
        smoke.SetActive(false);
        health = 100;
        explosion.SetActive(false);

    }

    void OnTriggerEnter(Collider col)
    {

        //print("entered");
        //switch (col.gameObject.tag)
        //{
        //    case "BasicBullet":
        //        print("taking 2 damage");
        //        TakeDamage(2);
        //        break;
        //    case "SpecialWeapon":
        //        TakeDamage(40);
        //        break;
        //    default:
        //        break;
        //}
    }
}
