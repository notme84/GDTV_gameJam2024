using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailDelivered : MonoBehaviour
{
    //two serialized fields to change the sprite from one to another
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite mailDeliveredSprite;
    [SerializeField] private Sprite mailNotDeliveredSprite;
    [SerializeField] private bool mailDelivered;
    [SerializeField] private AudioSource audioSource;

    // ontrigger enter to check if the this object has collided with the mail
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mail"))
        {
            mailDelivered = true;
            FinishGameManager.Instance.ScorePoints();
            ChangeSprite(mailDelivered);
            //destroy the colliding object
            Destroy(collision.gameObject);
        }
    }

    // function to change the sprite from one to another
    public void ChangeSprite(bool mailDelivered)
    {
        spriteRenderer.sprite = mailDelivered ? mailDeliveredSprite : mailNotDeliveredSprite;
        //check if there is an audio source attached to the object
        if (audioSource != null)
            audioSource.Play();
    }
}
