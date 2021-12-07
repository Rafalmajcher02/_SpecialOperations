using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string triggerNamePIU = "Player";
    public string triggerNameBullet = "Bullet";
    public string triggerNamePBullet = "PBullet";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == triggerNamePIU || collision.gameObject.tag == triggerNamePBullet)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == triggerNamePIU)
        {
            Destroy(this.gameObject);
        }
    }
}
