using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
       
        if (level < 5)
        {
            SceneManager.LoadScene("Level0" + level.ToString());
        }
    }
    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}