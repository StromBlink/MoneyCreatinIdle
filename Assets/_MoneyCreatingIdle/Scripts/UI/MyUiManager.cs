using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using KeyboredGames;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace KeyboredGames
{
    public enum VibrationState
    {
        on,
        of
    };

    public class MyUiManager : MonoBehaviour
    {
        public static MyUiManager instance;
        public VibrationState vibrationState;
        [Header("Texts")] public TMP_Text cointext;
        public TMP_Text incomeButtonCoinText;
        public TMP_Text countButtonCoinText;
        public TMP_Text speedButtonCoinText;

        [Header("Buttons")] public Button incomeButton;
        public Button countButton;
        public Button speedButton;

        /* [Header("Slider")]
        public Slider audioSlider; */

        [Header("Panels")] public Image settingPanel;

        [Header("Particles")] public ParticleSystem incomeParticle;
        public ParticleSystem countParticle;
        public ParticleSystem speedParticle;

        [Header("Coins")] public int coin;
        public int incomeCoin;

        [Header("Values")] 
        private int _incomeButtonValue;
        private int _countCoinValue;
        private int _speedCoinValue;
        

        private void Awake()
        {
            instance = this;
            coin = GameData.Coin;
            incomeCoin = GameData.SavePlayerSpec1;
            _incomeButtonValue = GameData.BgmCount;
            _countCoinValue = GameData.SavePlayerSpec2;
            _speedCoinValue = GameData.SavePlayerSpec3;
            /*  audioSlider.value = GameData.Slider; */
        }

        private void Update()
        {
            cointext.SetText(coin.ToString());
            incomeButtonCoinText.SetText(_incomeButtonValue.ToString());
            countButtonCoinText.SetText(_countCoinValue.ToString());
            speedButtonCoinText.SetText(_speedCoinValue.ToString());
            /*  GameData.Slider = audioSlider.value; */
        }

        public void Income()
        {
            if (coin >= _incomeButtonValue)
            {
                coin -= _incomeButtonValue;
                GameData.Coin -= _incomeButtonValue;
                _incomeButtonValue += 10;
                GameData.BgmCount += 10;
                incomeCoin++;
                GameData.SavePlayerSpec1++;

                ButtonEffekt(incomeButton);
            }
        }

        public void Count()
        {
            if (coin >= _countCoinValue)
            {
                coin -= _countCoinValue;
                GameData.Coin -= _countCoinValue;
                _countCoinValue += 10;
                GameData.SavePlayerSpec2 += 10;
                
                ButtonEffekt(countButton);
            }
        }

        public void Speed()
        {
            if (coin >= _speedCoinValue)
            {
                coin -= _speedCoinValue;
                GameData.Coin -= _speedCoinValue;
                _speedCoinValue += 10;
                GameData.SavePlayerSpec3 += 10;
                AnimationController.Instance.animationSpeed += .5f;
                
                ButtonEffekt(speedButton);
            }
        }

        public void Settings()
        {
            Time.timeScale = 0;

            settingPanel.enabled = true;
        }

        public void Resume()
        {
            Time.timeScale = 1;
            settingPanel.enabled = false;
        }

        /* public void Sound()
        {
            AudioManager.Instance.effectSource.volume = audioSlider.value * 10;
        } */


        public void Quit()
        {
            Application.Quit();
            Debug.Log("Application Quit");
        }

        private void ButtonEffekt(Button button)
        {
            button.gameObject.transform.DOPunchScale(Vector3.one * .5f, 0.5f, 0, 0)
                .OnComplete(() => button.gameObject.transform.localScale = Vector3.one * 0.805f);
        }
    }
}