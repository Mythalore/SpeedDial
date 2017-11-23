using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {


	public Animator animator;

	public void StartGameBtn(string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);
	}

	public void QuitGameBtn()
	{
		Application.Quit ();

	}

	public void ControlsBtn()
	{
		animator.SetBool ("ControlsUp", !animator.GetBool ("ControlsUp"));
	}

}
