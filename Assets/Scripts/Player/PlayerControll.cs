using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    Rigidbody2D rigidbody;
    Animator animator;

    BoxCollider2D[] collider2D;

    enum FaceState { down=0,up,left,right };

    FaceState face;
    bool iswalk;
    [SerializeField] Sprite sprite_down;
    [SerializeField] Sprite sprite_up;
    [SerializeField] Sprite sprite_left;
    [SerializeField] Sprite sprite_right;
    [SerializeField] float moveSpeed;
    Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        face = FaceState.down;
        sprite = GetComponentInChildren<SpriteRenderer>().sprite;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        collider2D = GetComponents<BoxCollider2D>();
        iswalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.W))
        {

            transform.Translate(new Vector2(0, 1+moveSpeed)*Time.deltaTime);
            face = FaceState.up;
            sprite = sprite_up;
            iswalk = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(new Vector2(0, -1- moveSpeed) * Time.deltaTime);
            face = FaceState.down;
            sprite = sprite_down;
            iswalk = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(new Vector2(1+ moveSpeed, 0) * Time.deltaTime);
            face = FaceState.right;
            sprite = sprite_right;
            iswalk = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(new Vector2(-1- moveSpeed, 0) * Time.deltaTime);
            face = FaceState.left;
            sprite = sprite_left;
            iswalk = true;
        }
        else
        {
            iswalk = false;
        }



        animator.SetInteger("face", (int)face);
        animator.SetBool("walk", iswalk);
        GetComponentInChildren<SpriteRenderer>().sprite = sprite;

    }

    public int GetFaceState()
    {
        return (int)face;
    }
}
