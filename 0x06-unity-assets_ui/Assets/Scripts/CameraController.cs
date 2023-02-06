using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float HorizontalSpeed = 2f;
    public float VerticalSpeed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = HorizontalSpeed * Input.GetAxis("Mouse X");

        transform.Rotate(0, h, 0f);
        
    }
}
