using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float sec;
    BoxCollider2D boxCollider;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explosion());
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator Explosion()
    {

        yield return new WaitForSeconds(sec);
        // 爆炸特效
        Instantiate(explosion, gameObject.transform);
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";  //改layer讓炸彈看似不見
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }
}
