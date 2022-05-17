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
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

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
    public void IndexGenerator(int index)
    {
        floorY = index * 5;
    }
}
