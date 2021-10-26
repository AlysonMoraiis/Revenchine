using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMove : MonoBehaviour
{   
    float currCountdownValue;
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;

    private Player player;

    private bool aaa = true;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        transform.position = waypoints [waypointIndex].transform.position;
    }

    void Update () 
    {
        Move ();
    }

    void Move()
    {
        //if (player.isAlive)
        //{
            
            transform.position = Vector3.MoveTowards (transform.position, waypoints[waypointIndex].transform.position,moveSpeed * Time.deltaTime);
            if (aaa == true)
            {
                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }
                    
                if (waypointIndex == waypoints.Length)
                {   
                    waypointIndex = 0;
                    aaa = false;
                    StartCoroutine(Timerr(2));
                }
            //}
           
        
        }
    

        IEnumerator Timerr(float a)
        {   
            yield return new WaitForSeconds(a);
            aaa = true;
        }
    }
}
