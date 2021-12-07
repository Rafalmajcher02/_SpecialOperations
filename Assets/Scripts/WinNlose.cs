using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinNlose : MonoBehaviour
{
    //arrays
    public GameObject[] EnemiesInLevel;
    public GameObject[] VIPsInLevel;
    //floats
    private float PlayerHealth = 1f;
    private float vips2collect;
    //other
    private PlayerStatistics PS;
    public GameObject GameOver;
    public GameObject LevelComplete;
    void Start()
    {
        PS = GetComponent<PlayerStatistics>();
        VIPsInLevel = GameObject.FindGameObjectsWithTag("VIP");
        EnemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy");
        
        LevelComplete.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);

        vips2collect = VIPsInLevel.Length;
    }
 
    void Update()
    {
        if (PlayerHealth <= 0) //checks for health
        {
            StartCoroutine(LoadAfterDeley());
            GameOver.gameObject.SetActive(true);
        }
        PlayerHealth = PS.PlayerHealth; 

        if (vips2collect == PS.VIPsCollected) //checks for vips
        {
            StartCoroutine(LoadAfterDeley());
            LevelComplete.gameObject.SetActive(true);
        }

        VIPsInLevel = GameObject.FindGameObjectsWithTag("VIP");
        if (EnemiesInLevel.Length <= 0) //checks for enemies
        {
            StartCoroutine(LoadAfterDeley());
            LevelComplete.gameObject.SetActive(true);
        }
        EnemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy");


    }

    private IEnumerator LoadAfterDeley() //restarts current scene after set seconds
    {
        yield return new WaitForSeconds(2f);
        LoadLevel(SceneManager.GetActiveScene().name);
    }

    private void LoadLevel(string LevelName) //gets current scene name
    {
        SceneManager.LoadScene(LevelName);
    }
}

