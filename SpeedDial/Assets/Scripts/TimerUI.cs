using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour {
    private float timer = 0.0f;
    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);
        if(minutes != 0)
        text.text = minutes.ToString() + ":" + seconds.ToString();
        else
            text.text = "00" + ":" + seconds.ToString();

        print(timer);
    }
}
