using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject activeWeapon;
    public GameObject knife;
    public GameObject pistol;
    public GameObject rifle;
    //weapon images;
    public GameObject imageRifle;
    public GameObject imagePistol;
    public GameObject imageKnife;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && knife != null)
        {
            if(activeWeapon != null)
            {
                activeWeapon.SetActive(false);
            }
            activeWeapon = knife;
            activeWeapon.SetActive(true);
            imageKnife.SetActive(true);
            imagePistol.SetActive(false);
            imageRifle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && pistol != null)
        {
            if (activeWeapon != null)
            {
                activeWeapon.SetActive(false);
            }
            activeWeapon = pistol;
            activeWeapon.SetActive(true);
            imageKnife.SetActive(false);
            imagePistol.SetActive(true);
            imageRifle.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && rifle != null)
        {
            if (activeWeapon != null)
            {
                activeWeapon.SetActive(false);
            }
            activeWeapon = rifle;
            activeWeapon.SetActive(true);
            imageKnife.SetActive(false);
            imagePistol.SetActive(false);
            imageRifle.SetActive(true);
        }
    }
}
