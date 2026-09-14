using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public float Speed;
    public int Score;
    public float Life;
    public Rigidbody2D rigBody;
    public TextMeshPro scoreText;
    public TextMeshPro lifeTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Speed = 35;
        Score = 0;
        Life = 21;
        scoreText.text = "Score: " + Score;
        lifeTimer.text = "" + (int)Life;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(0, 0);

        if (Keyboard.current.leftArrowKey.ReadValue() > 0) // going left
        {
            vel.x -= Speed;
        }
        if (Keyboard.current.rightArrowKey.ReadValue() > 0) // going right
        {
            vel.x += Speed;
        }
        if (Keyboard.current.upArrowKey.ReadValue() > 0) // going up
        {
            vel.y += Speed;
        }
        if (Keyboard.current.downArrowKey.ReadValue() > 0) // going down
        {
            vel.y -= Speed;
        }

        rigBody.linearVelocity = vel;



        Life -= Time.deltaTime;
        lifeTimer.text = "" + (int)Life;
        if (Life <= 1) // if timer reaches 0, despawns and game over
        {
            Despawn();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Coin coin = other.gameObject.GetComponent<Coin>(); // +1 point upon collecting
        if (coin != null)
        {
            coin.GetBumped();
            Score++;
            UpScore();
        }

        Anticoin anticoin = other.gameObject.GetComponent<Anticoin>(); // -1 point upon collecting
        if (anticoin != null)
        {
            anticoin.GetBumped();
            Score--;
            UpScore();
        }
    }

    void UpScore() // score tracker
    {
        scoreText.text = "Score: " + Score;
    }

    void Despawn() // game over
    {
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject);
    }
}
