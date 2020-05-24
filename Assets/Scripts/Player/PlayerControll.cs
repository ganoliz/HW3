using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    public int HP;
    public Text HPText;

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
    public VariableJoystick vJoystick;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        face = FaceState.down;
        sprite = GetComponentInChildren<SpriteRenderer>().sprite;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        collider2D = GetComponents<BoxCollider2D>();
        iswalk = false;

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP == 0)
        {
            gameController.GameOver();
        }

        if(Input.GetKey(KeyCode.W)|| vJoystick.Vertical>=0.7)
        {

            transform.Translate(new Vector2(0, 1+moveSpeed)*Time.deltaTime);
            face = FaceState.up;
            sprite = sprite_up;
            iswalk = true;
        }
        else if (Input.GetKey(KeyCode.S)|| vJoystick.Vertical<=-0.7)
        {

            transform.Translate(new Vector2(0, -1- moveSpeed) * Time.deltaTime);
            face = FaceState.down;
            sprite = sprite_down;
            iswalk = true;
        }
        else if (Input.GetKey(KeyCode.D)||vJoystick.Horizontal>=0.7)
        {

            transform.Translate(new Vector2(1+ moveSpeed, 0) * Time.deltaTime);
            face = FaceState.right;
            sprite = sprite_right;
            iswalk = true;
        }
        else if (Input.GetKey(KeyCode.A)||vJoystick.Horizontal<=-0.7 )
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

        HPText.text = "HP:" + HP.ToString();

        animator.SetInteger("face", (int)face);
        animator.SetBool("walk", iswalk);
        GetComponentInChildren<SpriteRenderer>().sprite = sprite;

    }

    public int GetFaceState()
    {
        return (int)face;
    }

    public void GetDamage(int damage)
    {
        HP -= damage;
        if (HP < 0)
            HP = 0;
    }
}
