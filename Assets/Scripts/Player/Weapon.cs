using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] float strength;
    [SerializeField] GameObject bullet;
    public Transform firepoint;
    public LayerMask Whattohit;

    int faceState;
    int firebutton;

    PlayerControll playerControll;

    // Start is called before the first frame update
    void Start()
    {
        playerControll = GetComponentInParent<PlayerControll>();
        strength = 1.0f;
        firebutton = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)|| firebutton==1)
        {
            Toss();
            firebutton = 0;
        }


    }


     void Toss()
    {
        faceState = playerControll.GetFaceState();
        //bullet.transform.position = firepoint.transform.position;
        GameObject bullet1 = Instantiate(bullet, firepoint.transform.position, new Quaternion(0, 0, 0, 0));
      Rigidbody2D  rigidbody = bullet1.GetComponent<Rigidbody2D>();
        //bullet1.GetComponent<Collider2D>().
        switch (faceState)
        {
            case 0:
            //    rigidbody.AddForce(new Vector2(0, -2 * strength));
               bullet1.transform.Translate(new Vector2(0,- 2 * strength));
                break;
            case 1:
                   bullet1.transform.Translate(new Vector2(0, 2 * strength));
             //   rigidbody.AddForce(new Vector2(0, 2 * strength));
                break;
            case 2:
               // rigidbody.AddForce(new Vector2(-2 * strength,0 ));
                  bullet1.transform.Translate(new Vector2(-2 * strength, 0));
                break;
            case 3:
              //  rigidbody.AddForce(new Vector2(2 * strength, 0));
                  bullet1.transform.Translate(new Vector2(2 * strength, 0));
                break;
            default:
                break;
        }



    }

  public void fire_button()
    {
        firebutton = 1;
    }

}
