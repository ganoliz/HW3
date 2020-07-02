using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] float strength;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet_fire;
    public Transform firepoint;
    public LayerMask Whattohit;

    int faceState;
    int firebutton1;
    int firebutton2;
    PlayerControll playerControll;

    // Start is called before the first frame update
    void Start()
    {
        playerControll = GetComponentInParent<PlayerControll>();
        strength = 1.0f;
        firebutton1 = 0;
        firebutton2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)|| firebutton1==1)
        {
            firebutton1 = 1;
            Toss();
            firebutton1 = 0;
            
        }
       else if (Input.GetKeyDown(KeyCode.K) || firebutton2 == 1)
        {
            firebutton2 = 1;
            Toss();
            firebutton2 = 0;

        }




    }


    void Toss()
    {
        faceState = playerControll.GetFaceState();
        //default

        //bullet.transform.position = firepoint.transform.position;
        if (firebutton1 == 1)
        {
         GameObject   bullet1 = Instantiate(bullet, firepoint.transform.position, new Quaternion(0, 0, 0, 0));
            Rigidbody2D rigidbody = bullet1.GetComponent<Rigidbody2D>();


            //bullet1.GetComponent<Collider2D>().
            switch (faceState)
            {
                case 0:
                    //    rigidbody.AddForce(new Vector2(0, -2 * strength));
                    // bullet1.transform.Translate(new Vector2(0,- 2 * strength));
                    StartCoroutine(TossPlace(bullet1, 0, -2));
                    break;
                case 1:
                    //   bullet1.transform.Translate(new Vector2(0, 2 * strength));
                    //   rigidbody.AddForce(new Vector2(0, 2 * strength));
                    StartCoroutine(TossPlace(bullet1, 0, 2));
                    break;
                case 2:
                    // rigidbody.AddForce(new Vector2(-2 * strength,0 ));
                    //  bullet1.transform.Translate(new Vector2(-2 * strength, 0));
                    StartCoroutine(TossPlace(bullet1, -2, 0));
                    break;
                case 3:
                    //  rigidbody.AddForce(new Vector2(2 * strength, 0));
                    //    bullet1.transform.Translate(new Vector2(2 * strength, 0));
                    StartCoroutine(TossPlace(bullet1, 2, 0));
                    break;
                default:
                    break;
            }
        }
        else if (firebutton2 == 1)
        {
          GameObject  bullet2 = Instantiate(bullet_fire, firepoint.transform.position, new Quaternion(0, 0, 0, 0));
            Rigidbody2D rigidbody = bullet2.GetComponent<Rigidbody2D>();


            switch (faceState)
            {
                case 0:
                    //    rigidbody.AddForce(new Vector2(0, -2 * strength));
                    // bullet1.transform.Translate(new Vector2(0,- 2 * strength));
                    StartCoroutine(TossPlace(bullet2, 0, -1));
                    break;
                case 1:
                    //   bullet1.transform.Translate(new Vector2(0, 2 * strength));
                    //   rigidbody.AddForce(new Vector2(0, 2 * strength));
                    StartCoroutine(TossPlace(bullet2, 0, 1));
                    break;
                case 2:
                    // rigidbody.AddForce(new Vector2(-2 * strength,0 ));
                    //  bullet1.transform.Translate(new Vector2(-2 * strength, 0));
                    StartCoroutine(TossPlace(bullet2, -1, 0));
                    break;
                case 3:
                    //  rigidbody.AddForce(new Vector2(2 * strength, 0));
                    //    bullet1.transform.Translate(new Vector2(2 * strength, 0));
                    StartCoroutine(TossPlace(bullet2, 1, 0));
                    break;
                default:
                    break;
            }

        }

    }

  public void fire_button1()
    {
        firebutton1 = 1;
    }
    public void fire_button2()
    {
        firebutton2 = 1;
    }

    IEnumerator TossPlace(GameObject obj,float x,float y)
    {
        int i;
        int j;
        float count = 0.3f;
        if (x != 0)
        {  
            if(x>0)
            for (i = (int)x*5; i > 0; i--)
            {
                obj.transform.Translate ( new Vector3(0.0545f*i *strength,0,0));
                yield return new WaitForSeconds(count);
                    count /= 2;
                }

            else if(x<0)
                for (i = (int)x * 5; i < 0; i++)
                {
                    obj.transform.Translate(new Vector3(0.0545f * i * strength, 0, 0));
                    yield return new WaitForSeconds(count);
                    count /= 2;
                }


        }
        if (y != 0)
        {

            if (y > 0)
                for (i = (int)y * 5; i > 0; i--)
                {
                    obj.transform.Translate(new Vector3(0, 0.0545f * i * strength, 0));
                    yield return new WaitForSeconds(count);
                    count /= 2;
                }

            else if (y < 0)
                for (i = (int)y * 5; i < 0; i++)
                {
                    obj.transform.Translate(new Vector3(0, 0.0545f * i * strength, 0));
                    yield return new WaitForSeconds(count);
                    count /= 2;
                }

        }

    }

}
