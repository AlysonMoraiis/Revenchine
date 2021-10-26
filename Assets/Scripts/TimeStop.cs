using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    private float speed;
    private bool restoreTime;
    public GameObject ImpactEffects;
    private Animator anim;
    private Player player;
    private bool pode;

    private void Start()
    {
        restoreTime = false;
        anim = GetComponentInChildren<Animator>();
    }


    private void Update()
    {   
        if(restoreTime)
        {
            if(Time.timeScale < 1f)
            {
                Time.timeScale += Time.deltaTime * speed;
            }
            else
            {
                Time.timeScale = 1f;
                restoreTime = false;
                anim.SetBool("Hurt", false);
            }
        }
    }
    

    public void StopTime(float changeTime, int restoreSpeed, float delay)
    {
        
        speed = restoreSpeed;

        if (delay > 0)
        {
            StopCoroutine(StartTimeAgain(delay));
            StartCoroutine(StartTimeAgain(delay));
        }
        else
        {
            restoreTime = true;
        }
        
        Instantiate(ImpactEffects, transform.position, Quaternion.identity);
        anim.SetBool("Hurt", true);
        

        Time.timeScale = changeTime;
    }

    IEnumerator StartTimeAgain(float amt)
    {
        yield return new WaitForSecondsRealtime(amt);
        restoreTime = true;
    }
    
}
