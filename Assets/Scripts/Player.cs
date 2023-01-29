using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Health = 100;
    public float MaxHealth = 100;
    public Slider HealthBar;
    public Text HealthText;
    public GameObject DeathMenu;
    public GameObject screenBlood;
    public GameObject controls;
    public GameObject weaponRifle;
    public GameObject weaponPistol;
    public GameObject weaponKnife;
    void Start()
    {
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = Health;
        HealthText.text = "" + Health;
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
            weaponRifle.SetActive(false);
            weaponPistol.SetActive(false);
            weaponKnife.SetActive(false);
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
}
