using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed = 2f;
    public bool isInverted = false;
    public Transform Player;
    private Vector3 OffSet;
    public Vector3 turn;

    void Start()
    {
        turn = transform.position - Player.position;
        transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
    }

    // Update is called once per fram
    void Update()
    {
        if (!isInverted)
        {
            turn = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * Speed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * -Speed, Vector3.left) * turn;
            transform.position = Player.position + turn;
            transform.LookAt(Player.position);
        }
        else
        {
            turn = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * Speed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * Speed, Vector3.left) * turn;
            transform.position = Player.position + turn;
            transform.LookAt(Player.position);

        }
    }
    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PosX", transform.position.x);
        PlayerPrefs.SetFloat("PosY", transform.position.y);
        PlayerPrefs.SetFloat("PosZ", transform.position.z);
    }
}
