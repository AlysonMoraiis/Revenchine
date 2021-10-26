using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public float waiting;
    public bool down;
    public bool space;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
           StartCoroutine(FallTimer());
        }
    }

    IEnumerator FallTimer()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(waiting);
        GetComponent<BoxCollider2D>().enabled = true;
        space = true;
        down = false;

    }
}
