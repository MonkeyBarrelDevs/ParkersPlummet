using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    [SerializeField] EventHandler handler;

    bool pickedUp;

    private void Start()
    {
        pickedUp = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!pickedUp)
        {
            handler.ExtendTime();
            pickedUp = true;
        }
    }
}
