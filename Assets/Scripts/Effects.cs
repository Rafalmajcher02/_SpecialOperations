using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effects : MonoBehaviour
{
    //floats
    public float EnemyDamage = 30f;
    public float BulletDamage2Player = 20f;
    public float addAmmo = 30f;
    //strings
    private string Table = "Table";
    private string Star = "Star";
    private string Enemy = "Enemy";
    private string Civ = "Civilian";
    private string Vip = "VIP";
    private string Bullet = "Bullet";
    private string Ammo = "Ammo";
    //other
    private PlayerStatistics PS;   
    void Start()
    {
        PS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatistics>();     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == Star)
        {
            PS.StarsCollected += 1;
            Debug.Log("Star Collected");
            Debug.Log("Stars: " + PS.StarsCollected);
        }         
       if (collision.gameObject.tag == Civ)
        {
            PS.CivilliansCollected += 1;
            Debug.Log("Civilian Collected!");
            Debug.Log("Civilians: " + PS.CivilliansCollected);
        }
       if (collision.gameObject.tag == Vip)
        {
            PS.VIPsCollected += 1;
            Debug.Log("VIP Collected!");
            Debug.Log("VIPs: " + PS.VIPsCollected);
        }
        if (collision.gameObject.tag == Ammo)
        {
            PS.PlayerAmmo += addAmmo;
            Debug.Log("You got " + addAmmo + " more ammo!");
            Debug.Log("Total Ammo: " + PS.PlayerAmmo);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Bullet)
        {
            PS.PlayerHealth -= BulletDamage2Player;
            Debug.Log("You have been shot!");
            Debug.Log("Health: " + PS.PlayerHealth);
            
        }
        if (collision.gameObject.tag == Enemy)
        {
            PS.PlayerHealth -= EnemyDamage;
            
            Debug.Log("Taken damage from enemy");
            Debug.Log("Health: " + PS.PlayerHealth);
        }
    }
}
