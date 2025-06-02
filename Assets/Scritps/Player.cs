using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string OBSTACLE = "Obstacle";
    private const string FINISH = "Finish";

    private float horizontalInput , verticalInput ;
    private float speed = 5f;
    private Rigidbody2D rb;
    private SoundManager soundManager;

    [SerializeField]private LevelManager levelManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<SoundManager>();

        if(soundManager ==  null )
        {
            Debug.Log("Sound Manager not Found");
        }
    }

    void Update() => GetInput();

    private void FixedUpdate() => PlayerMovement();

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw(HORIZONTAL);
        verticalInput = Input.GetAxisRaw(VERTICAL);
    }

    private void PlayerMovement()
    {
        Vector2 newVelocity = new Vector2(horizontalInput,verticalInput).normalized * speed;
        rb.velocity = newVelocity;
    }

    private void PlayerDied()
    {
        soundManager.PlayGameOverAudio();
        levelManager.OnPlayerDeath();
        Destroy(gameObject);

    }

    private void LevelComplete()
    {
        soundManager.PlayLevelCompleteAudio();
        levelManager.OnLevelComplete();
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(OBSTACLE))
        {
            PlayerDied();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(FINISH))
        {
            LevelComplete();
        }
    }
}
