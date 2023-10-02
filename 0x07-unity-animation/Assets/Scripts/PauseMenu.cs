using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Player;
    public Text TimerUI;
    public static Vector3 playerPos;
    public static bool opts;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Timer gett = GameObject.Find("TimerCanvas").GetComponent<Timer>();
            PlayerController gett2 = GameObject.Find("Player").GetComponent<PlayerController>();
            gett.SaveTime();
            gett2.SavePosition();


            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                playerPos = Player.transform.position;
                PlayerPrefs.SetString("TheTimer", TimerUI.text);
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {

        opts = true;
        string scene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("currentScene", scene);
        Time.timeScale = 1;
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");

    }
}
