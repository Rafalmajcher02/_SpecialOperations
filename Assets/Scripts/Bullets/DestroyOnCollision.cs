using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string avoidTag = "Player";

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != avoidTag && collision.gameObject)
        {
            Destroy(this.gameObject);
        }
    }

}
