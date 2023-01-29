using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretching : MonoBehaviour
{
    public Animator animator;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            animator.Play("Explosion");
        }
        if (collision.transform.tag.Equals("Enemy"))
        {
            animator.Play("Explosion");
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
