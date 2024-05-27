using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterCollision : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Entity"))
        {
            switch (other.GetComponent<EntityType>().entityType)
            {
                case EntityType.EntityTypes.Life:
                    audioManager.PlayClipByName("increase");
                    Debug.Log("Life increases");
                    Destroy(other.gameObject);
                    break;
                case EntityType.EntityTypes.Hurt:
                    audioManager.PlayClipByName("decrease");
                    Debug.Log("Hurt");
                    break;
                case EntityType.EntityTypes.Death:
                    audioManager.PlayClipByName("death");
                    FinishGameManager.Instance.FinishGame();
                    break;
                case EntityType.EntityTypes.Cat:
                    Debug.Log("Cat");
                    break;
                case EntityType.EntityTypes.Fox:
                    Debug.Log("Fox");
                    break;
                default:
                    Debug.Log("Default");
                    break;
            }
        }
    }
}
