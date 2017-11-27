using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public int health = 100;
    public GameObject huge_Fire;
    public GameObject smoke;

    private autobounce _ab;
    private ParticleSystem explosion;
    // Use this for initialization
    void Start () {
        explosion = GetComponentInChildren<ParticleSystem>();
        //huge_Fire = GetComponentInChildren<GameObject>(small_Fire);
	}
	
	// Update is called once per frame
	void Update () {
		
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
            huge_Fire.transform.localScale = new Vector3(1, 1, 1);
        }
        if (health > 25 && health <= 50)
        {
            huge_Fire.gameObject.SetActive(true);

        }
        if (health > 10 && health <= 25)
        {
            huge_Fire.transform.localScale = new Vector3(1, 1, 1);

        }
        if (health > 0 && health <= 10)
        {
            huge_Fire.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if(health == 0)
        {
            DestroyCar();               
        }
    }

    void DestroyCar()
    {
        explosion.Play();
        health = 100;
        _ab.flipTimer(_ab.start_pos);
    }

    void OnCollisionEnter(Collision col)
    {
        print("entered");
        switch (col.gameObject.tag)
        {
            case "BasicBullet":
                print("taking 2 damage");
                TakeDamage(2);
                break;
            case "SpecialWeapon":
                TakeDamage(40);
                break;
            default:
                break;
        }
    }
}
