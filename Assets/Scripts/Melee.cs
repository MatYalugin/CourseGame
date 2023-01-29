using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public AudioSource audioSource;
    public string kickAnimName;
    public string powerKickAnimName;
    public string inspectionAnimName;
    Camera mainCamera;
    public float damage;
    public float distance;
    public float kickingDelay = 0.3f;
    public bool isReadyToKick = true;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    public void Kick()
    {
        if (Input.GetButtonDown("Fire1") && isReadyToKick == true)
        {
            isReadyToKick = false;
            Invoke("MakeReadyToKick", kickingDelay);
            GameManager.weaponAnimator.Play(kickAnimName);
            audioSource.Play();
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Enemy"))
                {
                    hit.transform.GetComponent<Enemy>().Hurt(damage);
                }
            }
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Explosive"))
                {
                    hit.transform.GetComponent<ExplosiveBarrel>().Hurt(damage);
                }
            }
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Breakable"))
                {
                    hit.transform.GetComponent<Breakable>().Hurt(damage);
                }
            }
        }
    }
    public void MakeReadyToKick()
    {
        isReadyToKick = true;
    }
    public void sprintKick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && Input.GetKey(KeyCode.LeftShift) && isReadyToKick == true)
        {
            isReadyToKick = false;
            Invoke("MakeReadyToKick", kickingDelay * 3);
            GameManager.weaponAnimator.Play(powerKickAnimName);
            audioSource.Play();
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Enemy"))
                {
                    hit.transform.GetComponent<Enemy>().Hurt(damage * 2);
                }
            }
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Explosive"))
                {
                    hit.transform.GetComponent<ExplosiveBarrel>().Hurt(damage * 2);
                }
            }
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Breakable"))
                {
                    hit.transform.GetComponent<Breakable>().Hurt(damage * 2);
                }
            }
        }
    }
    public void Inspection()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameManager.weaponAnimator.Play(inspectionAnimName);
        }
    }
    private void Update()
    {
        Kick();
        Inspection();
        sprintKick();
    }
}
