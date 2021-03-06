﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour {
    private float timer = 0.0f;
 

    public Text timer_text;
    public Text P1ScoreText;
    public Text P2ScoreText;
    public Text P3ScoreText;
    public Text P4ScoreText;
    

    private int p1Score;
    private int p2Score;
    private int p3Score;
    private int p4Score;

    public Vector3 offset = new Vector3(0.08f, 0.1f, 0);
    private int[] score = new int[4];
    private int[] deaths = new int[4];

    private int p1Deaths;
    private int p2Deaths;
    private int p3Deaths;
    private int p4Deaths;

    private GameObject playerManager;
    public GameObject crown;

    public GameObject[] player;

    public int winner_num = -1;
    // Use this for initialization
    void Start () {
        timer = 120;
        crown = GameObject.Find("Crown");
        playerManager = GameObject.Find("PlayerManager");
        player[0] = GameObject.Find("Player1Car(Clone)");
        player[1] = GameObject.Find("Player2Car(Clone)");
        player[2] = GameObject.Find("Player3Car(Clone)");
        player[3] = GameObject.Find("Player4Car(Clone)");
    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);

        if(minutes != 0)
            timer_text.text = "0" + minutes.ToString() + ":" + seconds.ToString();
        else
            timer_text.text = "00" + ":" + seconds.ToString();

        P1ScoreText.text = score[0].ToString() + "/" + deaths[0].ToString();
        P2ScoreText.text = score[1].ToString() + "/" + deaths[1].ToString();
        P3ScoreText.text = score[2].ToString() + "/" + deaths[2].ToString();
        P4ScoreText.text = score[3].ToString() + "/" + deaths[3].ToString();

       
        for(int i = 0; i < score.Length; i++)
        {
            if(score[i] > winner_num && score[i] != 0)
            {
                winner_num = i+1;
                print(winner_num);

            }
        }

        if(timer <= 0)
        {
            
            playerManager.GetComponent<PlayerManagement>().PlayerRankings(winner_num);
            SceneManager.LoadScene(3);
        }

        if(winner_num != -1)
        {
           // crown.transform.parent = player[winner_num].transform;
            //crown.transform.position = player[winner_num].transform.position + offset;      

        }

        
          
    }


    public void UpdatePlayerKills(string _playerName)
    {
        switch(_playerName)
        {
		case "Player1Car(Clone)":
                score[0]++;
                break;
		case "Player2Car(Clone)":
                score[1]++;
                break;
		case "Player3Car(Clone)":
                score[2]++;
                break;
		case "Player4Car(Clone)":
                score[3]++;
                break;
        }
    }

    public void UpdatePlayerLives(string _playerName)
    {
        switch (_playerName)
        {
		case "Player1Car(Clone)":
                deaths[0]++;
                break;
		case "Player2Car(Clone)":
                deaths[1]++;
                break;
		case "Player3Car(Clone)":
                deaths[2]++;
                break;
		case "Player4Car(Clone)":
                deaths[3]++;
                break;
        }
    }
}
