using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Master : MonoBehaviour
{
    public GameObject[] floors;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Entered");
        }
    }


}
