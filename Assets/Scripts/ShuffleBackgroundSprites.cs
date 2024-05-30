using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleBackgroundSprites : MonoBehaviour
{
    [SerializeField] private Vector3 positionToGoBackTo;
    [SerializeField] private Vector3 destination;

    [SerializeField] private float scalingMultiplier;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    private bool isSpeedingUp;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.timeScale);

        if (transform.position == destination)
        {
            transform.position = positionToGoBackTo;
            HouseSpawnManager.Instance.SpawnHouse();
        }

        if (isSpeedingUp)
        {
            speed *= scalingMultiplier;
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
                isSpeedingUp = false;
            }
        }
    }

    public void StartScript()
    {
        isSpeedingUp = true;
    }
}
