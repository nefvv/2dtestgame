using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text strawberriesText;
    private int strawberries = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("strawberry"))
        {
            Destroy(collision.gameObject);
            strawberries++;

            strawberriesText.text = "Strawberries : " + strawberries;
        }

    }

}
