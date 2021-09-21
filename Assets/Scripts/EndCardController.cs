using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCardController : MonoBehaviour
{
    [SerializeField] LevelLoader loader;
    [SerializeField] GameObject credits;

    public void GoToCredits() 
    {
        StartCoroutine(transition());
    }

    IEnumerator transition() 
    {
        yield return new WaitForSeconds(7);
        loader.ReplayTransition();
        yield return new WaitForSeconds(1.5f);
        credits.SetActive(true);
    }
}
