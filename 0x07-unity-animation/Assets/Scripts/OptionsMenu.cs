using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertToggle;

    void Start()
    {
        if (PlayerPrefs.GetInt("isInverted") == 1)
        {
            invertToggle.isOn = true;
        }
        else
        {
            invertToggle.isOn = false;
        }
    }

    public void Back()
    {
        string lastScene = PlayerPrefs.GetString("currentScene");
        SceneManager.LoadScene(lastScene);
    }

    public void Apply()
    {
        if (invertToggle.isOn)
        {
            PlayerPrefs.SetInt("isInverted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isInverted", 0);
        }

    }
}