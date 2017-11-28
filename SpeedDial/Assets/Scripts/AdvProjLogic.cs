using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvProjLogic : MonoBehaviour {
    private float speed = 30f;
    private Rigidbody rb;
    private Vector3 targetForProj = Vector3.zero;
    private Vector3 startPos;
    float lerpTime = 1.0f;
    float currentLerpTime;
    float moveDistance = 10f;
    private int Dmg;
    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        //vel = transform.forward * 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetForProj == Vector3.zero)
        {
            rb.velocity = transform.forward * speed;
        }
        else if (transform.position != targetForProj)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(transform.position, targetForProj, perc);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != transform.parent.tag && col.gameObject.tag != "Ignore")
        {
            print("Hit");
            if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Barrel") || col.gameObject.CompareTag("Bumper"))
            {
                print("Hit object");
                Destroy(gameObject);
            }
            else
            {
                print("whomp");
                print("player");
                Destroy(gameObject);
                col.gameObject.GetComponent<Damage>().TakeDamage(Dmg);
                //Damage that player
                //get component player health -= advancedweaponLogicscript.weaponDamage?
            }
        }
    }
    public void setTarget(Vector3 target)
    {
        targetForProj = target;
        print(target);
    }
    public void setDamage(int damage)
    {
        Dmg = damage;
    }

}
