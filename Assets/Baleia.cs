using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baleia : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float velocidade;

    void Update()
    {
        rb2d.velocity = new Vector2(velocidade, 0);
    }

    private void OnTriggerEnter2D(Collider2D col2D) {
        if (col2D.gameObject.CompareTag("FinalTela")){
            Destroy(gameObject);
        }
    }
}
