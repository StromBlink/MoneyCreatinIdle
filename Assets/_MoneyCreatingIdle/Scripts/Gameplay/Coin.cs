using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KeyboredGames
{
    enum State_WichDirection { Left, Right }

    public class Coin : MonoBehaviour
    {
        State_WichDirection state_WichDirection;
        [SerializeField] Transform leftPoint;
        [SerializeField] Transform rightPoint;
        [SerializeField] bool isConveyorSwtich;
        public PressMachine pressMachine;
        public PressMachine pressMachine2;
        public PressMachine pressMachine_level2;
        public PressMachine pressMachine2_level2;
        public Animator animator;
        public TrailRenderer trailRenderer;
        public Rigidbody rgdbody;
        public static int whichpoint;

        void OnEnable()
        {
            Vector3 fallingPoint = WhichFallingPoint();

            animator.enabled = false;
            isConveyorSwtich = false;


            transform.DOMove(fallingPoint, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.DORotate(new Vector3(0, 0, 90), 0.3f);
                transform.DOJump(fallingPoint + Vector3.up * 0.05f, 0.1f, 1, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    animator.enabled = true;
                    if (state_WichDirection == State_WichDirection.Left) animator.SetTrigger("Left");
                    if (state_WichDirection == State_WichDirection.Right) animator.SetTrigger("Right");
                });
            });
            transform.DORotate(new Vector3(0, 0, 270), 0.5f);
        }
        Vector3 WhichFallingPoint()
        {
            if (whichpoint % 2 == 0) { whichpoint++; state_WichDirection = State_WichDirection.Left; return leftPoint.position; }
            if (whichpoint % 2 != 0) { whichpoint++; state_WichDirection = State_WichDirection.Right; return rightPoint.position; }
            return Vector3.zero;
        }

        void Update()
        {
            if (isConveyorSwtich && state_WichDirection == State_WichDirection.Left) pressMachine = pressMachine2;
            if (state_WichDirection == State_WichDirection.Right) animator.speed = pressMachine.conveyorSpeed;
            if (isConveyorSwtich && state_WichDirection == State_WichDirection.Left)
            {
                pressMachine_level2 = pressMachine2_level2;

            }
            if (state_WichDirection == State_WichDirection.Left) animator.speed = pressMachine_level2.conveyorSpeed;


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