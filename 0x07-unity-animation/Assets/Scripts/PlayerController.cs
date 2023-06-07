
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
    private float gravity = 9.8f;
    //private Vector3 moveDirection = Vector3.zero;
    public GameObject Noob;
    public Animator anim;
    public GameObject _cam;
    //public GameObject Ty;


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
        anim = this.transform.GetChild(1).GetComponent<Animator>();
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
            anim.SetBool("Jump", true);
            directionY = Jump;
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
            anim.SetBool("ImpactToGettingUp", false);*/



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
        _cam.transform.parent = this.transform;
        transform.position = new Vector3(0, 250, 0);
        //cc.radius = 0.4f;
        //cc.height = 0.4f;
        _Death();
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PosX", transform.position.x);
        PlayerPrefs.SetFloat("PosY", transform.position.y);
        PlayerPrefs.SetFloat("PosZ", transform.position.z);
    }


    void _Death()
    {
        anim.SetBool("Falling", true);
         StartCoroutine(Wait());
        //cc.enabled = false;
        //this.AddComponent<Rigidbody>();
        /*this.GetComponent<Rigidbody>().mass=100;
        this.AddComponent<CapsuleCollider>();
        this.GetComponent<CapsuleCollider>().isTrigger = true;
        this.GetComponent<CapsuleCollider>().height = 2.2f;*/
    }


   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "floor")
        {
            //anim.SetBool("FallingToImpact", true);
            anim.SetBool("Falling", false);
            //this.GetComponent<Rigidbody>().isKinematic=true;
           // this.transform.position = new Vector3(0,-0.8f,0);    
        }
    }

    IEnumerator Wait()
    {
        
        WaitForSeconds xx = new WaitForSeconds(2);
        yield return xx;
        anim.SetBool("Falling", false);
        _cam.transform.parent = null;
        GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(8);
        GetComponent<PlayerController>().enabled = true;

    }
}