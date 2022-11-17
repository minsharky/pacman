using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float time;
    public Transform player;
    public Rigidbody2D rigidBody;

    public Vector3 enemySpawn;
    public Quaternion enemyRot;

    public AudioSource KillSound;

    public AudioSource NiceSound;

    void Start()
    {
        enemySpawn = transform.position;
        enemyRot = transform.rotation;

        time = 3;
        player = FindObjectOfType<Player>().transform;
        rigidBody = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (Time.time > time)
        {
            rigidBody.velocity = 7 * (player.position - transform.position).normalized;
        }
        if (FindObjectOfType<Player>().inAttackMode)
        {
            rigidBody.velocity = -8 * (player.position - transform.position).normalized;
            GetComponent<SpriteRenderer>().color = new Color(0, 0.4f, 1f, 1);
        }
        else {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (FindObjectOfType<Player>().inAttackMode == false)
            {
                KillSound.Play();
                FindObjectOfType<Player>().lives--;
                ScoreKeeper.AddToScore(-1 * ScoreKeeper.score);
                ResetToSpawn();
                FindObjectOfType<Player>().ResetToSpawn();

            }
            else {
                ResetToSpawn();
                NiceSound.Play();
                FindObjectOfType<Player>().inAttackMode = false;
                ScoreKeeper.AddToScore(10);
            }
            time = 3 + Time.time;
        }
    }

    private void ResetToSpawn() {
        transform.position = enemySpawn;
        transform.rotation = enemyRot;
    }
}
