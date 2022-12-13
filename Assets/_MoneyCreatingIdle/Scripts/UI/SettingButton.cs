using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboredGames
{
    public class SettingButton : MonoBehaviour
    {
        [SerializeField] AudioListener audioListener;
        bool isSound = true;
        bool isVib = true;

        public void Start()
        {
            isSound = GameData.SoundStatues;
            isVib = GameData.VibrationStatues;
        }

        public void SoundController()
        {
            audioListener.enabled = !isSound;
            isSound = !isSound;
        }

        public void VibrationController()
        {
            if (isVib)
            {
                MyUiManager.instance.vibrationState = VibrationState.on;
                GameData.VibrationStatues = true;
            }

            if (!isVib)
            {
                MyUiManager.instance.vibrationState = VibrationState.of;
                GameData.VibrationStatues = false;
            }
            isSound = !isSound;
        }

        public void Golink(string link)
        {
            Application.OpenURL(link);
        }
    }
}