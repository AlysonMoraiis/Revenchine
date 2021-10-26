using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float velocidade;

    void Update()
    {
        rb2d.velocity = new Vector2(velocidade, 0);
    }
}
