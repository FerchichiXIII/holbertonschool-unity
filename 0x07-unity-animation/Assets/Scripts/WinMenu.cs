using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinMenu : MonoBehaviour
{   
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Next()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        
    }
}
