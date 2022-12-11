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

        [Header("Transforms")]
        [SerializeField]
        private Transform[] coinBases;

        [SerializeField] private GameObject blocks;
        [SerializeField] Transform invertory;
        private GameObject _coin;
        private GameObject _coinBackground;

        public int coinIndex = 1;

        public float time;
        public float timer;

        private void Update()
        {
            time += 1 * Time.deltaTime;
        }

        public void GetCoin()
        {
            _coin = PoolManager.Instance.GetPoolObject(0);
            _coinBackground = PoolManager.Instance.GetPoolObject(0);
            _coin.transform.position = coinBases[coinIndex].position;
            _coin.transform.SetParent(invertory);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Knife"))
            {
                GetCoin();
            }
        }
    }
}
