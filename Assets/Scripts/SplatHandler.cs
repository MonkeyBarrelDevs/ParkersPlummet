using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatHandler : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] EndCardController ECC;
    [SerializeField] AudioSource audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("Splat");
        audio.Play();
        ECC.GoToCredits();
    }
}
