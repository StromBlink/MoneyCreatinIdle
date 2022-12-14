using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
        public TMP_Text incomeValueButtonCoinText;
        public TMP_Text countButtonCoinText;
        public TMP_Text speedButtonCoinText;

        [Header("Buttons")]
        public Button incomeButton;
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
        public static int knifeIndex;

        [Header("Values")]
        private int _incomeButtonValue;
        private int _countCoinValue;
        private int _speedCoinValue;

        [Header("Plates")]
        public GameObject[] plates;
        public int platesCount;

        [Header("UpgradeObject0")]
        public GameObject levelUpgradeGameObject;
        
        

        private void Awake()
        {
            Time.timeScale = 2.5f;
            instance = this;
            coin = GameData.Coin;
            incomeCoin = GameData.SavePlayerSpec1;
            _incomeButtonValue = GameData.BgmCount;
            _countCoinValue = GameData.SavePlayerSpec2;
            _speedCoinValue = GameData.SavePlayerSpec3;
            platesCount = GameData.Gem;
            knifeIndex = GameData.knifeIndex;

            /*  audioSlider.value = GameData.Slider; */
        }
        private void Start()
        {
            OpenPlates();
            if (platesCount > 5)
            {
                levelUpgradeGameObject.SetActive(true);
                CamAnim.Instance.CamAnimation();
            }

        }

        private void Update()
        {
            cointext.SetText("$" + coin.ToString());
            incomeButtonCoinText.SetText("$" + _incomeButtonValue.ToString());
            incomeValueButtonCoinText.SetText("$" + incomeCoin.ToString());
            countButtonCoinText.SetText("$" + _countCoinValue.ToString());
            speedButtonCoinText.SetText("$" + _speedCoinValue.ToString());
            /*  GameData.Slider = audioSlider.value; */


            
        }

        public void Income()
        {
            if (coin >= _incomeButtonValue)
            {
                coin -= _incomeButtonValue;
                GameData.Coin -= _incomeButtonValue;
                _incomeButtonValue += 110;
                GameData.BgmCount += 110;
                incomeCoin++;
                GameData.SavePlayerSpec1++;
            }
        }

        public void Count()
        {
            if (coin >= _countCoinValue)
            {
                coin -= _countCoinValue;
                GameData.Coin -= _countCoinValue;
                _countCoinValue += 110;
                GameData.SavePlayerSpec2 += 110;
                platesCount++;
                GameData.Gem++;
                OpenPlates();
            }
        }

        public void Speed()
        {
            if (coin >= _speedCoinValue)
            {
                coin -= _speedCoinValue;
                GameData.Coin -= _speedCoinValue;
                _speedCoinValue += 110;
                GameData.SavePlayerSpec3 += 110;
                AnimationController.Instance.animationSpeed += .2f;



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
        public void Vibrate()
        {
            if (vibrationState == VibrationState.on)
            {
                Handheld.Vibrate();
            }
        }

        public void Quit()
        {
            Application.Quit();
            Debug.Log("Application Quit");
        }

        /*private void ButtonEffekt(Button button)
        {
            button.gameObject.transform.DOPunchScale(Vector3.one * .5f, 0.5f, 0, 0)
                .OnComplete(() => button.gameObject.transform.localScale = Vector3.one * 0.805f);
        }*/
        public void OpenPlates()
        {

            if (Knife.Instance.knifeRotationSpeed >= 50)
            {
                Knife.Instance.knifeRotationSpeed -= 1;
                GameData.Save_Turn--;
            }

            foreach (GameObject plate in plates)
            {
                plate.SetActive(false);
            }

            for (int i = 0; i < platesCount; i++)
            {
                plates[i].SetActive(true);

            }

            if (platesCount < 5)
            {
                levelUpgradeGameObject.SetActive(false);
            }
            else if (platesCount >= 5 && platesCount < 12)
            {
                levelUpgradeGameObject.SetActive(true);
                knifeIndex = 1;
                GameData.knifeIndex = 1;
                CamAnim.Instance.CamAnimation();
            }
            else
            {
                knifeIndex = 2;
                GameData.knifeIndex = 2;
            }

            Knife.Instance.GetKnife(knifeIndex);
            Knife.Instance.GetCircle(knifeIndex);
        }
        public void InstateEarnCanva(GameObject earnCanva, Vector3 earnCanvaPoint_position)
        {
            GameObject b = Instantiate(earnCanva, earnCanvaPoint_position, new Quaternion(0.116089985f, -0.219164997f, 0.0236491859f, 0.96846813f));

        }
    }
}