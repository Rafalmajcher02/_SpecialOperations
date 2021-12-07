using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftT : MonoBehaviour
{
    public bool playerDecLe;
    private string triggerName = "Player";
    void Start()
    {
        playerDecLe = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == triggerName)
        {
            playerDecLe = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == triggerName)
        {
            playerDecLe = false;
        }
    }
}
