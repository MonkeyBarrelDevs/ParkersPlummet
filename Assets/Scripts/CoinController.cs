using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] AudioSource audio;
    EventHandler eHandler;

    private void Start()
    {
        value = 100;
        eHandler = GameObject.FindGameObjectWithTag("EventHandler").GetComponent<EventHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audio.Play();
        eHandler.AddCurrency(value);
        Destroy(gameObject);
    }
}
