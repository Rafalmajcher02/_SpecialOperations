using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //bools
    private bool saidMes;
    public bool canShoot;
    public bool safetySwitch = true;
    //floats
    public float shootsFired; //Will be send to other scrip
    public float bulletSpeed = 40000f; //Will be overwritte through inspector
    //other
    public PlayerStatistics playerStatistics;
    public AudioSource ausioSource;
    public GameObject bullet;
    public Transform firePoint;
    public AudioClip[] shootSoundEffects; 

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
        if (Input.GetButtonDown("FireAllowed"))
        {
            safetySwitch = !safetySwitch;            
        }
        //Shooting and checking for bools
        if (!safetySwitch)
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
}
