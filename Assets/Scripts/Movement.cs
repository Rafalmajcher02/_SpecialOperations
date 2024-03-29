﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : C_Rigidbody
{
    //extractions
    public PlayerStatistics PS;
    //floats
    private float MovementSpeed;
    private float JumpForce;
    //bools
    public bool CanJump;
    public bool isElevator;
    public bool isPlayingSound;
    public bool isPause;
    public bool insideElevator;
    //strings
    public string triggerName = "Ground";
    public string Elevator = "Elevator";
    //audio
    private AudioSource audioS;
    public AudioClip[] walkSteps;
    //corutine
    private IEnumerator coroutine;
    //UI
    public GameObject Pause;

    void Start()
    {
        //extractions
        audioS = GetComponent<AudioSource>();
        MovementSpeed = PS.PlayerSpeed;
        JumpForce = PS.PlayerJumpForce;
        //bools
        CanJump = false;
        isElevator = false;
        isPause = false;
        insideElevator = false;
    }
    private void Update()
    {
        if (isElevator)
        {
            ElevatorMovement();
            movement();
        }
        if (!isElevator)
        {
            movement();
        }
        if (rigid2D.velocity.x != 0 && !isPlayingSound)
        {
            StepSound();
            isPlayingSound = false;
        }
        if (rigid2D.velocity.x == 0)
        {
            audioS.Stop();
        }
        isPlayingSound = audioS.isPlaying;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
        if (isPause)
        {
            Pause.SetActive(true);
            Time.timeScale = 0.000000001f;
        }
        if (!isPause)
        {
            Pause.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
    
    //Elevator
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Elevator)
        {
            isElevator = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Elevator)
        {
            isElevator = false;
        }
    }


    //Jumping
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == triggerName)
        {
            CanJump = true;
        }
    }

    //Movement Methods
    private void movement()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1; //resets gravity
        if (Input.GetButton("Jump") && CanJump) //if jump conditions
        {
            rigid2D.AddForce(transform.up * JumpForce, ForceMode2D.Impulse); //jump by adding force up on impulse
            CanJump = false; //resets jump
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid2D.AddForce(transform.right * MovementSpeed); //moves right                                            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid2D.AddForce(transform.right * -MovementSpeed); //movs left             
        }

    }

    private void ElevatorMovement()
    {
        Vector3 jumpUpVectorY = new Vector3(0, 5f, 0);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Input.GetKeyDown(KeyCode.W) && rigid2D.position.y < 14f) //teleports up on elevator
            {
                transform.position += jumpUpVectorY;
            }
            if (Input.GetKeyDown(KeyCode.S) && rigid2D.position.y > -0f) //teleports down on elevator
            {
                transform.position -= jumpUpVectorY;
            }
        }

    }

    //Audio

    private void StepSound()//Activated by animation event, causing sound on steps when walking
    {
        audioS.pitch = UnityEngine.Random.Range(0.75f, 1.15f);//generates random pitch
        float randomVal = UnityEngine.Random.Range(0.5f, 1f);//generates random valume
        int randomiser = UnityEngine.Random.Range(0, walkSteps.Length); //generates random sound int
        audioS.PlayOneShot(walkSteps[randomiser]);//chooses random sound with random volume and pitch
    }

    public void stupid()
    {
        isPause = false;
    }
}