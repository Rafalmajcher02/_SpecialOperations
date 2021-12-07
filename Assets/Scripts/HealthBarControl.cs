using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour
{
    private PlayerStatistics PS;
    //UI
    public Image HealthBar;
    private float healthTemp;

    private void Awake()
    {
        PS = GetComponent<PlayerStatistics>();
        healthTemp = PS.PlayerHealth;        
    }
    private void Update()
    {
        float healthCal = PS.PlayerHealth/healthTemp;
        HealthBar.fillAmount = healthCal;
    }
}
