using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private int p1Deaths;
    private int p2Deaths;
    private int p3Deaths;
    private int p4Deaths;

    // Use this for initialization
    void Start () {
       

    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);
        if(minutes != 0)
            timer_text.text = minutes.ToString() + ":" + seconds.ToString();
        else
            timer_text.text = "00" + ":" + seconds.ToString();

        P1ScoreText.text = p1Score.ToString() + "/" + p1Deaths.ToString();
        P2ScoreText.text = p2Score.ToString() + "/" + p2Deaths.ToString();
        P3ScoreText.text = p3Score.ToString() + "/" + p3Deaths.ToString();
        P4ScoreText.text = p4Score.ToString() + "/" + p4Deaths.ToString();

    }


    public void UpdatePlayerKills(string _playerName)
    {
        switch(_playerName)
        {
            case "Player1Car":
                p1Score++;
                break;
            case "Player2Car":
                p2Score++;
                break;
            case "Player3Car":
                p3Score++;
                break;
            case "Player4Car":
                p4Score++;
                break;
        }
    }

    public void UpdatePlayerLives(string _playerName)
    {
        switch (_playerName)
        {
            case "Player1Car":
                p1Deaths++;
                break;
            case "Player2Car":
                p2Deaths++;
                break;
            case "Player3Car":
                p3Deaths++;
                break;
            case "Player4Car":
                p4Deaths++;
                break;
        }
    }
}
