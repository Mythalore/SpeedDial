using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPower : MonoBehaviour {
    // Use this for initialization
    
   public GameObject[] car;
    int i;

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
                //Quaternion rot = pos.rotation;
                transform.localRotation = new Quaternion(transform.rotation.x, pos.localRotation.z, pos.localRotation.z, pos.localRotation.w);

                if(col.gameObject.CompareTag("Player1"))
                {
                    i = 0;
                }
                else if (col.gameObject.CompareTag("Player2"))
                {
                    i = 1;
                }
                else if (col.gameObject.CompareTag("Player3"))
                {
                    i = 2;
                }
                else if (col.gameObject.CompareTag("Player4"))
                {
                    i = 3;
                }



                //phone logic shit
                car[i].GetComponentInChildren<canvasScript>().collectable = true;             

                if (car[i].GetComponentInChildren<canvasScript>().weaponenabled == true)
                {
                    pos.GetComponent<AdvancedWeaponLogic>().AttachedWeapon(gameObject.tag);
                    car[i].GetComponentInChildren<canvasScript>().weaponenabled = false;
                }
            }
            
        }

    }
}
