using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityType : MonoBehaviour
{
    public enum EntityTypes { Life, Hurt, Death, Newspapers}
    public EntityTypes entityType;

    [SerializeField] private bool isAnimal;
    public bool _isAnimal { get { return isAnimal; } }
}
