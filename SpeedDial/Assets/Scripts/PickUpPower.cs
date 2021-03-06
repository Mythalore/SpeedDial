﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPower : MonoBehaviour {
    // Use this for initialization
    private string weaponTag;

    void Start () {



    }
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = new Quaternion(transform.rotation.x, transform.parent.localRotation.y, transform.parent.localRotation.z, transform.parent.localRotation.w);
        transform.position = transform.parent.position;
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player1") || col.gameObject.CompareTag("Player2") || col.gameObject.CompareTag("Player3") || col.gameObject.CompareTag("Player4"))
        {
            if(col.gameObject.GetComponentInChildren<AdvancedWeaponLogic>().attachState == AdvancedWeaponLogic.AttachState.NoWeaponAttached)
            {
                transform.parent = col.transform;
                var pos = col.transform.Find("AttachmentPoint");
                transform.position = pos.position;
                transform.parent = pos;
                //Quaternion rot = pos.rotation;
                transform.localRotation = new Quaternion(transform.rotation.x, pos.localRotation.z, pos.localRotation.z, pos.localRotation.w);


                //phone logic
               // col.GetComponent<carMovement>().cameraGet().GetComponentInChildren<canvasScript>().collected = true;
                col.GetComponent<carMovement>().cameraGet().GetComponentInChildren<canvasScript>().collected = true;
                if (col.GetComponent<carMovement>().cameraGet().GetComponentInChildren<canvasScript>().weaponenabled == true)
                {
                    pos.GetComponent<AdvancedWeaponLogic>().AttachedWeapon(gameObject.tag);
                    col.GetComponent<carMovement>().cameraGet().GetComponentInChildren<canvasScript>().weaponenabled = false;
                }
            }
           
        }

    }
}
