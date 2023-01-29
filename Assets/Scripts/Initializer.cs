using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    public Player player;
    public LayerMask playerLayer;
    public Camera mainCamera;
    public Animator weaponAnimator;
    public float healthUp;
    public GameObject playerScreenBlood;
    public GameObject killScoreText;
    public void Start()
    {
        GameManager.player = player;
        GameManager.playerLayer = playerLayer;
        GameManager.mainCamera = mainCamera;
        GameManager.weaponAnimator = weaponAnimator;
        GameManager.healthUp = healthUp;
        GameManager.playerScreenBlood = playerScreenBlood;
        GameManager.killScoreText = killScoreText;
    }
}
