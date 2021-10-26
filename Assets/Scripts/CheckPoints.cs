using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private GameMaster gm;
    public Animator anim;
    
    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
           // anim.Play("CheckPoint");
            gm.lastCheckPointPos = transform.position;
        }
    }
}
