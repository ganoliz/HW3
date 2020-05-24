using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullMan : MonoBehaviour
{
    public ParticleSystem explosion;
    public float moveSpeed;
    public int HP;

    bool inRM;
    bool inNP;

    Vector3 moveDir;
    Animator animator;
    GameObject player;
    GameController gameController;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        inRM = false;
        inNP = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (HP <= 0)
        {
            animator.SetBool("Die", true);
            StartCoroutine(Delay());
        }

        if (Vector3.Distance(player.transform.position, transform.position) > 5 && inRM == false)
        {
            inRM = true;
            inNP = false;
            StopAllCoroutines();
            StartCoroutine(RandomMove());
        }
        else if(Vector3.Distance(player.transform.position, transform.position) <= 5 && inNP == false)
        {
            inRM = false;
            inNP = true;
            StopAllCoroutines();
            StartCoroutine(NearPlayer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControll>().GetDamage(30);
        }
    }


    private void OnParticleCollision(GameObject other)
    {
        HP -= 2;
    }

    IEnumerator Delay()
    {

        yield return new WaitForSeconds(1);
        gameController.EnemyIsDefeat();
        Destroy(gameObject);
    }

    IEnumerator RandomMove()
    {
        moveSpeed = 0.5f;
        while (true)
        {
            int dir = Random.Range(0, 5);
            animator.SetBool("walk", true);
            animator.SetInteger("face", dir);
            switch (dir)
            {
                case 0:
                    moveDir = -Vector3.up;
                    break;
                case 1:
                    moveDir = Vector3.up;
                    break;
                case 2:
                    moveDir = Vector3.left;
                    break;
                case 3:
                    moveDir = -Vector3.left;
                    break;
                default:
                    moveDir = Vector3.zero;
                    animator.SetBool("walk", false);
                    break;

            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator NearPlayer()
    {
        moveSpeed = 1.2f;
        while (true)
        {
            animator.SetBool("walk", true);
            Vector3 vector = player.transform.position - transform.position;
            if(Mathf.Abs(vector.x) >= Mathf.Abs(vector.y))
            {
                if(vector.x >= 0)
                {
                    moveDir = -Vector3.left;
                    animator.SetInteger("face", 3);
                }
                else
                {
                    moveDir = Vector3.left;
                    animator.SetInteger("face", 2);
                }
            }
            else
            {
                if (vector.y >= 0)
                {
                    moveDir = Vector3.up;
                    animator.SetInteger("face", 1);
                }
                else
                {
                    moveDir = -Vector3.up;
                    animator.SetInteger("face", 0);
                }
            }
            yield return null;
        }
    }
}
