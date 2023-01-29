using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0f;
    public float requiredScore;
    public Text killScoreText;
    public GameObject exitGameobject;
    // Start is called before the first frame update
    void Start()
    {
        killScoreText.text = "Zombie killed to unlock exit: " + score + "/" + requiredScore;
    }

    // Update is called once per frame
    void Update()
    {
        unlockExit();
    }
    public void plusKill()
    {
        score = score + 1f;
        killScoreText.text = "Zombie killed to unlock exit: " + score + "/" + requiredScore;
    }
    public void unlockExit()
    {
        if(score >= requiredScore)
        {
            exitGameobject.SetActive(true);
        }
    }
}
