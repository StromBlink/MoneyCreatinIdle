using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace KeyboredGames
{
    public class UpgradeController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1.5f;
                MyUiManager.instance.coin += MyUiManager.instance.incomeCoin;
                GameData.Coin += MyUiManager.instance.incomeCoin;
                Time.timeScale = 1;
            }
            
        }
    }
}