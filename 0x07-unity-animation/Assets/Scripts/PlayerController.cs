
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
    public GameObject _cam;
    //public GameObject Ty;
    public Transform cameraTransform;
    public Animator anim;
    private Vector3 NewPosY ;


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
        
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            directionY = Jump;
            anim.SetBool("Jump", true);
        }   
        else
        {
            anim.SetBool("Jump", false);
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

        if (transform.position.y <= -10)
        {
            death();
            anim.SetBool("Falling", true);
        }

      
        else if (cc.isGrounded)
        {
            anim.SetBool("Falling", false);
            Debug.Log("toheet !!!!");
        }
        if (Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.B))
        {
            Noob.SetActive(true);
        }
    }   

    void death()
    {
        Debug.Log("nik omek");
        _cam.transform.parent = this.transform;
        NewPosY = new Vector3(0 ,250f ,0 );
        transform.position = NewPosY;
        Debug.Log("mout asba!!!!!!!!!");
    }


    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PosX", transform.position.x);
        PlayerPrefs.SetFloat("PosY", transform.position.y);
        PlayerPrefs.SetFloat("PosZ", transform.position.z);
    }
}
