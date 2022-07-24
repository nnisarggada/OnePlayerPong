using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
	public Animator transition;

    public void LoadMenu()
	{
		StartCoroutine(LoadingMenu());
	}

	IEnumerator LoadingMenu()
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(1f);

		SceneManager.LoadScene("menu");
	}
}
