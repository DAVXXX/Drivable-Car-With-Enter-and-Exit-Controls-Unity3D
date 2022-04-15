using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FirstPersonController : MonoBehaviour


{
    public CharacterController controller;

    Vector3 veclocity;

    Vector3 pushDirection;

    public float gravity = -9.81f;
    public float speed = 7.5f;
    public float walkSpeed = 7.5f;
    public float runSpeed = 14f;
    public float jumpHeight = 3f;
    public float groundDist = 0.4f;
    public float totaltime = 0;


    public float knockbackSpeed;


    public int maxHealth = 100;
    public int currentHealth;

    public Rigidbody playerRigidbody;

    //public HealthBar healthBar;

    public Transform goundCheck;
    public LayerMask groundMask;


    public GameObject CleanAir;
    public GameObject Wheel;


    public Camera FPScam;

    protected Drive drive;
    protected SkinnedMeshRenderer Renderer;
    

    public bool isWalking = true;
    public bool isRunning = false;
    bool isGrounded;
    public bool inObject = false;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inObject == false)
        {
            isGrounded = Physics.CheckSphere(goundCheck.position, groundDist, groundMask);

            if (isGrounded && veclocity.y < 0)
            {
                veclocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");



            Vector3 move = transform.right * x + transform.forward * z;


            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                veclocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                Debug.Log("Jumped");


            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
                speed = runSpeed;
            }
            else
            {
                isRunning = false;
                speed = walkSpeed;

            }

            veclocity.y += gravity * Time.deltaTime;

            controller.Move(veclocity * Time.deltaTime);
        }

        


        float distance = Vector3.Distance(playerRigidbody.transform.position, Wheel.transform.position);

        if (distance <= 2)
        {
          if (Input.GetKeyDown(KeyCode.E))
            {
                //drive.Engaged = true;
                
            } 
                


        }


    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            Debug.Log("knocback");

            playerRigidbody = GetComponent<Rigidbody>();

            pushDirection = Vector3.back * knockbackSpeed;
            playerRigidbody.AddForce(pushDirection * 100);
            TakeDamage(10);

        }

    }
    private void OnTriggerStay(Collider other)
    {
        totaltime += Time.deltaTime;
        if (totaltime > 1)
        {
            TakeDamage(1);
            totaltime = 0;
        }


        //TakeDamage(1);
    }


   




}
