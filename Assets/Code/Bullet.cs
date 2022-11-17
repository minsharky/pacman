using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float time;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time + 1.5f)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ghost")
        {
            FindObjectOfType<Enemy>().transform.Translate(collision.transform.position * -2 * Time.deltaTime * 3f);
        }
        else if (collision.gameObject.GetComponent<BoxCollider2D>())
        {
            Destroy(gameObject);
        }
        else {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
