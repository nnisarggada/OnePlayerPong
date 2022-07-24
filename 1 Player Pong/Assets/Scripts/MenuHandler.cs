using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
	public static string gameMode;

	private void Start()
	{
		
	}

	public void Solo()
	{
		gameMode = "solo";
		SceneManager.LoadScene("solo");
		FindObjectOfType<AudioManager>().Play("UI");
	}
	
	public void Team()
	{
		gameMode = "team";
		SceneManager.LoadScene("team");
		FindObjectOfType<AudioManager>().Play("UI");
	}
	
	public void Versus()
	{
		gameMode = "versus";
		SceneManager.LoadScene("versus");
		FindObjectOfType<AudioManager>().Play("UI");
	}
	
	public void Exit()
	{
		Debug.Log("exited");
		FindObjectOfType<AudioManager>().Play("UI");
		Application.Quit();
	}
}
