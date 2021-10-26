using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Caixa : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    private Vector2 moveDirection;
    private bool podeMover;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    

    private void Update() {
        Inputs();
        ChangeControll();
        

        if(moveDirection.x != 0)
        {
            moveDirection.y = 0;
        }
        else if(moveDirection.y != 0)
        {
            moveDirection.x = 0;
        }
    }

    private void FixedUpdate() {
        Move();
    }

    private void ChangeControll()
    {
        if(Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
    }

    private IEnumerator WaitMove()
    {
        yield return new WaitForSeconds(1);

    } 

    void Inputs()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        rb2d.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
}
