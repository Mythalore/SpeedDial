using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLobbyScript : MonoBehaviour {

    public GameObject playerManagerObject;
    public PlayerManagement playerManager;
    

    // Use this for initialization
    void Start () {

        playerManagerObject = GameObject.FindGameObjectWithTag("PlayerManager");
        playerManager = playerManagerObject.GetComponent<PlayerManagement>();
        
	}
	
	// Update is called once per frame
	void Update () {


        

        if (this.gameObject.tag == "Player1")
        {
            if (playerManager.player1 == true)
            {
                gameObject.GetComponent<Image>().color = Color.white;
            }
            else if (playerManager.player1 == false)
            {
                gameObject.GetComponent<Image>().color = Color.grey;
            }
        }
       else if(this.gameObject.tag == "Player2")
       {
            if (playerManager.player2 == true)
            {
                gameObject.GetComponent<Image>().color = Color.white;
            }
            else if (playerManager.player2 == false)
            {
                gameObject.GetComponent<Image>().color = Color.grey;
            }
        }
       else if (this.gameObject.tag == "Player3")
       {
            if (playerManager.player3 == true)
            {
                gameObject.GetComponent<Image>().color = Color.white;
            }
            else if (playerManager.player3 == false)
            {
                gameObject.GetComponent<Image>().color = Color.grey;
            }
        }
      else if (this.gameObject.tag == "Player4")
        {
            if (playerManager.player4 == true)
            {
                gameObject.GetComponent<Image>().color = Color.white;
            }
            else if (playerManager.player4 == false)
            {
                gameObject.GetComponent<Image>().color = Color.grey;
            }
        }
		
	}
}
