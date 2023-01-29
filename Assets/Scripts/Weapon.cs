using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    Camera mainCamera;
    public float damage;
    public float distance;
    public string shotAnimName;
    public string reloadAnimName;
    public ParticleSystem ParticleSystem;
    public bool useParticleSystem;
    public bool inspection;
    public string inspectionAnimName;
    public AudioSource AudioSource;
    public ParticleSystem bulletCartridge;
    public bool useBulletCartridge;
    public float ammo;
    public float maxAmmo;
    public float ammoCapacityMag;
    public float maxAmmoCapacityMag;
    public Text AmmoText;
    public float firingDelay;
    public bool isReadyToFire = true;
    public bool isAutomatic;
    private void Start()
    {
        mainCamera = Camera.main;
        AmmoText.text = "Ammo: " + ammo + " / " + ammoCapacityMag + "x";
    }

    public void Shot()
    {
        if(isAutomatic == true)
        {
            if (Input.GetButton("Fire1") && ammo != 0 && isReadyToFire == true)
            {
                isReadyToFire = false;
                Invoke("MakeReadyToFire", firingDelay);
                ammo = ammo - 1f;
                AmmoText.text = "Ammo: " + ammo + " / " + ammoCapacityMag + "x";
                if (useParticleSystem == true)
                {
                    ParticleSystem.Play();
                }
                if (useBulletCartridge == true)
                {
                    bulletCartridge.Play();
                }
                GameManager.weaponAnimator.Play(shotAnimName);
                AudioSource.Play();
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
        if (isAutomatic == false)
        {
            if (Input.GetButtonDown("Fire1") && ammo != 0 && isReadyToFire == true)
            {
                isReadyToFire = false;
                Invoke("MakeReadyToFire", firingDelay);
                ammo = ammo - 1f;
                AmmoText.text = "Ammo: " + ammo + " / " + ammoCapacityMag + "x";
                if (useParticleSystem == true)
                {
                    ParticleSystem.Play();
                }
                if (useBulletCartridge == true)
                {
                    bulletCartridge.Play();
                }
                GameManager.weaponAnimator.Play(shotAnimName);
                AudioSource.Play();
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
    }
    public void MakeReadyToFire()
    {
        isReadyToFire = true;
    }
    public void Reload()
    {
        if (Input.GetKey(KeyCode.R) && ammo != maxAmmo && ammoCapacityMag != 0)
        {
            GameManager.weaponAnimator.Play(reloadAnimName);
            ammo = maxAmmo;
            ammoCapacityMag = ammoCapacityMag - 1;
            AmmoText.text = "Ammo: " + ammo + " / " + ammoCapacityMag + "x";
        }
    }
    public void Inspection()
    {
        if(inspection = true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                GameManager.weaponAnimator.Play(inspectionAnimName);
            }
        }
    }
    void Update()
    {
        Shot();
        Reload();
        Inspection();
    }
}



