using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathtoAI : MonoBehaviour
{
    public string bS = "PBullet";
    public PlayerStatistics PS;

    private void Start()
    {
        PS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatistics>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == bS)
        {
            Destroy(this.gameObject);
            PS.EnemyKills += 1;
            Debug.Log(PS.EnemyKills);
        }
    }
}
