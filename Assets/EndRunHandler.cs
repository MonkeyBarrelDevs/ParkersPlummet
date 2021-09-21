using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRunHandler : MonoBehaviour
{
    [SerializeField] LevelLoader loader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        loader.LoadNextLevel();
    }
}
