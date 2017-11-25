using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvProjLogic : MonoBehaviour {
    private float speed = 30.0f;
    private float speed2 = 3.0f;
    private Rigidbody rb;
    private Vector3 targetForProj = Vector3.zero;
    private Vector3 startPos;
    float lerpTime = 1.0f;
    float currentLerpTime;
    float moveDistance = 10f;
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
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Untagged" && col.gameObject.tag != "Rocket" && col.gameObject.tag != transform.parent.tag)
        {
            //print(col.gameObject.tag);
            //print(transform.parent.tag);
            if (col.CompareTag("Ground") || col.CompareTag("Barrel") || col.CompareTag("Bumper"))
            {
                Destroy(gameObject);
            }
            else
            {
                print("player");
                Destroy(gameObject);
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

}
