using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour

{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ScoreKeeper.AddToScore(1);
            Destroy(gameObject);
        }
        else {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }

    }
}
