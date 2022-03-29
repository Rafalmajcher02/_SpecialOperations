using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public string Player = "Player";
    private void OnTriggerEnter2D(Collider2D poo)
    {
        if (poo.gameObject.tag == Player)
        {
            Debug.Log("We pooped");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }
    private void OnCollisionEnter2D(Collision2D poo)
    {

    }
}
