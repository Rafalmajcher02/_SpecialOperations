using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //Variable Integers and Floats
    public float rotationSpeed = 5f; 

    //Strings
    private string bS = "Bullet";

    //GameObjects + Scripts
    public GameObject Target;
    public PlayerStatistics PS;
    public GameObject Pla;

    //Shooting
    public float bulletSpeed = 100f;
    public GameObject Bullet;
    public Transform firePoint;
    public float RangeShooting = 6f;

    //fire rate
    private float time;
    public float FireRate = 3;



    private void Start()
    {
        PS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatistics>();
        Pla = GameObject.FindGameObjectWithTag("Player");        
    }

    void FixedUpdate()
    {
        //Colonials and Invaders
        Vector2 direction = Target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //getting tan of y and x from camera and getting some unity manual stuff to calculate tangent by using two sides of triangle calculating an missing angle
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); //conveting the angle and vector 3 into quaternion so  ican use transform rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime); //rotating object with the speed applied. 
        

        //Native Locals
        GameObject EnemyGun = GameObject.Find("EnemyGun");
        Transform GunT = EnemyGun.GetComponent<Transform>();

        //Calculating the distance
        Vector3 playerDistance = (Pla.transform.position - transform.position);
        

        float RangeX = playerDistance.x;
        float RangeY = playerDistance.y;

        if (RangeX < RangeShooting && RangeY < RangeShooting && Time.time >= time)
        {
            time = Time.time + FireRate;
            AIShootAtPlayer();
        }
        
    }

    private void AIShootAtPlayer()
    {
        Debug.Log("Shoot fired! (AI)");
        GameObject tempBullet = Instantiate(Bullet, firePoint.position, firePoint.rotation);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.right * bulletSpeed * Time.deltaTime);
        Destroy(tempBullet, 20f);
    }
}
