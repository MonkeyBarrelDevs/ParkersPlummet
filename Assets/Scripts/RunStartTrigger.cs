using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStartTrigger : MonoBehaviour
{
    [SerializeField] EventHandler eventHandler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!eventHandler.inRun)
            eventHandler.StartRun();
    }
}
