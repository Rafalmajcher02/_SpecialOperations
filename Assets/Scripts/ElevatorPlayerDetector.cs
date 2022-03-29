using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlayerDetector : MonoBehaviour
{
    public GameObject self;
    public string Player = "Player";
    public string index;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Player)
        {
            if (Input.GetButton("Interact Button"))
            {
                Debug.Log("Intered Elevator");
            }
            index = self.name;
            Debug.Log(index);
        }
    }
}
