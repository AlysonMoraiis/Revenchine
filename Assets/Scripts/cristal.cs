using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cristal : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Transform moeda;
    private SpriteRenderer sprite;



    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
       // rb = GetComponent<moeda>(Rigidbody2D);
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    IEnumerator Damage()
    {
        sprite.color = Color.gray;
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(Damage());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Cristal destruido");
        Destroy(gameObject);
        int number = Random.Range(0, 50);
        Debug.Log(number);
        if( number >= 25 )
        {
            float n1 = Random.Range(0f, 0.5f);
            float n2 = Random.Range(0f, 0.5f);
            Instantiate(moeda, new Vector2(transform.position.x + n1, transform.position.y ), Quaternion.identity);
            Instantiate(moeda, new Vector2(transform.position.x - n2, transform.position.y - 0.8f), Quaternion.identity);

        }
    }
}

