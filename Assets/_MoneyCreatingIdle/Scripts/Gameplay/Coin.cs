using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KeyboredGames
{


    public class Coin : MonoBehaviour
    {
        [SerializeField] bool isConveyorSwtich;
        public PressMachine pressMachine;
        public PressMachine pressMachine_2;
        public Animator animator;
        public TrailRenderer trailRenderer;
        public Rigidbody rgdbody;

        public float coinSpeed;
        void OnEnable()
        {
            Vector3 fallingPoint = new Vector3(0.0132756457f, 0.250106752f, -7.21832323f);
            animator.enabled = false;
            animator.SetBool("Start", false);
            isConveyorSwtich = false;


            transform.DOMove(fallingPoint, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.DORotate(new Vector3(0, 0, 90), 0.3f);
                transform.DOJump(fallingPoint + Vector3.up * 0.05f, 0.1f, 1, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    animator.enabled = true;
                    animator.SetBool("Start", true);
                });
            });
            transform.DORotate(new Vector3(0, 0, 270), 0.5f);
            tag = "CylinderCoin";
        }

        void Update()
        {
            if (isConveyorSwtich) { pressMachine = pressMachine_2; }
            animator.speed = pressMachine.conveyorSpeed;

            if ((rgdbody.velocity).sqrMagnitude > 1f)
            {
                trailRenderer.gameObject.SetActive(true);
            }
            else
            {
                trailRenderer.gameObject.SetActive(false);
            }
        }


    }
}