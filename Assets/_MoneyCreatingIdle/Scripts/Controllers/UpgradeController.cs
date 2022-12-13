using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace KeyboredGames
{
    public class UpgradeController : MonoBehaviour
    {

        [SerializeField] private ParticleSystem touchParticle;
        private Touch touch;
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    Time.timeScale = 1.5f;
                    MyUiManager.instance.coin += MyUiManager.instance.incomeCoin;
                    GameData.Coin += MyUiManager.instance.incomeCoin;
                    Time.timeScale = 1;
                    MyUiManager.instance.Vibrate();

                    Vector3 tochPoint = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
                    touchParticle.transform.position = Camera.main.ScreenToWorldPoint(tochPoint);

                    touchParticle.Play();
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Time.timeScale = 1;
                }
            }
        }
    }
}