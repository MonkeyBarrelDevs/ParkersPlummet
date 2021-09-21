using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyHandler : MonoBehaviour
{
    EventHandler eventHandler;
    TextMeshProUGUI textMeshGUI;

    // Start is called before the first frame update
    void Start()
    {
        eventHandler = GameObject.FindGameObjectWithTag("EventHandler").GetComponent<EventHandler>();
        textMeshGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshGUI.text = eventHandler.currency.ToString();
    }
}
