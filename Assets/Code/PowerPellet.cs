using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : MonoBehaviour
{

    public static float ActionTime;
    // Start is called before the first frame update
    void Start()
    {
        ActionTime = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            FindObjectOfType<Player>().inAttackMode = true;
            ActionTime = Time.time;
            Destroy(gameObject);
        }
        else
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
