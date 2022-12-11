using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace KeyboredGames
{
    enum WhichCoin { Coin, Coin_2 }
    public class PressMachine : MonoBehaviour
    {
        float _countDown = 0;
        [SerializeField] Transform press;
        [SerializeField] ParticleSystem pressSteam;
        [SerializeField] private float conveyorSpeed;
        [SerializeField] private Animator conveyorAnimator;


        private Vector3 _basePosition;
        private Vector3 _target;
        private bool _isPress;

        private AnimationController _animationController;
        private void Start()
        {
            _animationController = AnimationController.Instance;
            PressAnimation(press, 1f, 0.3f, pressSteam);
            _basePosition = press.transform.position;
            _target = new Vector3(press.transform.position.x, press.transform.position.y - 0.1f,
                press.transform.position.z);
        }

        private void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(press.position, Vector3.down, out hit, 25f))
            {
                if (hit.collider.gameObject.CompareTag("Coin") && !_isPress)
                {
                    _isPress = true;
                    PressAnimation(press, 1f / _animationController.animationSpeed, 0.3f / _animationController.animationSpeed, pressSteam);
                    hit.collider.gameObject.tag = "Player";
                }
            }

        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(press.position, Vector3.down);
        }

        public void PressAnimation(Transform press, float time, float delay, ParticleSystem pressSteam)
        {
            press.transform.DOMove(_target, time).OnStart(() => { conveyorSpeed = 0; })
            .OnComplete(() =>
            {
                pressSteam.Play();
                press.transform.DOMove(_basePosition, time).SetDelay(delay).OnStart(() =>
                {
                    conveyorSpeed = _animationController.animationSpeed;
                    _isPress = false;
                });
            });
        }
    }
}