using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject UI;
	public GameObject MenuLoader;

	void Start()
	{
		Time.timeScale = 0f;
		MenuLoader.SetActive(false);
	}

	void Update()
    {
		
        if(Input.touchCount > 0 || Input.anyKey)
		{
			UI.SetActive(false);
			Time.timeScale = 1f;
		}
    }
}
