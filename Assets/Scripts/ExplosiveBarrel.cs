using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float Health = 100;
    public Animator animator;
    private void Start()
    {
        tag = "Explosive";
    }
    public void Hurt(float damage)
    {
        Health = Health - damage;
        if (Health <= 0)
        {
            animator.Play("Explosion");
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
