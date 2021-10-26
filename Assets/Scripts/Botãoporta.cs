using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botãoporta : MonoBehaviour
{
    private bool inRange;
    private porta porta;

    public Animator anim;

    void Start()
    {
        //porta = GameObject.FindGameObjectWithTag("Porta").GetComponent<porta>();
    }


    void Update()
    {
        if (inRange == true && Input.GetKey(KeyCode.E))
        {

            anim.Play("Porta");
            //porta.GetComponent<porta>().Move();
           // porta.Move();
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("Tá no range");
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
