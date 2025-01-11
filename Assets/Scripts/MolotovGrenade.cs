using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovGrenade : MonoBehaviour
{
    [SerializeField] private GameObject _fireArea;
    [SerializeField] private AudioClip _sound;
    [SerializeField] private bool _isItem;
    [SerializeField] private GameObject _fireOnRag;
    // Start is called before the first frame update
    void Start()
    {
        if (_isItem)
        {
            Destroy(_fireOnRag);
        }
    }
    public void Explode()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5f))
        {
            if (!string.IsNullOrEmpty(hit.transform.tag))
            {
                Instantiate(_fireArea, hit.point, Quaternion.Euler(-90, 0, 0));
                AudioSource.PlayClipAtPoint(_sound, transform.position);
                Destroy(gameObject);
            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(_sound, transform.position);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag != null && !_isItem)
        {
            Explode();
        }
        if (collision.transform.tag.Equals("Player") && _isItem)
        {
            collision.gameObject.GetComponent<Molotov>().AddMolotov();
            Destroy(gameObject);
        }
    }
}
