using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPower : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
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
                pos.GetComponent<AdvancedWeaponLogic>().AttachedWeapon(gameObject.tag);
            }
            
        }

    }
}
