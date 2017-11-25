using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour 
{

    // Use this for initialization
	public bool collectable = false;

	public Canvas canvas;
    public Image phone;

	public List<Image> buttons = new List<Image>();
	public List<Image> DPad = new List<Image>();

	public List<bool> button_bool = new List<bool> ();
	public List<bool> DPad_bool = new List<bool> ();

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
		//if(Input.GetKeyDown("joystick button 0"))
		if(collectable == true)
        {
			phone.transform.Translate (0, 540, 0);
			collectable = false;

			//highlights buttons etc
			RandomizeButton ();
        }

		if (Input.GetKeyDown ("0")) 
		{
			RandomizeButton ();
		}

		if (Input.GetKeyDown ("9")) 
		{
			buttons [random_number_button].color = ogc;
			DPad [random_number_dpad].color = seethrough;
		}
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
