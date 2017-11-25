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

	public Color seethrough;
	public Color highlighted;
	private Color ogc;

	private int random_number_button;
	private int random_number_dpad;

	void Start () 
	{
		ogc = buttons [0].color;
		random_number_button = 0;
		random_number_dpad = 0;

		for (int i = 0; i < 4; i++) 
		{
			DPad [i].color = seethrough;
			DPad_bool [i] = false;
			button_bool [i] = false;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		PhoneUp ();








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
		random_number_button = Random.Range(0, 4);
		random_number_dpad = Random.Range(0, 4);

		buttons[random_number_button].color = highlighted;
		button_bool [random_number_button] = true;

		DPad[random_number_dpad].color = highlighted;
		DPad_bool [random_number_dpad] = true;
	}
}
