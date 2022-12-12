using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboredGames
{
    public class AudioManager : MonoBehaviour
    {
        [Header("AudioSources")]
        public AudioSource effectSource;

        [Header("AudioClips")] 
        public AudioClip uiEffect;
        public AudioClip cutEffect;
        public AudioClip moneyFalling;
        public AudioClip firstPress;
        public AudioClip secondPress;
        public AudioClip inTheChest;
        
        
        public static AudioManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void UIClip()
        {
            effectSource.clip = uiEffect;
            effectSource.Play();
        }

        public void CutClip()
        {
            effectSource.clip = cutEffect;
            effectSource.Play();
        }

        public void MoneyFallingClip()
        {
            effectSource.clip = moneyFalling;
            effectSource.Play();
        }
        
        public void FirstPressClip()
        {
            effectSource.clip = firstPress;
            effectSource.Play();
        }

        public void SecondPressClip()
        {
            effectSource.clip = secondPress;
            effectSource.Play();
        }
        
        public void InTheChestsClip()
        {
            effectSource.clip = inTheChest;
            effectSource.Play();
        }
        
    }
}