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
        [Header("Materials")][SerializeField] private Material coinFirstStateMaterial;
        [SerializeField] private Material coinSecondStateMaterial;
        [SerializeField] private Material coinThirdStadeMaterial;
        [SerializeField] Animator animator;
        [Header("Transforms")]
        [SerializeField]
        private Transform coinBasePoint;
        [SerializeField] Transform invertory;
        private GameObject _coin;
        public void GetCoin()
        {
            _coin = PoolManager.Instance.GetPoolObject(0);
            /*  _coinBackground = PoolManager.Instance.GetPoolObject(0); */
            _coin.transform.position = coinBasePoint.position;
            _coin.transform.SetParent(invertory);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Knife"))
            {
                GetCoin();
                animator.SetTrigger("Kesildi");
            }
        }
    }
}
