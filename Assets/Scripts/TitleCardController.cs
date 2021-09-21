using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCardController : MonoBehaviour
{
    [SerializeField] LevelLoader loader;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            loader.LoadNextLevel();
        }
    }
}
