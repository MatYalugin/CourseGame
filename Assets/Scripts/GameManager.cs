using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Player player;
    public static LayerMask playerLayer;
    public static Camera mainCamera;
    public static Animator weaponAnimator;
    public static float healthUp;
    public static GameObject playerScreenBlood;
    public static GameObject killScoreText;
}
