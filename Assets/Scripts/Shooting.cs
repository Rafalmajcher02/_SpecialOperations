﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //bools
    private bool saidMes;
    public bool canShoot;
    public bool safetySwitchBool = true;
    //floats
    public float shootsFired; //Will be send to other scrip
    public float bulletSpeed = 40000f; //Will be overwriten through inspector
    //other
    public PlayerStatistics playerStatistics;
    public AudioSource ausioSource;
    public GameObject bullet;
    public Transform firePoint;
    public AudioClip[] shootSoundEffects;
    //safety swtich settings
    public int safetyMode = 0;

    private void Start()
    {         
        //Getting components
        playerStatistics = GetComponent<PlayerStatistics>();
        ausioSource = GetComponent<AudioSource>();

        //Statistics
        shootsFired = playerStatistics.PlayerShootsDone; 
    }
    private void Update()
    {
        //Checking if more than 0 ammo
        //Positive

        //Toggle Safety Switch
        if (Input.GetButtonDown("SafetySwitch"))
        {
            safetySwitchBool = !safetySwitchBool;
            SafetySwitch();
        }
        //Shooting and checking for bools
        if (safetyMode == 1)
        {
            if (Input.GetButtonDown("Fire1") && playerStatistics.PlayerAmmo > 0)
            {
                Shoot();
            }
            if (Input.GetButtonDown("Fire1") && 0 >= playerStatistics.PlayerAmmo)
            {
                Debug.Log("No ammo");
            }
        }
        if (safetyMode == 2)
        {
            if (Input.GetButton("Fire1") && playerStatistics.PlayerAmmo > 0)
            {
                Shoot();
            }
            if (Input.GetButton("Fire1") && 0 >= playerStatistics.PlayerAmmo)
            {
                Debug.Log("No ammo");
            }
        }
    }
    /// <summary>
    /// This method allows player to shoot
    /// It is done by instantiating a bullet and destroying it after time
    /// This method also plays random shooting sound from an array with randomised variables
    /// </summary>
    private void Shoot()
    {
        //Statistics
        playerStatistics.PlayerAmmo -= 1f;
        shootsFired += 1f;   

        //Creates and starts the bullet
        GameObject tempBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.right * bulletSpeed * Time.deltaTime);
        //Destroys bullet after 40s
        Destroy(tempBullet, 40f);


        //Randomises sounds settings
        int randomiser = UnityEngine.Random.Range(0, shootSoundEffects.Length); //Random sounds clip from array
        float volRandomiser = UnityEngine.Random.Range(0.90f, 1.80f); //Random volume
        //Play sound
        ausioSource.PlayOneShot(shootSoundEffects[randomiser], volRandomiser);
        ausioSource.pitch = 1f;
    }
    private void SafetySwitch()
    {
        //Switches from Safety to Semi
        if (safetyMode == 0)
        {
            safetyMode = 1;
            Debug.Log(safetyMode);
        }
        //Switches from Semi to Auto
        else if (safetyMode == 1)
        {
            safetyMode = 2;
            Debug.Log(safetyMode);
                     
        }
        //Switches from Auto to Safety
        else if(safetyMode == 2)
        {
            safetyMode = 0;
            Debug.Log(safetyMode);
        }

    }
}
