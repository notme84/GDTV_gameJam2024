using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingLeft = 0.5f;
    [SerializeField] float paddingRight = 0.5f;
    [SerializeField] int numOfProjectiles = 20;
    [SerializeField] TextMeshProUGUI paperText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;

    SpriteRenderer spriteRenderer;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    Vector2 upperLeft;
    Vector2 upperRight;
    Vector2 up;
    Vector2 Left;
    Vector2 Right;
    int playerScore = 0;
    private AudioManager audioManager;
    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
        upperLeft = new Vector2(-0.71f, 0.71f);
        upperRight = new Vector2(0.71f, 0.71f);
        up = new Vector2(0, 1);
        Left = new Vector2(-1, 0);
        Right = new Vector2(1, 0);
    }

    void Start () 
    {
        InitBounds();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        scoreText.text = playerScore.ToString();
        paperText.text = numOfProjectiles.ToString();
        livesText.text = playerLives.ToString();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    
    void Update()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, 
            minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = transform.position.y + delta.y;
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        if (rawInput.y > 0)
        {
            shooter.isMoving = true;
        }
        else
        {
            shooter.isMoving = false;
        }
    }

    void OnFire(InputValue value)
    {
        if (numOfProjectiles > 0)
        {
            if(shooter != null)
            {
                shooter.isFiring = value.isPressed;
                numOfProjectiles--;
                Debug.Log("projectile count: " + numOfProjectiles);
                paperText.text = numOfProjectiles.ToString();
            }
        }
    }

    public int GetProjectileCount()
    {
        return numOfProjectiles;
    }

    public void AddProjectileCount(int num)
    {
        numOfProjectiles += num;
        paperText.text = numOfProjectiles.ToString();
    }

    public void SetScore(int score)
    {
        playerScore = score;
        scoreText.text = playerScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Entity"))
        {
            switch (other.GetComponent<EntityType>().entityType)
            {
                case EntityType.EntityTypes.Life:
                    audioManager.PlayClipByName("increase");
                    playerLives++;
                    livesText.text = playerLives.ToString();
                    Debug.Log("Life increases");
                    Destroy(other.gameObject);
                    break;
                case EntityType.EntityTypes.Hurt:
                    audioManager.PlayClipByName("decrease");
                    playerLives--;
                    livesText.text = playerLives.ToString();
                    Debug.Log("Hurt");
                    if(playerLives<= 0)
                    {
                        FinishGameManager.Instance.FinishGame();
                        break;
                    }
                    break;
                case EntityType.EntityTypes.Death:
                    audioManager.PlayClipByName("death");
                    FinishGameManager.Instance.FinishGame();
                    break;
                case EntityType.EntityTypes.Newspapers:
                    audioManager.PlayClipByName("increase");
                    AddProjectileCount(5);
                    Debug.Log("More Paper");
                    break;
                default:
                    Debug.Log("Default, ohh noooooooo.......");
                    break;
            }
        }
    }
}
