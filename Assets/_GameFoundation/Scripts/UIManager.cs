 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KeyboredGames
{
    public class UIManager : MonoBehaviour
    {
        
        public Canvas menuCanvas;
        public Canvas endCanvas;
        public Canvas lossCanvas;
        public Canvas rewardCanvas;
        public Canvas market;
        public TMP_Dropdown skinSelect;
        
        
        private Canvas currentCanvas;
        
        private void Start() 
        {
            EventManager.Instance.levelEnd += GameEnded;
            EventManager.Instance.playerWatchRewarded += GameReward;
            EventManager.Instance.levelLose += GameLoss;
            menuCanvas.enabled = true;
            Click_Skin1();
            skinSelect.value = GameData.SavePlayerSkin1;
        }

        

        public void Click_Spec1()
        {
            GameData.SavePlayerSpec1 += 1;
            EventManager.Instance.PlayerSpecChanged();
        } 

        public void Click_Spec2()
        {
            GameData.SavePlayerSpec2 += skinSelect.value;
            EventManager.Instance.PlayerSpecChanged();
        } 

        public void Click_Spec3()
        {
            GameData.SavePlayerSpec3 += 1;
            EventManager.Instance.PlayerSpecChanged();
        }

        public void Click_Skin1()
        {
            GameData.SavePlayerSkin1 = skinSelect.value;
            EventManager.Instance.PlayerSkinChanged();
           // Debug.Log("Click Skın" +skinSelect.value); // skinSelect.value değeri değişecek.

        }

        public void Click_Play()
        {
            EventManager.Instance.LevelStart(); 
            DisableAllCanvases();
        }

        public void Click_Revive()
        {
            EventManager.Instance.PlayerRevive();
            DisableAllCanvases();
        }

        public void Click_Reward()
        {
            EventManager.Instance.PlayerReward();
        }

        public void GameEnded(int a,int b)     
        {
            DisableAllCanvases();
            endCanvas.enabled = true;
        }

        public void GameLoss()
        {
            DisableAllCanvases();
            lossCanvas.enabled = true;
        }

        public void GameReward()
        {
            DisableAllCanvases();
            rewardCanvas.enabled = true;
        }

        public void GameMenu ()
        {
            DisableAllCanvases();
            EventManager.Instance.GameMenu();
            menuCanvas.enabled = true;
        }
        public void OpenMarketMenu()
        {
            DisableAllCanvases();
            market.enabled = true;
            EventManager.Instance.GameMenuChanged(true);
        }

        public void CloseMarketMenu()
        {
            DisableAllCanvases();
            menuCanvas.enabled = true;
            EventManager.Instance.GameMenuChanged(false);
          
        }

        public void ChooseWeapon(int startSkinValue)
        {
            EventManager.Instance.PlayerSkinShown(startSkinValue); // Invoke ediliyor.
        }

        public void BuyWeapon(int save)
        {
            GameData.SavePlayerSkin1 = save;
            EventManager.Instance.PlayerSkinShown(save);
        }
        
        
        private void DisableAllCanvases()
        {
            menuCanvas.enabled = false;
            endCanvas.enabled = false;
            lossCanvas.enabled = false;
            rewardCanvas.enabled = false;
            market.enabled = false;
        } 
    }
}