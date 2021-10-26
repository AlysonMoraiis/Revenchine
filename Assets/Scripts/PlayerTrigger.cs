using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private Player player;
    private TimeStop hitstop;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        hitstop = GetComponentInParent<TimeStop>();
    }


   
    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!player.invunerable)
            {
                player.DamagePlayer();     
            }
        }
    }
    */
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {

             if (!player.invunerable && player.isAlive)
            {
                player.DamagePlayer();
                hitstop.StopTime(0.05f, 10, 0.2f);
            }
        }
    }
}
