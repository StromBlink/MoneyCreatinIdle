using System;
using System.Collections;
using System.Collections.Generic;
using KeyboredGames;
using Unity.VisualScripting;
using UnityEngine;

namespace KeyboredGames
{
    public class CoinController : MonoBehaviour
    {

        [SerializeField] Animator animator;
        [Header("Transforms")]
        [SerializeField]
        private Transform coinBasePoint;

        [SerializeField] Transform invertory;
        [Header("EarnCanva")]
        [SerializeField] GameObject earnCanva;

        private GameObject _coin;
        static int sol;
        public void GetCoin()
        {
            _coin = PoolManager.Instance.GetPoolObject(0);
            _coin.transform.position = coinBasePoint.position;
            _coin.transform.SetParent(invertory);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Knife"))
            {


                GetCoin();
                animator.SetTrigger("Kesildi");

                animationspeed();

                Instantiate(earnCanva, coinBasePoint.position, new Quaternion(0.116089985f, -0.219164997f, 0.0236491859f, 0.96846813f));
                MyUiManager.instance.Vibrate();
                GameData.Coin += MyUiManager.instance.incomeCoin;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Knife"))
            {

                AudioManager.Instance.CutClip();
            }
        }
        void animationspeed()
        {
            int count = MyUiManager.instance.platesCount;
            switch (count)
            {
                case 1: animator.speed = 1; break;
                case 5: animator.speed = 0.7f; break;
                case 14: animator.speed = 0.4f; break;
            }
        }
    }
}
