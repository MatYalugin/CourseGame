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
    public GameObject mediumHealthEffect;
    public GameObject lowHealthEffect;
    public GameObject bleedingSing;
    public bool isBleeding;
    private float bleedingDamageTimer = 0f;
    private float KnockOutTimer = 0f;
    public GameObject knockEffect;
    private bool isInKnockOut;
    private bool isHurtedByKnock;
    void Start()
    {
        Health = PlayerPrefs.GetFloat("currentHealth");
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = Health;
        HealthText.text = "" + Health;
    }
    public void FixedUpdate()
    {
        PlayerPrefs.SetFloat("currentHealth", Health);
    }

    public void Hurt(float damage)
    {
        GameManager.weaponAnimator.Play("Hurt");
        Health = Health - damage;
        PlayerPrefs.SetFloat("currentHealth", Health);
        HealthBar.value = Health;
        HealthText.text = "" + Health;
        if (Random.value < 0.15f)
        {
            isBleeding = true;
        }
        if (Health <= 0)
        {
            PlayerPrefs.SetFloat("currentHealth", 100);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            DeathMenu.SetActive(true);
            weaponRifle.SetActive(false);
            weaponPistol.SetActive(false);
            weaponKnife.SetActive(false);
            knockEffect.gameObject.GetComponent<DisableInputScript>().enabled = false;
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
            PlayerPrefs.SetFloat("currentHealth", Health);
            HealthBar.value = Health;
            HealthText.text = "" + Health;
        }
        if (Health > 100)
        {
            Health = 100;
            PlayerPrefs.SetFloat("currentHealth", Health);
            HealthBar.value = Health;
            HealthText.text = "" + Health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.P))
        {
            PlayerPrefs.SetFloat("currentHealth", 100);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
            Cursor.visible = true;
            knockEffect.gameObject.GetComponent<DisableInputScript>().enabled = false;
        }
        if(DeathMenu.activeSelf == true)
        {
            knockEffect.gameObject.GetComponent<DisableInputScript>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            controls.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            controls.SetActive(false);
        }

        if (Health <= 60)
        {
            mediumHealthEffect.SetActive(true);
            lowHealthEffect.SetActive(false);
        }
        else
        {
            mediumHealthEffect.SetActive(false);
        }
        if (Health <= 30)
        {
            lowHealthEffect.SetActive(true);
            mediumHealthEffect.SetActive(false);
        }
        else
        {
            lowHealthEffect.SetActive(false);
        }
        if (Health <= 0)
        {
            lowHealthEffect.SetActive(false);
            mediumHealthEffect.SetActive(false);
        }

        if (isInKnockOut == true)
        {
            KnockOutTimer += Time.deltaTime;
        }

        if (isBleeding == true)
        {
            bleedingSing.SetActive(true);
            bleedingDamageTimer += Time.deltaTime;

            if (bleedingDamageTimer >= 2)
            {
                bleedingDamage();
                bleedingDamageTimer = 0f;
            }
        }
        else if (isBleeding == false)
        {
            bleedingSing.SetActive(false);
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("currentHealth", 100);
    }

    public void bleedingChanceExplosion()
    {
        if (Random.value < 0.45f)
        {
            isBleeding = true;
        }
    }
    public void bleedingChanceTrap()
    {
        if (Random.value < 1f)
        {
            isBleeding = true;
        }
    }
    private void bleedingDamage()
    {
        HealthBar.value = Health;
        HealthText.text = "" + Health;
        Health -= 2;
        if (Random.value < 0.03f)
        {
            isInKnockOut = true;
            knockEffect.SetActive(true);
            if(isInKnockOut == true)
            {
                if (KnockOutTimer >= 3 && KnockOutTimer <= 8 && isHurtedByKnock == false)
                {
                    Hurt(10f);
                    isHurtedByKnock = true;
                }
                if (KnockOutTimer >= 10)
                {
                    KnockOutTimer = 0;
                    knockEffect.SetActive(false);
                    isInKnockOut = false;
                    isHurtedByKnock = false;
                }
            }
            
        }

        PlayerPrefs.SetFloat("currentHealth", Health);
        if (Health <= 0)
        {
            PlayerPrefs.SetFloat("currentHealth", 100);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            DeathMenu.SetActive(true);
            weaponRifle.SetActive(false);
            weaponPistol.SetActive(false);
            weaponKnife.SetActive(false);
        }
    }
    public void bleedingOff()
    {
        isBleeding = false;
    }
}
