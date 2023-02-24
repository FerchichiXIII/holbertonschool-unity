using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public bool playing = false;
    private float timer;
    void Start()
    {
        timer = PlayerPrefs.GetFloat("Timer", 0f);
    }
    void OnDestroy()
    {
        PlayerPrefs.SetFloat("Timer", timer);
    }

    void Update()
    {
        if (playing == true)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer % 60F);
            int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
            TimerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
        }
    }
}