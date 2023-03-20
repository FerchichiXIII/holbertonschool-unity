using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    }
    private void Start()
    {
        StartCoroutine(ActivateObjectAfterDelay(3));
    }
}
