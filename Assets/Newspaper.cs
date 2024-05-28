using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    //Destroy the newspaper after 2 seconds
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
}
