using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    private SpriteRenderer sprite;
    private UnityEngine.Object explosionRef;
    private float dazedTime;
    public float startDazedTime;
    private Enemy_IA enemyIA;
    public Transform moeda;
    public Rigidbody2D rb;

    //private AudioSource soundFx;
    public AudioSource dmg;



    void Awake()
    {
        enemyIA = GetComponent<Enemy_IA>();
        sprite = GetComponent<SpriteRenderer>();
       // soundFx = GetComponent<AudioSource>();
       // soundFx.Play();
       // rb = GetComponent<moeda>(Rigidbody2D);
    }

    void Start()
    {
        currentHealth = maxHealth;
        explosionRef = Resources.Load("Explosion");
    }

    private void Update() 
    {
        if(dazedTime <= 0 && enemyIA.inRange == true)
        {
            enemyIA.moveSpeed = 2.5f;
        }
        else if(dazedTime <= 0 && enemyIA.inRange == false)
        {
            enemyIA.moveSpeed = 1f;
        }
        else
        {
            enemyIA.moveSpeed = 0f;
            dazedTime -= Time.deltaTime;
        }
    }

    IEnumerator Damage()
    {
        dmg.Play();
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;
    }

    public void TakeDamage(int damage)
    {
        //rb.AddForce(new Vector2(0, 100f));
        dazedTime = startDazedTime;
        currentHealth -= damage;
        StartCoroutine(Damage());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        //soundFx.Stop();
        Destroy(gameObject);
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        int number = Random.Range(0, 50);
        Debug.Log(number);
        if( number >= 25 )
        {
            float n1 = Random.Range(0f, 0.5f);
            //float n2 = Random.Range(0f, 0.5f);
            Instantiate(moeda, new Vector2(transform.position.x + n1, transform.position.y ), Quaternion.identity);
            //Instantiate(moeda, new Vector2(transform.position.x - n2, transform.position.y - 0.8f), Quaternion.identity);
            //rb.AddForce(new Vector2(1f, 2f));
        }
    }
}
