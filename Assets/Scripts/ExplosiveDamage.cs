using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveDamage : MonoBehaviour
{
    public float Damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player>().Hurt(Damage);
            collision.gameObject.GetComponent<Player>().bleedingChanceExplosion();
        }
        if (collision.transform.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Hurt(Damage);
        }
        if (collision.transform.tag.Equals("Explosive"))
        {
            collision.gameObject.GetComponent<ExplosiveBarrel>().Explode();
        }
    }
}
