using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class WinTrigger : MonoBehaviour
{
    public Canvas CanvasObject;
    public Text TimerText;
    public GameObject WinCanvas;
    //public GameObject WinCanvas;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WinFlag")
        {
            Timer gett = GameObject.Find("TimerCanvas").GetComponent<Timer>();
            gett.playing = false;
            TimerText.color = Color.green;
            TimerText.fontSize = 60;
           // WinCanvas.SetActive(true);
            gett.Win();
        }
    }
}
