using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float sec;
    BoxCollider2D boxCollider;
    public int Ready;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explosion());
        boxCollider=gameObject.GetComponent<BoxCollider2D>();
        Ready = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerStay2D(Collider2D collision)
    {

        Debug.Log(collision.name);

        if (Ready == 1)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }

        }
    }

    IEnumerator Explosion() {
        
        yield return new WaitForSeconds(sec);
        // 爆炸特效
       
        Destroy(gameObject);
    }
}
