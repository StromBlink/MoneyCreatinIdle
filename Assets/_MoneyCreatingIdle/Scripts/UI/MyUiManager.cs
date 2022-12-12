using System;
using System.Collections;
using System.Collections.Generic;
using KeyboredGames;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MyUiManager : MonoBehaviour
{
    public static MyUiManager instance;
    
    [Header("Texts")] 
    public TextMeshProUGUI cointext;
    public TextMeshProUGUI incomeButtonCoinText;
    public TextMeshProUGUI countButtonCoinText;
    public TextMeshProUGUI speedButtonCoinText;

    [Header("Buttons")] 
    public Button incomeButton;
    public Button countButton;
    public Button speedButton;
    public Button settingButton;

    [Header("Slider")] 
    public Slider audioSlider;

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
        audioSlider.value = GameData.Slider;
    }

    private void Update()
    {
        cointext.text = coin.ToString();
        incomeButtonCoinText.text = incomeCoin.ToString();
        countButtonCoinText.text = countCoin.ToString();
        speedButtonCoinText.text = speedCoin.ToString();
        GameData.Slider = audioSlider.value;
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
        settingPanel.SetEnabled(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        settingPanel.SetEnabled(false);
    }

    public void Sound()
    {
        AudioManager.Instance.effectSource.volume = audioSlider.value * 10;
    }

    public void Mute()
    {
        AudioManager.Instance.effectSource.volume = 0;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
