using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitstop_Call : MonoBehaviour
{
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            collision.gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.2f);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Bateu");
            collision.gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.2f);
        }
    }
}
