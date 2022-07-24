using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
	public GameObject PauseUI;
	public GameObject PauseButton;

	public void PauseGame()
	{
		Time.timeScale = 0f;
		PauseButton.SetActive(false);
		PauseUI.SetActive(true);
		FindObjectOfType<AudioManager>().Play("UI");
	}

	public void Resume()
	{
		PauseUI.SetActive(false);
		PauseButton.SetActive(true);
		Time.timeScale = 1f;
		FindObjectOfType<AudioManager>().Play("UI");
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		FindObjectOfType<AudioManager>().Play("UI");
	}

	public void Menu()
	{
		SceneManager.LoadScene("menu");
		FindObjectOfType<AudioManager>().Play("UI");
	}
}
