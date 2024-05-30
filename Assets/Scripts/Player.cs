using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingLeft = 0.5f;
    [SerializeField] float paddingRight = 0.5f;
    [SerializeField] int numOfProjectiles = 20;
    [SerializeField] float projectileCooldown = 1.5f;
    [SerializeField] Sprite upperLeftsprite;
    [SerializeField] Sprite upperRightsprite;
    [SerializeField] Sprite Leftsprite;
    [SerializeField] Sprite Rightsprite;
    [SerializeField] Sprite upForwardSprite;
    [SerializeField] TextMeshProUGUI paperCountText;
    [SerializeField] TextMeshProUGUI scoreText;

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
    float paperTimer;
    bool canShoot = true;

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
        upForwardSprite = spriteRenderer.sprite;
        scoreText.text = playerScore.ToString();
        paperCountText.text = numOfProjectiles.ToString();
        paperTimer = projectileCooldown;
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
        /*if(!canShoot)
        {
            Debug.Log("delta time: " + Time.deltaTime);
            Debug.Log("paper cooldown timer: " + paperTimer.ToString());
            paperTimer -= Time.deltaTime;
            if(paperTimer < 0)
            {
                paperTimer = projectileCooldown;
                canShoot = true;
            }
        }*/
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

        //Debug.Log(rawInput);
        //TODO: Player sprite directions fix UR/UL
        if (rawInput == upperLeft)
        {
            Debug.Log("UPPER LEFT!");
            ChangeSprite(upperLeftsprite);
        }
        else if (rawInput == upperRight)
        {
            Debug.Log("UPPER RIGHT!");
            ChangeSprite(upperRightsprite);
        }
        else if (rawInput == Left)
        {
            ChangeSprite(Leftsprite);
        }
        else if (rawInput == Right)
        {
            ChangeSprite(Rightsprite);
        }
        else if (rawInput == up)
        {
            ChangeSprite(upForwardSprite);
        }
    }

    void OnFire(InputValue value)
    {
        
        /*if (numOfProjectiles > 0 && paperTimer == projectileCooldown)
        {
            if(shooter != null && canShoot)
            {
                shooter.isFiring = value.isPressed;
                numOfProjectiles--;
                paperCountText.text = numOfProjectiles.ToString();
                canShoot = false;
            }
        }*/
        if (numOfProjectiles > 0)
        {
            if(shooter != null)
            {
                shooter.isFiring = value.isPressed;
                numOfProjectiles--;
                paperCountText.text = numOfProjectiles.ToString();
            }
        }
    }

    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public int GetProjectileCount()
    {
        return numOfProjectiles;
    }

    public void SetProjectileCount(int num)
    {
        numOfProjectiles = num;
    }
}
