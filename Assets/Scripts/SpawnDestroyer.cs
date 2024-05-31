using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Entity") || other.CompareTag("Home"))
        {
            //Debug.Log("Entity destoyed");
            Destroy(other.gameObject);
        }
    }
}
