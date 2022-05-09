using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Shaft : MonoBehaviour
{
    [Header("Elevator Settings")]
    [Range(1, 8)]
    public int elevatorNumber = 1;

    [Header("Drags")]
    public GameObject panel;

    public virtual void ElevatorButtonAdjuster()
    {
        //Turn children on
        for (int i = 0; i < elevatorNumber; i++)
        {
            panel.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
