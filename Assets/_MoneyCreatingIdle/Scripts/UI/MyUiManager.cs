using System;
using System.Collections;
using System.Collections.Generic;
using KeyboredGames;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public enum VibrationState { on, of };
public class MyUiManager : MonoBehaviour
{
    public static MyUiManager instance;
    public VibrationState vibrationState;
    [Header("Texts")]
    public TMP_Text cointext;
    public TMP_Text incomeButtonCoinText;
    public TMP_Text countButtonCoinText;
    public TMP_Text speedButtonCoinText;

    [Header("Buttons")]
    public Button incomeButton;
    public Button countButton;
    public Button speedButton;

    /* [Header("Slider")]
    public Slider audioSlider; */

    [Header("Panels")]
    public Image settingPanel;

    [Header("Particles")]
    public ParticleSystem incomeParticle;
    public ParticleSystem countParticle;
    public ParticleSystem speedParticle;

    [Header("Coins")]
    public int coin;
    public int incomeCoin;
    public int countCoin;
    public int speedCoin;

    private void Awake()
    {
        instance = this;
        coin = GameData.Coin;
        incomeCoin = GameData.SavePlayerSpec1;
        countCoin = GameData.SavePlayerSpec2;
        speedCoin = GameData.SavePlayerSpec3;
        /*  audioSlider.value = GameData.Slider; */
    }

    private void Update()
    {
        cointext.SetText(coin.ToString());
        incomeButtonCoinText.SetText(incomeCoin.ToString());
        countButtonCoinText.SetText(countCoin.ToString());
        speedButtonCoinText.SetText(speedCoin.ToString());
        /*  GameData.Slider = audioSlider.value; */
    }

    public void Income()
    {
        if (coin >= incomeCoin)
        {
            coin -= incomeCoin;
            GameData.Coin -= incomeCoin;
            incomeCoin++;
            GameData.SavePlayerSpec1++;
        }
    }

    public void Count()
    {
        if (coin >= countCoin)
        {
            coin -= countCoin;
            GameData.Coin -= countCoin;
            countCoin++;
            GameData.SavePlayerSpec2++;

        }
    }

    public void Speed()
    {
        if (coin >= speedCoin)
        {
            coin -= speedCoin;
            GameData.Coin -= speedCoin;
            speedCoin++;
            GameData.SavePlayerSpec3++;
            AnimationController.Instance.animationSpeed += .5f;
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
}
