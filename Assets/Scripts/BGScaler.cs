using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        float width = sr.sprite.bounds.size.x;
        //float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        tempScale.x = worldScreenWidth / width;
        //tempScale.y = worldScreenHeight / height;

        transform.localScale = tempScale;
    }
}
