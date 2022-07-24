using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchToggle.vibration = true;
        SceneManager.LoadScene("menu");
    }
}