﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUniversalCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
