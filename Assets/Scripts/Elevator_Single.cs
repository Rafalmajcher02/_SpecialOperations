using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Single : MonoBehaviour
{
    public GameObject elevatorPanel;
    public GameObject elevatorShaft;
    public Elevator_Shaft es;

    public void Start()
    {
        es = transform.GetComponentInParent<Elevator_Shaft>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            elevatorPanel.SetActive(true);
            es.ElevatorButtonAdjuster();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Turns off children
        for (int i = 0; i < elevatorPanel.transform.childCount; i++)
        {
            elevatorPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
