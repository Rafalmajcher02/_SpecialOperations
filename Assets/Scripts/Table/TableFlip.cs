using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFlip : MonoBehaviour
{
    public bool playerDec;
    public LeftT LeftT;
    public RightT RightT;
    private string Player = "Player";
    private GameObject TableP;
    private Rigidbody2D rb2;
    public bool notFlipped;
    public bool playerDecRi;
    public bool playerDecLe;
    public bool playerToTheRight;
    public bool playerToTHeLeft;
    

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();    
        playerDec = false;
        notFlipped = true;
        playerToTheRight = false;
        playerToTHeLeft = false;
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E) && playerToTheRight && notFlipped)
        {
            transform.Rotate(0, 0, 90);
            notFlipped = false;
        }
        if (Input.GetKey(KeyCode.E) && playerToTHeLeft && notFlipped)
        {
            transform.Rotate(0, 0, -90);
            notFlipped = false;
        }
        if (RightT.playerDecRi)
        {
            playerToTheRight = true;
        }
        if (!RightT.playerDecRi)
        {
            playerToTheRight = false;
        }
        if (LeftT.playerDecLe)
        {
            playerToTHeLeft = true;
        }
        if (!LeftT.playerDecLe)
        {
            playerToTHeLeft = false;
        }
    }
}
