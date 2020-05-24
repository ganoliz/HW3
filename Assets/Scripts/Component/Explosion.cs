using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.PlayExplodeEffect();
    }

    // Update is called once per frame
    void Update()
    {

    }


   /* private void OnParticleCollision(GameObject other)
    {

        int numCollisionEvents = explosion.GetCollisionEvents(other, collisionEvents);

        int i = 0;

        while (i < numCollisionEvents)
        {

            Debug.Log(other.name);
            if (other.tag.Equals("Enemy"))
            {
                Destroy(other);

            }

            i++;
        }


       
     
    }*/
}
