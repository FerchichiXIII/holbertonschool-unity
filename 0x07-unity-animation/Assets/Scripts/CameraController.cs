using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed = 2f;
    public bool isInverted = false;
    public Transform player;

    public Vector3 turn;

    void Start()
    {
        turn = transform.position - player.position;
    }

    // Update is called once per fram
    void Update()
    {
        if (!isInverted)
        {
            turn = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * Speed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * -Speed, Vector3.left) * turn;
            transform.position = player.position + turn;
            transform.LookAt(player.position);
        }
        else
        {
            turn = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * Speed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * Speed, Vector3.left) * turn;
            transform.position = player.position + turn;
            transform.LookAt(player.position);

        }

    }
}