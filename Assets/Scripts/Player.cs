using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Animator anim;
    private SpriteRenderer sprite;

    public AudioSource dmgPlayerSound;

    [Header("Movement")]
    public float speed;
    public AudioSource soundFx;
    private bool isMoving;
    private PlayerJump PJump;

    [Header("Health & Coins")]
    public int health;
    public bool invunerable = false;
    public bool isAlive = true;

    public int moedas;
    public Text textMoedas;

    [Header("Attack")]
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public bool inAttack;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        inAttack = false;
        soundFx = GetComponent<AudioSource>();
        PJump = GetComponent<PlayerJump>();
        
    }

    void Update()
    {
        if(health > 5)
        {
            health = 5;
        }

        if (isAlive)
        {
            //ATK------------------------------
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    StartCoroutine(Countdown());
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
            //ATK------------------------------
        }

        if (rb2d.velocity.x != 0 && PJump.grounded == true)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving) 
        {
           if(!soundFx.isPlaying)
           soundFx.Play();
        }
        else 
           soundFx.Stop();
    }
    void FixedUpdate()
    {
        if (isAlive)
        {
            float move = Input.GetAxis("Horizontal");
          
            anim.SetFloat("Speed", Mathf.Abs(move));
            rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

            if ((move > 0f && sprite.flipX) || (move < 0f && !sprite.flipX))
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        if(inAttack == false)
        {
            sprite.flipX = !sprite.flipX;

            if (!sprite.flipX)
            {
                attackPoint.position = new Vector2(this.transform.position.x + 1.3f, attackPoint.position.y);   
            }
            else
            {
                attackPoint.position = new Vector2(this.transform.position.x - 1.3f, attackPoint.position.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col2D)
    {
        if (col2D.gameObject.CompareTag("Moedas"))
        {
            Destroy(col2D.gameObject);
            moedas++;
            textMoedas.text = moedas.ToString();
        }
        if (col2D.gameObject.CompareTag("Moedao"))
        {
            Destroy(col2D.gameObject);
            moedas = moedas +20;
            textMoedas.text = moedas.ToString();
        }
        if (col2D.gameObject.CompareTag("Vida"))
        {
            Destroy(col2D.gameObject);
            health++;
        }
        if (col2D.gameObject.CompareTag("FinalTela"))
        {
            health = 0;
            Invoke("ReloadLevel", 1);
            isAlive = false;
            anim.SetTrigger("Death");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("AutomaticPlat"))
        {
            this.transform.parent = other.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("AutomaticPlat"))
        {
            this.transform.parent = null;
        }
    }

    //ATK--------------------------------------------------------
    void Attack()
    {
        //Animação Ataque
        anim.SetTrigger("Attack");
        //Detectar Distancia dos Inimigos
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Dano
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    //ATK----------------------------------------------------------

    //DAMAGE TAKEN------------------------------------------------
    IEnumerator Damage()
    {
        invunerable = true;
        dmgPlayerSound.Play();
        for (float i = 0f; i < 1f; i += 0.2f)
        {   
            yield return new WaitForSeconds(0.06f);
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        invunerable = false;
    }

    IEnumerator Countdown ()
    {
        inAttack = true;
        for (float i = 0f; i < 1f; i += 0.2f)
        {
            yield return new WaitForSeconds(0.05f);
        }
        inAttack = false;
    }
    
    public void DamagePlayer()
    {
        if (isAlive)
        {
            //invunerable = true;
            health--;
            //anim.SetBool("Hurt", true);
            
            StartCoroutine(Damage()); 

            if (health < 1)
            {
                isAlive = false;
                //anim.SetBool("Hurt", false);
                anim.SetTrigger("Death");
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                Invoke("ReloadLevel", 4f);
            }
        }
    }

    public void StopPlayer()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    public void PauseSound()
    {
        soundFx.Pause();
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
