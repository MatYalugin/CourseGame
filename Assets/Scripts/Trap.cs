using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float Damage;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player>().Hurt(Damage);
            Destroy(gameObject);
        }
        if (collision.transform.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Hurt(Damage);
            Destroy(gameObject);
        }
    }
}
