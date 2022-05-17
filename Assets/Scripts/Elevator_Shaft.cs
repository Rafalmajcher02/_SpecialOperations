using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Shaft : MonoBehaviour
{
    [Header("Elevator Settings")]
    [Range(1, 8)]
    public int elevatorNumber = 1;
    private int floorY = 0;


    [Header("Drags")]
    public GameObject panel;
    public GameObject player;

    public virtual void ElevatorButtonAdjuster()
    {
        //Turn children on
        for (int i = 0; i < elevatorNumber; i++)
        {
            panel.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void OnClick()
    {
        Vector2 playerLocation = new Vector2(player.transform.position.x, floorY);
        player.transform.SetPositionAndRotation(playerLocation, player.transform.rotation);
    }
    public void click1()
    {
        floorY = 1 * 5;
    }
    public void click2()
    {
        floorY = 2 * 5;
    }
}
