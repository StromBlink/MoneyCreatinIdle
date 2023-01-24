using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;
namespace KeyboredGames
{
    public enum State_WichDirection { Left, Right }

    public class Coin : MonoBehaviour
    {
        public State_WichDirection state_WichDirection;
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
            MMVibrationManager.Haptic(HapticTypes.Selection);
            defaultMesh();
            animator.enabled = false;
            isConveyorSwtich = false;

            Vector3 fallingPoint = WhichFallingPoint();
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
            print(MyUiManager.knifeIndex);
            if (whichpoint % 2 == 0 && MyUiManager.knifeIndex > 0) { whichpoint++; state_WichDirection = State_WichDirection.Left; return leftPoint.position; }
            else /* if (whichpoint % 2 != 0 || MyUiManager.knifeIndex <= 4)  */{ whichpoint++; state_WichDirection = State_WichDirection.Right; return rightPoint.position; }

        }
        void defaultMesh()
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
        }

        void Update()
        {
            if (isConveyorSwtich && state_WichDirection == State_WichDirection.Right) pressMachine = pressMachine2;
            if (state_WichDirection == State_WichDirection.Right) animator.speed = pressMachine.conveyorSpeed;
            if (isConveyorSwtich && state_WichDirection == State_WichDirection.Left) pressMachine_level2 = pressMachine2_level2;
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