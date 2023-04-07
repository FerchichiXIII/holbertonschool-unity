using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float Jump = 5f;
    public CharacterController cc;
    public GameObject player;
    public Text timerText;
    private float directionY;
    private float gravity = 9.0f;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject Noob;
    public Animator anim;

    
    private void Awake()
    {
        /*if (PauseMenu.opts)
        {
            player.transform.position = new Vector3(PauseMenu.playerPos.x, PauseMenu.playerPos.y, PauseMenu.playerPos.z);
            PauseMenu.opts = false;
        }*/
    }


    void Start()
    {
        cc = GetComponent<CharacterController>();
        transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(x, 0, z);
   

        if (moveDirection.magnitude > 0)
        {
            anim.SetBool("Run", true);
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }   
        else
        {
            anim.SetBool("Run", false);
        }
            //transform.Translate(PlayerMovement);
            if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            directionY = Jump;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }
        
        directionY -= gravity * Time.deltaTime;
        moveDirection.y = directionY;
        cc.Move(moveDirection * speed *Time.deltaTime);
       

        if (transform.position.y < -50)
        {
            death();
        }
        if (Input.GetKey(KeyCode.N))
        {
            if (Input.GetKey(KeyCode.O))
            {
                if (Input.GetKey(KeyCode.O))
                {
                    if (Input.GetKey(KeyCode.B))
                    {
                        Noob.SetActive(true);
                    }
                }
            }
        }
    }

    void death()
    {
        transform.position = new Vector3(0, 100, 0);     
    }
    
    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PosX", transform.position.x);
        PlayerPrefs.SetFloat("PosY", transform.position.y);
        PlayerPrefs.SetFloat("PosZ", transform.position.z);
    }
}
