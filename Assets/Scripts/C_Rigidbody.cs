using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Rigidbody : MonoBehaviour
{
    protected Rigidbody2D rigid2D;
    public virtual void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
}
