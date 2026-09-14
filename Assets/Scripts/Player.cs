using UnityEngine;
using UnityEngine.InputSystem;
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
        Speed = 50;
        Score = 0;
        Life = 21;
        scoreText.text = "Score: " + Score;
        lifeTimer.text = "" + (int)Life;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(0, 0);

        if (Keyboard.current.leftArrowKey.ReadValue() > 0) 
        {
            vel.x -= Speed;
        }
        if (Keyboard.current.rightArrowKey.ReadValue() > 0)
        {
            vel.x += Speed;
        }
        if (Keyboard.current.upArrowKey.ReadValue() > 0)
        {
            vel.y += Speed;
        }
        if (Keyboard.current.downArrowKey.ReadValue() > 0)
        {
            vel.y -= Speed;
        }

        rigBody.linearVelocity = vel;



        Life -= Time.deltaTime;
        lifeTimer.text = "" + (int)Life;
        if (Life <= 1)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Coin coin = other.gameObject.GetComponent<Coin>();
        if (coin != null)
        {
            coin.GetBumped();
            Score++;
            UpScore();
        }

        Anticoin anticoin = other.gameObject.GetComponent<Anticoin>();
        if (anticoin != null)
        {
            anticoin.GetBumped();
            Score--;
            UpScore();
        }
    }

    void UpScore()
    {
        scoreText.text = "Score: " + Score;
    }
}
