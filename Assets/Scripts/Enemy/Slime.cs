using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem explosion;
    public float moveSpeed;
    public int HP;
    Vector3 moveDir;
    Animator animator;
    GameController gameController;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        StartCoroutine(RandomMove());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if(HP <= 0)
        {
            animator.SetBool("Die", true);
            StartCoroutine(Delay());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControll>().GetDamage(10);
        }
        animator.SetBool("Die", true);
        StartCoroutine(Delay());
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
        while (true)
        {
            int dir = Random.Range(0, 5);
            switch (dir)
            {
                case 0:
                    moveDir = Vector3.up;
                    break;
                case 1:
                    moveDir = -Vector3.up;
                    break;
                case 2:
                    moveDir = Vector3.left;
                    break;
                case 3:
                    moveDir = -Vector3.left;
                    break;
                default:
                    moveDir = Vector3.zero;
                    break;

            }
            yield return new WaitForSeconds(1.5f);
        }
    }


}
