using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float Health = 100;
    public Animator animator;
    public GameObject fireEffect;
    private void Start()
    {
        tag = "Explosive";
    }
    public void Hurt(float damage)
    {
        Health = Health - damage;
        if (Health <= 0)
        {
            Explode();
        }
    }
    public void Explode()
    {
        animator.Play("Explosion");
        fireEffect.SetActive(false);
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (Health <= 40)
        {
            fireEffect.SetActive(true);
            Invoke("Explode", 5f);
        }
    }
}
