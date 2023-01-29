using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float Health;
    public void Hurt(float Damage)
    {

        Health = Health - Damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        tag = "Breakable";
    }
}
