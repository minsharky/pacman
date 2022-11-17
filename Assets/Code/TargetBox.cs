using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;

    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }
    public bool alreadyCollided = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) {
            Scored();
        }
    }

    private void Scored()
    {
        // FILL ME IN
        GetComponent<SpriteRenderer>().color = Color.green;
        if (!alreadyCollided)
        {
            if (GetComponent<Rigidbody2D>() != null) {
                ScoreKeeper.AddToScore(GetComponent<Rigidbody2D>().mass);
                alreadyCollided = true;
            }
        }

    }
}
