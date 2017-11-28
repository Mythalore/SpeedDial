using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLobbyScript : MonoBehaviour {

    public GameObject playerManagerObject;
    public PlayerManagement playerManager;
    public Sprite ThumbsUp;    
    public Sprite P1ThumbsDown;
    public Sprite P2ThumbsDown;
    public Sprite P3ThumbsDown;
    public Sprite P4ThumbsDown;



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
               // gameObject.GetComponent<Image>().color = Color.white;
                gameObject.GetComponent<Image>().sprite = ThumbsUp;
            }
            else if (playerManager.player1 == false)
            {
                //gameObject.GetComponent<Image>().color = Color.grey;
                gameObject.GetComponent<Image>().sprite = P1ThumbsDown;

            }
        }
       else if(this.gameObject.tag == "Player2")
       {
            if (playerManager.player2 == true)
            {
                //gameObject.GetComponent<Image>().color = Color.white;
                gameObject.GetComponent<Image>().sprite = ThumbsUp;
            }
            else if (playerManager.player2 == false)
            {
                //gameObject.GetComponent<Image>().color = Color.grey;
                gameObject.GetComponent<Image>().sprite = P2ThumbsDown;
            }
        }
       else if (this.gameObject.tag == "Player3")
       {
            if (playerManager.player3 == true)
            {
                //gameObject.GetComponent<Image>().color = Color.white;
                gameObject.GetComponent<Image>().sprite = ThumbsUp;
            }
            else if (playerManager.player3 == false)
            {
               // gameObject.GetComponent<Image>().color = Color.grey;
                gameObject.GetComponent<Image>().sprite = P3ThumbsDown;
            }
        }
      else if (this.gameObject.tag == "Player4")
        {
            if (playerManager.player4 == true)
            {
                //gameObject.GetComponent<Image>().color = Color.white;
                gameObject.GetComponent<Image>().sprite = ThumbsUp;
            }
            else if (playerManager.player4 == false)
            {
              //  gameObject.GetComponent<Image>().color = Color.grey;
                gameObject.GetComponent<Image>().sprite = P4ThumbsDown;
            }
        }
		
	}
}
