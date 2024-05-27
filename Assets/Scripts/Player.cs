using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingLeft = 0.5f;
    [SerializeField] float paddingRight = 0.5f;
    [SerializeField] Sprite upperLeftsprite;
    [SerializeField] Sprite upperRightsprite;
    [SerializeField] Sprite Leftsprite;
    [SerializeField] Sprite Rightsprite;
    [SerializeField] Sprite upForwardSprite;

    SpriteRenderer spriteRenderer;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    Vector2 upperLeft;
    Vector2 upperRight;
    Vector2 Left;
    Vector2 Right;

    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
        upperLeft = new Vector2(-0.71f, 0.71f);
        upperRight = new Vector2(0.71f, 0.71f);
        Left = new Vector2(-1, 0);
        Right = new Vector2(1, 0);
    }

    void Start () 
    {
        InitBounds();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        upForwardSprite = spriteRenderer.sprite;
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
        Debug.Log(rawInput);
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
        else
        {
            ChangeSprite(upForwardSprite);
        }

        //TODO: Player sprite directions
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
