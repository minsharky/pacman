using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the player.
/// </summary>
public class Player : MonoBehaviour {

    public bool inAttackMode = false;

    public int lives = 3;

    public Vector3 Spawn;
    public Quaternion Rot;

    public float time;

    public GameObject prefab;

    public AudioSource PopSound;
    public AudioSource PowerUpSound;


    internal void Start() {
        Spawn = transform.position;
        Rot = transform.rotation;
        time = Time.time;
    }

    internal void Update()
    {

        MovePlayer();

        ShootBullet();

        if (inAttackMode) {
            if (Time.time > PowerPellet.ActionTime + 5) { 
                inAttackMode = false;
            }
        }

        WinOrLose();
        
    }

    public void ResetToSpawn()
    {
        transform.position = Spawn;
        transform.rotation = Rot;

    }

    public void MovePlayer() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10f);
        }
    }

    public void ShootBullet() {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 newPos;

            //if the enemy is to the right of the player
            if (FindObjectOfType<Enemy>().transform.position.x > transform.position.x)
            {
                newPos = Vector3.right;
            }
            else
            {
                //if the enemy is to the left of the player
                newPos = Vector3.left;
            }
            GameObject newBullet = Instantiate(prefab, transform.localPosition + newPos * 2, Quaternion.identity);

            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.velocity = 10f * (FindObjectOfType<Enemy>().transform.position - transform.position).normalized;
        }
    }

    public void WinOrLose() {
        if (FindObjectsOfType<Pellet>().Length == 0)
        {
            //You Win!
            WinLoseText.UpdateWinLoseText(true);
        }
        else if (lives == 0)
        {
            //You Lose
            WinLoseText.UpdateWinLoseText(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Pellet>() != null) {
            PopSound.Play();
        }

        if (collision.gameObject.GetComponent<PowerPellet>() != null)
        {
            PowerUpSound.Play();
        }
    }

}
