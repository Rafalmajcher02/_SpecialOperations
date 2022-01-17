using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Master : MonoBehaviour
{
    public GameObject elevatorShaft;
    public GameObject[] elevatorFloors;
    public int floorCount;
    // Start is called before the first frame update
    void Start()
    {
        floorCount = elevatorFloors.Length;
        Debug.Log(floorCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
