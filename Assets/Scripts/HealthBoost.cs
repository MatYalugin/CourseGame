using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player>().HealthBoost(GameManager.healthUp);
            Destroy(gameObject);
        }
    }
}
