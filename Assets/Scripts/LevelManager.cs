using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool bossDeath;
public void ChangeLevel(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
        if(bossDeath == true)
        {
            PlayerPrefs.SetFloat("currentHealth", 100);
        }
    }
    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
