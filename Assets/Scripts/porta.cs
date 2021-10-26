using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta : MonoBehaviour
{
     [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;

    public void Move()
    {
         transform.position = Vector3.MoveTowards (transform.position, waypoints[waypointIndex].transform.position,moveSpeed * Time.deltaTime);

                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }
                    
                if (waypointIndex == waypoints.Length)
                {   
                    waypointIndex = 0;
                }
        Debug.Log("Foi");
    }
}
