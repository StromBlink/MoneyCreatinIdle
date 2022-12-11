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
            animator.SetBool("Start", false);
            isConveyorSwtich = false;
            Vector3 fallingPoint = new Vector3(0.0132756457f, 0.250106752f, -7.21832323f);
            transform.DOMove(fallingPoint, 10f).SetEase(Ease.Linear).OnComplete(() => { animator.SetBool("Start", true); });
            //Domove calismiyor sadece 10 saniye sonra Oncomplete calisiyor


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