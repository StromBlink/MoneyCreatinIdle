using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace KeyboredGames
{

    public class PressMachine : MonoBehaviour
    {
        enum StateWhichMhacine { Crude, Coin };
        [SerializeField] StateWhichMhacine stateWhichMhacine;
        float _countDown = 0;
        [SerializeField] Transform press;
        [SerializeField] Transform earnCanvaPoint;
        [SerializeField] GameObject earnCanva;
        [SerializeField] ParticleSystem pressSteam;
        public float conveyorSpeed;
        [SerializeField] private Animator conveyorAnimator;


        private Vector3 _basePosition;
        private Vector3 _target;

        private string _tag = "Coin";
        int ID;

        private AnimationController _animationController;
        private void Start()
        {
            _animationController = AnimationController.Instance;
            _basePosition = press.transform.position;
            conveyorSpeed = _animationController.animationSpeed;
            _target = new Vector3(press.transform.position.x, press.transform.position.y - 0.1f,
                press.transform.position.z);

        }

        private void Update()
        {//We wrote vetcor3.up because the object pivot point is too low
            RaycastHit hit;
            if (Physics.Raycast(press.position, Vector3.up, out hit, 25f))
            {
                if (hit.collider.gameObject.CompareTag(_tag) && ID != hit.collider.gameObject.GetInstanceID())
                {

                    transform.DOPunchScale(Vector3.zero, 0.3f).OnComplete(() => { WhichPress(stateWhichMhacine, hit.collider.transform); });

                    PressAnimation(press, 1f / (_animationController.animationSpeed * 4), 0.3f / _animationController.animationSpeed, pressSteam);
                    ID = hit.collider.gameObject.GetInstanceID();
                }
            }

            conveyorAnimator.speed = conveyorSpeed;

        }
        void WhichPress(StateWhichMhacine stateWhichMhacine, Transform transform)
        {
            if (stateWhichMhacine == StateWhichMhacine.Crude)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);

            }
            if (stateWhichMhacine == StateWhichMhacine.Coin)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);

            }

        }

        public void PressAnimation(Transform press, float time, float delay, ParticleSystem pressSteam)
        {
            MyUiManager.instance.coin += MyUiManager.instance.incomeCoin;
            GameData.Coin += MyUiManager.instance.incomeCoin;
            press.transform.DOMove(_target, time).OnStart(() => { conveyorSpeed = 0; })
            .OnComplete(() =>
            {
                MyUiManager.instance.InstateEarnCanva(earnCanva, earnCanvaPoint.position);
                pressSteam.Play();
                press.transform.DOMove(_basePosition, time).SetDelay(delay).OnStart(() =>
                {
                    conveyorSpeed = _animationController.animationSpeed;

                });
            });
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Vector3 target = new Vector3(press.position.x, press.position.y + 2f, press.position.z);
            Gizmos.DrawLine(press.position, target);
        }
    }
}