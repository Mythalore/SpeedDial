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
   
    private string player1Value;
    private string player2Value;
    private string player3Value;
    private string player4Value;
	// Use this for initialization
	void Start () {
        playerManagerObject = GameObject.Find("PlayerManager");
        

        player1Value = playerManagerObject.GetComponent<PlayerManagement>().player1Rank;
        player2Value = playerManagerObject.GetComponent<PlayerManagement>().player2Rank;
        player3Value = playerManagerObject.GetComponent<PlayerManagement>().player3Rank;
        player4Value = playerManagerObject.GetComponent<PlayerManagement>().player4Rank;

        if(this.gameObject.tag == "1ST")
        {
            if(player1Value == "1ST")
            {
                gameObject.GetComponent<Image>().sprite = Player1;
            }
            else if(player2Value == "1ST")
            {
                gameObject.GetComponent<Image>().sprite = Player2;
            }
            else if (player3Value == "1ST")
            {
                gameObject.GetComponent<Image>().sprite = Player3;
            }
            else if (player4Value == "1ST")
            {
                gameObject.GetComponent<Image>().sprite = Player4;
            }

        }
        else if (this.gameObject.tag == "2ND")
        {
            if (player1Value == "2ND")
            {
                gameObject.GetComponent<Image>().sprite = Player1;
            }
            else if (player2Value == "2ND")
            {
                gameObject.GetComponent<Image>().sprite = Player2;
            }
            else if (player3Value == "2ND")
            {
                gameObject.GetComponent<Image>().sprite = Player3;
            }
            else if (player4Value == "2ND")
            {
                gameObject.GetComponent<Image>().sprite = Player4;
            }

        }
        else if (this.gameObject.tag == "3RD")
        {
            if (player1Value == "3RD")
            {
                gameObject.GetComponent<Image>().sprite = Player1;
            }
            else if (player2Value == "3RD")
            {
                gameObject.GetComponent<Image>().sprite = Player2;
            }
            else if (player3Value == "3RD")
            {
                gameObject.GetComponent<Image>().sprite = Player3;
            }
            else if (player4Value == "3RD")
            {
                gameObject.GetComponent<Image>().sprite = Player4;
            }

        }
        else if (this.gameObject.tag == "4TH")
        {
            if (player1Value == "4TH")
            {
                gameObject.GetComponent<Image>().sprite = Player1;
            }
            else if (player2Value == "4TH")
            {
                gameObject.GetComponent<Image>().sprite = Player2;
            }
            else if (player3Value == "4TH")
            {
                gameObject.GetComponent<Image>().sprite = Player3;
            }
            else if (player4Value == "4TH")
            {
                gameObject.GetComponent<Image>().sprite = Player4;
            }

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
