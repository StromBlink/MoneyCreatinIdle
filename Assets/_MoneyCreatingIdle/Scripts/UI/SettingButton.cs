using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] AudioListener audioListener;
    bool isSound = true;
    bool isVib = true;
    public void SoundController()
    {
        audioListener.enabled = !isSound; isSound = !isSound;
    }
    public void VibrationController()
    {
        if (isVib) MyUiManager.instance.vibrationState = VibrationState.on;
        if (!isVib) MyUiManager.instance.vibrationState = VibrationState.of;
        isSound = !isSound;
    }
    public void Golink(string link)
    {
        Application.OpenURL(link);
    }
}
