using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    void Start()
    {
        ScreenCapture.CaptureScreenshot("Screenshot.png");
    }
}
