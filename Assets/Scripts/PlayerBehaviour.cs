using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public MouseLook mouseLook;
    public GameObject restartPanel;

    public AudioSource steps;

    public bool isMoving;
    public bool secAttackDisp;
    public bool allowed;

    public TextMeshProUGUI secAttack;
    public TextMeshProUGUI secAttackValue;
    public TextMeshProUGUI healthTxt;
    public Slider healthSlider;

    public static PlayerBehaviour instance;

    public int damage;

    public float secAttackTime;
    float iniSecAttackTime;

    public bool attacking = false;
    public bool attackingSec = false;
    public bool canSec = false;

    public Animator swordController;
    
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public int maxHealth = 100;
    public int curHealth;

    public Transform groundCheck;
    public float groundDist = .4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        iniSecAttackTime = secAttackTime;
        curHealth = maxHealth;
        healthTxt.text = "" + curHealth;
        healthSlider.value = curHealth;
        
    }

    


    // Update is called once per frame
    void Update()
    {
        if(curHealth <= 0)
        {
            restartPanel.SetActive(true);
            this.GetComponent<PlayerBehaviour>().enabled = false;
            mouseLook.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            healthSlider.enabled = false;
            healthTxt.enabled = false;
            
        }


        if (secAttackDisp)
        {
            secAttack.enabled = true;
            secAttackValue.enabled = true;
            secAttackDisp = false;
        }
        if(secAttackTime > 0)
        {
            canSec = false;
            secAttackTime -= Time.deltaTime;
            secAttackValue.text = secAttackTime.ToString("F2");
            secAttackValue.color = Color.white;
            secAttack.color = Color.red;
        }
        else
        {
            canSec=true;
            secAttackTime = 0;
            secAttack.color = Color.green;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if(isGrounded && velocity.y < 0 )
        {
            velocity.y = -2f;
        }

        
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(x !=0 || z !=0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(isMoving && !steps.isPlaying)
        {
            steps.Play();
            
        }
        if (!isMoving)
        {
            steps.Stop();
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2f);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (allowed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swordController.SetBool("Attack", true);
                swordController.SetBool("AttackSec", false);
                attackingSec = false;
                attacking = true;
            }
            else if (Input.GetMouseButtonDown(1) && canSec)
            {
                swordController.SetBool("Attack", false);
                swordController.SetBool("AttackSec", true);
                secAttackTime = iniSecAttackTime;
                canSec = false;
                attackingSec = true;
                attacking = false;
            }
            else
            {
                swordController.SetBool("Attack", false);
                swordController.SetBool("AttackSec", false);
                attackingSec = false;
                attacking = false;
            }
        }

    }

    public void DecreaseHealth(int damage)
    {
        curHealth -= damage;
        healthTxt.text = "" + curHealth;
        healthSlider.value = curHealth;
        Debug.Log(curHealth);
    }
}
