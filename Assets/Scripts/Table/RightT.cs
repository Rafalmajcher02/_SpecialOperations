using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightT : MonoBehaviour
{
    public bool playerDecRi;
    private string triggerName = "Player";
    void Start()
    {
        playerDecRi = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == triggerName)
        {
            playerDecRi = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == triggerName)
        {
            playerDecRi = false;
        }
    }
}
