using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Health = 100;
    public float MaxHealth = 100;
    //public string Ammo;
    public Slider HealthBar;
    public Text HealthText;
   // public Text AmmoText;
    public GameObject DeathMenu;
    public GameObject PauseMenu;
    public GameObject optionsMenu;
    public GameObject screenBlood;
    public GameObject Grenade;
    public GameObject controls;
    void Start()
    {
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = Health;
        HealthText.text = "" + Health;
        //AmmoText.text = "Ammo: " + Ammo;
    }

    public void Hurt(float damage)
    {
        GameManager.weaponAnimator.Play("Hurt");
        Health = Health - damage;
        HealthBar.value = Health;
        HealthText.text = "" + Health;
        if (Health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            DeathMenu.SetActive(true);
        }
    }
    public void ScreenBloodOn()
    {
        screenBlood.SetActive(true);
    }
    public void ScreenBloodOff()
    {
        screenBlood.SetActive(false);
    }
    public void HealthBoost(float healthUp)
    {
        if(Health < 100)
        {
            Health = Health + GameManager.healthUp;
            HealthBar.value = Health;
            HealthText.text = "" + Health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            controls.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            controls.SetActive(false);
        }
    }
    public void DestroyGrenade()
    {
        Destroy(Grenade);
    }
}
