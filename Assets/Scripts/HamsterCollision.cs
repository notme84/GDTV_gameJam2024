using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Entity"))
        {
            switch (other.GetComponent<EntityType>().entityType)
            {
                case EntityType.EntityTypes.Life:
                    Debug.Log("Life increases");
                    Destroy(other.gameObject);
                    break;
                case EntityType.EntityTypes.Hurt:
                    Debug.Log("Hurt");
                    break;
                case EntityType.EntityTypes.Death:
                    Debug.Log("Death");
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
