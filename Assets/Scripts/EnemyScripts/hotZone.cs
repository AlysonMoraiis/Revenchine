using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotZone : MonoBehaviour
{
    private Enemy_IA enemyParent;
    public bool inRange;
    private Animator anim;

    private void Awake() 
    {
        enemyParent = GetComponentInParent<Enemy_IA>();
        anim = GetComponentInParent<Animator>();    
    }

    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            enemyParent.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            inRange = true;
            anim.SetBool("Puto", true);
            enemyParent.moveSpeed = 2.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            anim.SetBool("Puto", false);
            enemyParent.moveSpeed = 1;
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
        }
    }

}
