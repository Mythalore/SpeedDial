using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform parent;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = parent.position;
        gameObject.transform.rotation = new Quaternion(0, parent.transform.rotation.y, 0, parent.transform.rotation.w);

	}
    public void setUp()
    {
        gameObject.transform.parent = null;
    }


}
