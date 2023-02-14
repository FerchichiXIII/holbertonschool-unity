using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float Jump = 3.5f;
    public CharacterController cc;
    public GameObject player;
    private float directionY;
    private float gravity = 9.0f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 PlayerMovement = new Vector3(x, 0, z);
        //transform.Translate(PlayerMovement);
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            directionY = Jump;
        }
        
        directionY -= gravity * Time.deltaTime;
        PlayerMovement.y = directionY;
        cc.Move(PlayerMovement * speed * Time.deltaTime);

        if (transform.position.y < -50)
        {
            death();
        }
    }
    void death()
    {
        transform.position = new Vector3(0, 100, 0);     
    }
}
