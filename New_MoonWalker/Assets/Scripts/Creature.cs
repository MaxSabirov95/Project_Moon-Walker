using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public Animator anim;
    public enum kindOfCreature { Friendly,Enemy}
    public kindOfCreature KindOfCreature;
    public int HP;
    public float speed;
    bool dead;
    bool moving;
    int sideMove=1;
    float movingTime=0;
    float idleTime=0;
    Rigidbody2D rb2D;
    private Vector2 moveDirection;

    void Start()
    {
        movingTime = Random.Range(5, 10);
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (moving)
        {
            anim.SetBool("isMoving", moving);
            transform.localScale = new Vector2(sideMove, 1);
            rb2D.velocity = new Vector2(speed * sideMove, 0);
            movingTime -= Time.deltaTime;
            if (movingTime <= 0)
            {
                idleTime = Random.Range(2, 5);
                moving = false;
            }
        }
        else
        {
            anim.SetBool("isMoving", moving);
            idleTime -= Time.deltaTime;
            if (idleTime <= 0)
            {
                sideMove *= -1;
                movingTime = Random.Range(5, 10);
                moving = true;
            }
        }
        if (dead)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            HP-=BlackBoard.bullet.bulletDamage;
            Destroy(BlackBoard.bullet.gameObject);
            if (HP <= 0)
            {
                dead = true;
            }
        }
    }
}
