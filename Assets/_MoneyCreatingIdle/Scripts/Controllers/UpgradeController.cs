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
            }
            if (Input.GetMouseButtonUp(0))
            {
                MyUiManager.instance.coin++;
                GameData.Coin++;
                Time.timeScale = 1;
            }
        }
    }
}