using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class TextController : MonoBehaviour
{
    //Text
    public TextMeshProUGUI ammo;
    public TextMeshProUGUI Civs;
    public TextMeshProUGUI VIP;
    public TextMeshProUGUI Enemy;
    public TextMeshProUGUI Star;
    public TextMeshProUGUI shootMode;
    //Other
    private PlayerStatistics PS;
    //Statistics
    private float ammoD;
    public GameObject[] civs;
    public GameObject[] vips;
    public GameObject[] ene;
    public GameObject[] star;
    public string shoot;
    //DoneStatistics
    private float civsD;
    private float vipsD;
    private float eneD;
    private float starD;



    void Start()
    {
        PS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatistics>();
        ammoD = PS.PlayerAmmo; //First Number
        civsD = PS.CivilliansCollected;
        vipsD = PS.VIPsCollected;
        eneD = PS.EnemyKills;
        starD = PS.StarsCollected;
        shoot = PS.ShootingMode;
        //Assign variable to game object
        civs = GameObject.FindGameObjectsWithTag("Civilian");
        vips = GameObject.FindGameObjectsWithTag("VIP");
        ene = GameObject.FindGameObjectsWithTag("Enemy");
        star = GameObject.FindGameObjectsWithTag("Star");
        
    }

    
    void Update()
    {
        //Ammo
        ammo.text = ("Ammo: " + ammoD); //Display
        ammoD = PS.PlayerAmmo; //Constant Update
        //Civs
        Civs.text = ("Civs: " + civsD + "/" + civs.Length);
        civsD = PS.CivilliansCollected;
        //VIPs
        VIP.text = ("VIPs: " + vipsD + "/" + vips.Length);
        vipsD = PS.VIPsCollected;
        //Enemies
        Enemy.text = ("Enemies: " + eneD + "/" + ene.Length);
        eneD = PS.EnemyKills;
        //Stars
        Star.text = ("Stars: " + starD + "/" + star.Length);
        starD = PS.StarsCollected;
        //Shooting Mode
        shootMode.text = ("Shooting Mode: " + shoot);
        shoot = PS.ShootingMode;
    }
}
