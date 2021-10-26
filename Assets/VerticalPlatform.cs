using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    // private PlatformEffector2D effector;
    // public float waitTime;
    public bool coll;
    public PlatformEffector2D platform;


     private void Start() 
    {
    //     effector = GetComponent<PlatformEffector2D>();
    }

     private void Update()
    {
        if (coll && Input.GetKey(KeyCode.DownArrow))
        {
            platform.surfaceArc = 0f;
            StartCoroutine(Wait());
        }
        //     if(Input.GetKeyUp(KeyCode.DownArrow))
        //     {
        //         waitTime = 0.5f;
        //     }

        //     if(Input.GetKey(KeyCode.DownArrow))
        //     {
        //         if(waitTime <= 0)
        //         {
        //             effector.rotationalOffset = 180f;
        //             waitTime = 0.5f;
        //         } 
        //         else
        //         {
        //             waitTime -= Time.deltaTime;
        //         }
        //     }

        //     if(Input.GetKey(KeyCode.UpArrow))
        //     {
        //         effector.rotationalOffset = 0;
        //     }
        }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        coll = true;
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        coll = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.6f);
        platform.surfaceArc = 125f;
    }

}