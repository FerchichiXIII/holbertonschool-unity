using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Camera MainCamera;
    public Canvas TimerCanvas;
    public GameObject Player;

    IEnumerator ActivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MainCamera.gameObject.SetActive(true);
        TimerCanvas.gameObject.SetActive(true);
        Player.GetComponent<PlayerController>().enabled = true;
        gameObject.SetActive(false);
        //    Time.timeScale = 1f;
    }
    private void Start()
    {
        StartCoroutine(ActivateObjectAfterDelay(3));
        Player.GetComponent<PlayerController>().enabled = false;

    }
}
