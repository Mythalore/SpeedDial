using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour 
{
	public bool collectable = false;

	public Canvas canvas;
    public Image phone;

	public List<Image> buttons = new List<Image>();
	public List<Image> DPad = new List<Image>();

	private bool[] button_bool = new bool[4];
	private bool[] DPad_bool = new bool[4];

    private string[] button_string = new string[4];
    private string[] DPadButton_string = new string[4];

	public Color seethrough;
	public Color highlighted;
	private Color ogc;

	private int random_number_button;
	private int random_number_dpad;
    private string combination;
    private string playerCombination;

	void Start () 
	{

        //ADD MULTIPLE PLAYER INPUT STUFF HERE


		ogc = buttons [0].color;
		random_number_button = 0;
		random_number_dpad = 0;

		for (int i = 0; i < 4; i++) 
		{
			DPad [i].color = seethrough;
			DPad_bool [i] = false;
			button_bool [i] = false;
		}

        for(int i = 0; i <=3; i++)
        {
            if(i == 0)
            {
                DPadButton_string[i] = "UP";
            }
            else if(i == 1)
            {
                DPadButton_string[i] = "DOWN";

            }
            else if(i == 2)
            {
                DPadButton_string[i] = "LEFT";
            }
            else if(i == 3)
            {
                DPadButton_string[i] = "RIGHT";
            }
        }

        for (int i = 0; i <= 3; i++)
        {
            if (i == 0)
            {
                button_string[i] = "A";
            }
            else if (i == 1)
            {
                button_string[i] = "B";

            }
            else if (i == 2)
            {
                button_string[i] = "X";
            }
            else if (i == 3)
            {
                button_string[i] = "Y";
            }
        }

    }
	
	// Update is called once per frame
	void Update () 
	{
		PhoneUp ();

        string playerButton = "";
        string playerDPad = "";

        if(Input.GetButtonDown("A"))
        {
            playerButton = "A";

        }
        
        if(Input.GetButtonDown("B"))
        {
            playerButton = "B";
        }

        if(Input.GetButtonDown("X"))
        {
            playerButton = "X";
        }

        if(Input.GetButtonDown("Y"))
        {
            playerButton = "Y";
        }

        

        if(Input.GetAxis("DPADVERT") != 0)
        {
            if(Input.GetAxis("DPADVERT") < -0.1)
            {
                playerDPad = "DOWN";
            }
            else if(Input.GetAxis("DPADVERT") > 0.1)
            {
                playerDPad = "UP";
            }

        }

        if(Input.GetAxis("DPADHORI") != 0)
        {
            if(Input.GetAxis("DPADHORI") < -0.1)
            {
                playerDPad = "LEFT";
            }
            else if(Input.GetAxis("DPADHORI") > 0.1)
            {
                playerDPad = "RIGHT";
            }
           

        }

        playerCombination = playerDPad + playerButton;

        if(playerCombination == combination)
        {
            //Player entered the right thing! Move phone back down, give them a weapon
        }

        

		//debuggy sheet
		if (Input.GetKeyDown ("0")) 
		{
			RandomizeButton ();
		}
		//reset buttons
		if (Input.GetKeyDown ("9")) 
		{
			buttons [random_number_button].color = ogc;
			DPad [random_number_dpad].color = seethrough;
			DPad_bool [random_number_dpad] = false;
			button_bool [random_number_button] = false;
		}
	}

	void PhoneUp()
	{
		if(collectable == true)
		{
			phone.transform.Translate (0, 590, 0);
			collectable = false;

			//highlights buttons etc
			RandomizeButton ();
		}
	}

	void CorrectCombo()
	{


	}

	//highlights buttons and sets a boolean true to indicate which button needs pressing 
	void RandomizeButton()
	{
        string button = "";
        string DPadButton = "";
		random_number_button = Random.Range(0, 4);
		random_number_dpad = Random.Range(0, 4);

		buttons[random_number_button].color = highlighted;
		button_bool [random_number_button] = true;

		DPad[random_number_dpad].color = highlighted;
		DPad_bool [random_number_dpad] = true;

        for(int i = 0; i <= 3; i++)
        {
            if(button_bool[i])
            {
                button = button_string[i];
            }
        }

        for (int i = 0; i <= 3; i++)
        {
            if (DPad_bool[i])
            {
                DPadButton = DPadButton_string[i];
            }
        }


        combination = DPadButton + button;

        //if (Input.GetButtonDown("P1Fire")) ;
	}
}
