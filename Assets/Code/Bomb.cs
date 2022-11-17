using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;

    public void Boom()
    {
        var pointComp = GetComponent<PointEffector2D>();
        pointComp.enabled = true;

        var spriteRendComp = GetComponent<SpriteRenderer>();
        spriteRendComp.enabled = false;

        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        Invoke("DestroyOb", 0.1f);

    }
    public void DestroyOb()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        if (rb != null) {
            if (rb.velocity.magnitude >= ThresholdForce)
            {
                Boom();
            }
        }
    }
}
