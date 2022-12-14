using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using MoreMountains.NiceVibrations;
namespace KeyboredGames
{
    public class UpgradeController : MonoBehaviour
    {
        [SerializeField] GameObject earnCanvas;
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

                    MMVibrationManager.Haptic(HapticTypes.Selection);

                    Vector3 tochPoint = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
                    touchParticle.transform.position = Camera.main.ScreenToWorldPoint(tochPoint);

                    touchParticle.Play();
                    MyUiManager.instance.InstateEarnCanva(earnCanvas, Camera.main.ScreenToWorldPoint(tochPoint));
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    Time.timeScale = 1;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Time.timeScale = 1;
                }
            }
        }


    }
}