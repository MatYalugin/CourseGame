using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float Health = 100;
    public Animator animator;
    public GameObject fireEffect;
    private bool _isInFire;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Fire"))
        {
            _isInFire = true;
            StartCoroutine(FireDamage(other.gameObject));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Fire"))
        {
            _isInFire = false;
        }
    }
    private IEnumerator FireDamage(GameObject fire)
    {
        while (_isInFire)
        {
            Hurt(5);
            yield return new WaitForSeconds(0.5f);
            if (fire == null)
            {
                break;
            }
        }
    }
}
