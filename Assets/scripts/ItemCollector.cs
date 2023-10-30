using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text strawberriesText;
    [SerializeField] private AudioSource collectSound;
    private int strawberries = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("strawberry"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            strawberries++;

            strawberriesText.text = "Strawberries : " + strawberries;
        }

    }

}
