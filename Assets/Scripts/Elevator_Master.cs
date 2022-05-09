using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Master : MonoBehaviour
{
    public GameObject elevatorPanel;
    public GameObject elevatorShaft;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            elevatorPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        elevatorPanel.SetActive(false);
    }


}
