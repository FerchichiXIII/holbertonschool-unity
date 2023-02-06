using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WinTrigger : MonoBehaviour
{
    public Canvas CanvasObject;
    public Text TimerText;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WinFlag")
        {
            Timer gett = GameObject.Find("TimerCanvas").GetComponent<Timer>();
            gett.playing = false;
            TimerText.color = Color.green;
            TimerText.fontSize = 60;
        }
    }
}
