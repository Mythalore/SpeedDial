using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour 
{
	public bool collected = false;

	public Canvas canvas;
    public Image phone;
    public Animator phoneanim;

    public AudioSource speaker;
    public AudioClip sendTextSound;
    

	public List<Image> buttons = new List<Image>();
	public List<Image> DPad = new List<Image>();

	private bool[] button_bool = new bool[4];
	private bool[] DPad_bool = new bool[4];
    private bool phoneUp = false;
    private bool buttonDown = false;
    private bool DpadDown = false;

    public bool weaponenabled = false;

    private string[] button_string = new string[4];
    private string[] DPadButton_string = new string[4];

	public Color seethrough;
	public Color highlighted;
	private Color ogc;

	private int random_number_button;
	private int random_number_dpad;
    private int comboProgress = 0;

    private string combination;
    private string playerCombination;

    private string dPadHor;
    private string dPadVert;
    private string buttonA;
    private string buttonB;
    private string buttonX;
    private string buttonY;

    private string playerButton = "";
    private string playerDPad = "";

    private GameObject player;
    void Start () 
	{

        player = gameObject.transform.parent.transform.parent.transform.parent.gameObject;
        AssignPlayerInputs();
        ogc = buttons [0].color;
		random_number_button = 0;
		random_number_dpad = 0;

        //sets all dpad images to seethrough
		for (int i = 0; i < 4; i++) 
		{
			DPad [i].color = seethrough;
			DPad_bool [i] = false;
			button_bool [i] = false;
		}

        //sets the button array strings
        player.GetComponent<carMovement>().cameraGet().GetComponent<CameraMovement>().setUp();
        AssignButtonStrings();
    }
	
	// Update is called once per frame
	void Update () 
	{
        //puts the phone on the screen once collectable == true
		PhoneUp ();
        PlayerInputs();

        playerCombination = playerDPad + playerButton;

        //Player entered the right thing! Move phone back down, give them a weapon
        if (playerCombination == combination && buttonDown == true)
        {
            for (int i = 0; i < 3; i++)
            {
                buttons[i].color = ogc;
                DPad[i].color = seethrough;
                DPad_bool[i] = false;
                button_bool[i] = false;
            }
            playerCombination = "";
            playerDPad = "";
            playerButton = "";
            comboProgress++;
            RandomizeButton();
            
        }
        if (comboProgress == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                buttons[i].color = ogc;
                DPad[i].color = seethrough;
                DPad_bool[i] = false;
                button_bool[i] = false;
            }

            weaponenabled = true;
            phoneanim.SetBool("PhoneUp", false);
            comboProgress = 0;
            playerCombination = "";
            playerDPad = "";
            playerButton = "";
            player.GetComponentInChildren<AdvancedWeaponLogic>().setAttached();
            speaker.PlayOneShot(sendTextSound);
        }
    }

	public void PhoneUp()
	{
		if(collected == true)
		{
            collected = false;
            phoneanim.SetBool("PhoneUp", true);
            RandomizeButton();            
		}
	}

	//highlights buttons and sets a boolean true to indicate which button needs pressing 
	void RandomizeButton()
	{
        string button = "";
        string DPadButton = "";

		random_number_button = Random.Range(0, 3);
		random_number_dpad = Random.Range(0, 3);

        //sets required button to be highlighted and a bool for the button
		buttons[random_number_button].color = highlighted;
		button_bool [random_number_button] = true;

        //sets required dpad to be highlighted and a bool for the dpad
        DPad[random_number_dpad].color = highlighted;
		DPad_bool [random_number_dpad] = true;
        
        if(button_bool[random_number_button])
        {
            button = button_string[random_number_button];
        }

        if (DPad_bool[random_number_dpad])
        {
            DPadButton = DPadButton_string[random_number_dpad];
        }

        combination = DPadButton + button;
    }

    void AssignPlayerInputs()
    {
        if (gameObject.tag == "Player1")
        {
            print("setting P1...");
            dPadVert = "P1 DPadY";
            dPadHor = "P1 DPadX";
            buttonA = "P1 A";
            buttonB = "P1 B";
            buttonX = "P1 X";
            buttonY = "P1 Y";
        }
        if (gameObject.tag == "Player2")
        {
            print("setting P2...");

            dPadVert = "P2 DPadY";
            dPadHor = "P2 DPadX";
            buttonA = "P2 A";
            buttonB = "P2 B";
            buttonX = "P2 X";
            buttonY = "P2 Y";
        }
        if (gameObject.tag == "Player3")
        {
            print("setting P3...");

            dPadVert = "P3 DPadY";
            dPadHor = "P3 DPadX";
            buttonA = "P3 A";
            buttonB = "P3 B";
            buttonX = "P3 X";
            buttonY = "P3 Y";
        }
        if (gameObject.tag == "Player4")
        {
            dPadVert = "P4 DPadY";
            dPadHor = "P4 DPadX";
            buttonA = "P4 A";
            buttonB = "P4 B";
            buttonX = "P4 X";
            buttonY = "P4 Y";
        }
    }

    void AssignButtonStrings()
    {
        for (int i = 0; i <= 3; i++)
        {
            if (i == 0)
            {
                DPadButton_string[i] = "UP";
            }
            else if (i == 1)
            {
                DPadButton_string[i] = "DOWN";

            }
            else if (i == 2)
            {
                DPadButton_string[i] = "LEFT";
            }
            else if (i == 3)
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

    void PlayerInputs()
    {
        if (Input.GetKeyDown("0"))
        {
            collected = true;
        }
        //button A
        if (Input.GetButtonDown(buttonA))
        {
            playerButton = "A";           
            buttonDown = true;
        }
        if (Input.GetButtonUp(buttonA))
        {
            buttonDown = false;
        }
        //button B
        if (Input.GetButtonDown(buttonB))
        {
            playerButton = "B";
            buttonDown = true;
        }
        if (Input.GetButtonUp(buttonB))
        {
            buttonDown = false;
        }
        //button X
        if (Input.GetButtonDown(buttonX))
        {
            playerButton = "X";
            buttonDown = true;
        }
        if (Input.GetButtonUp(buttonX))
        {
            buttonDown = false;
        }
        //button Y
        if (Input.GetButtonDown(buttonY))
        {
            playerButton = "Y";
            buttonDown = true;
        }
        if (Input.GetButtonUp(buttonY))
        {
            buttonDown = false;
        }
        //Up and Down
        if (Input.GetAxis(dPadVert) != 0)
        {
            if (Input.GetAxis(dPadVert) < -0.1)
            {
                playerDPad = "DOWN";
               // DpadDown = true;
            }
            
            else if (Input.GetAxis(dPadVert) > 0.1)
            {
                playerDPad = "UP";
               // DpadDown = true;
            }            
        }
        //Left and Right
        else if (Input.GetAxis(dPadHor) != 0)
        {
            if (Input.GetAxis(dPadHor) < -0.1)
            {
                playerDPad = "LEFT";
               // DpadDown = true;
            }
            else if (Input.GetAxis(dPadHor) > 0.1)
            {
                playerDPad = "RIGHT";
               // DpadDown = true;
            }
        }
        else
        {
            //DpadDown = false;
            playerDPad = "";
        }
    }
}


