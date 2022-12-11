using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace KeyboredGames
{
    public class PressMachine : MonoBehaviour
    {
        float _countDown = 0;
        [SerializeField] Transform press;
        [SerializeField] ParticleSystem pressSteam;
        [SerializeField] private float conveyorSpeed;
        [SerializeField] private Animator conveyorAnimator;

        private Vector3 _basePosition;
        private Vector3 _target;

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
            if (_countDown > 2.3f)
            {
                PressAnimation(press, 1f / _animationController.animationSpeed, 0.3f / _animationController.animationSpeed, pressSteam);
                _countDown = 0;
            }
            _countDown += Time.deltaTime * _animationController.animationSpeed;
            conveyorAnimator.speed = conveyorSpeed;
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
                    });
                });
        }
    }
}