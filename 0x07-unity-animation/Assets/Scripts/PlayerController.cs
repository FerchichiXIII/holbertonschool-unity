
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    private float Jump = 3f;
    public CharacterController cc;
    public GameObject player;
    public Text timerText;
    private float directionY;
    private float gravity = 9.8f;
    //private Vector3 moveDirection = Vector3.zero;
    public GameObject Noob;
    //public Animator anim;
    //public GameObject _cam;
    //public GameObject Ty;
    public Transform cameraTransform;
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
        //anim = this.transform.GetChild(1).GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        moveDirection.y = 0;

        if (moveDirection.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
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
        cc.Move(moveDirection * speed * Time.deltaTime);
        /* if (!cc.isGrounded && transform.position.y < -50)
         {
             anim.SetBool("Falling", true);
             anim.SetBool("FallingToImpact", false);
         }
         else if (cc.isGrounded)
         {
             anim.SetBool("Falling", false);
             anim.SetBool("FallingToImpact", true);
             yield return new WaitForSeconds(3f);
             anim.SetBool("FallingToImpact", false);
             anim.SetBool("ImpactToGettingUp", true);
             cc.radius = 0.39f;
             cc.height = 2.29f;


         }
         else
             anim.SetBool("ImpactToGettingUp", false);
        */



        if (transform.position.y < -10)
        {
            death();
        }
        if (Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.B))
        {
            Noob.SetActive(true);
        }
    }

    void death()
    {
        transform.position = new Vector3(0, 250, 0);
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PosX", transform.position.x);
        PlayerPrefs.SetFloat("PosY", transform.position.y);
        PlayerPrefs.SetFloat("PosZ", transform.position.z);
    }

}
