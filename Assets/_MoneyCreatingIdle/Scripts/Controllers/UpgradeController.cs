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
            if (Input.GetMouseButtonUp(0))
            {
                MyUiManager.instance.coin++;
                GameData.Coin++;
            }
        }
    }
}