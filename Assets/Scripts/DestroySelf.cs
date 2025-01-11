using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] private float _delay;
    void Start()
    {
        Invoke("Destroy", _delay);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Water"))
        {
            Destroy(gameObject);
        }
    }
}
