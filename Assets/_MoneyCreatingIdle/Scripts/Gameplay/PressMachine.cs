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
        float _countDown = 0;
        [SerializeField] Transform press;
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
        {
            RaycastHit hit;
            if (Physics.Raycast(press.position, Vector3.down, out hit, 25f))
            {
                if (hit.collider.gameObject.CompareTag(_tag) && ID != hit.collider.gameObject.GetInstanceID())
                {
                    PressAnimation(press, 1f / (_animationController.animationSpeed * 4), 0.3f / _animationController.animationSpeed, pressSteam);
                    ID = hit.collider.gameObject.GetInstanceID();
                }
            }

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