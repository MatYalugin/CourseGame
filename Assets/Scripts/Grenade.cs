using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public AudioSource audioSource;
    public string throwAnimName;
    public string inspectionAnimName;
    public void Throw()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameManager.weaponAnimator.Play(throwAnimName);
            audioSource.Play();
        }
    }
    public void Inspection()
    {
        if (Input.GetKey(KeyCode.F))
        {
            GameManager.weaponAnimator.Play(inspectionAnimName);
        }
    }
    private void Update()
    {
        Throw();
        Inspection();
    }
}
