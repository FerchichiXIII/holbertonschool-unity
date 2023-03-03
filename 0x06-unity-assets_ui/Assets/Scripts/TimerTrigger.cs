using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTrigger : MonoBehaviour
{
    public Canvas CanvasObject;


    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
        {
            //CanvasObject.GetComponent<Canvas>().enabled = true;
            Timer gett = GameObject.Find("TimerCanvas").GetComponent<Timer>();
            gett.playing = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            //CanvasObject.GetComponent<Canvas>().enabled = false;
        }
    }
}
