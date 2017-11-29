using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour {


    public Sprite Player1;
    public Sprite Player2;
    public Sprite Player3;
    public Sprite Player4;

    private GameObject playerManagerObject;
   
     int first;

    // Use this for initialization
    void Start() {
        playerManagerObject = GameObject.Find("PlayerManager");

        first = playerManagerObject.GetComponent<PlayerManagement>().winner;
        //player1Value = playerManagerObject.GetComponent<PlayerManagement>().player1Rank;
        //player2Value = playerManagerObject.GetComponent<PlayerManagement>().player2Rank;
        // player3Value = playerManagerObject.GetComponent<PlayerManagement>().player3Rank;
        // player4Value = playerManagerObject.GetComponent<PlayerManagement>().player4Rank;


        if (first == 1)
        {
            gameObject.GetComponent<Image>().sprite = Player1;
            gameObject.GetComponent<Image>().color = Color.red;
        }
        else if (first == 2)
        {
            gameObject.GetComponent<Image>().sprite = Player2;
            gameObject.GetComponent<Image>().color = Color.magenta;
        }
        else if (first == 3)
        {
            gameObject.GetComponent<Image>().sprite = Player3;
            gameObject.GetComponent<Image>().color = Color.yellow;
        }
        else if (first == 4)
        {
            gameObject.GetComponent<Image>().sprite = Player4;
            gameObject.GetComponent<Image>().color = Color.green;
        }


    }

        

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
