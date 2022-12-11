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
        [Header("Materials")] [SerializeField] private Material coinFirstStateMaterial;
        [SerializeField] private Material coinSecondStateMaterial;
        [SerializeField] private Material coinThirdStadeMaterial;

        [Header("Transforms")] [SerializeField]
        private Transform[] coinBases;

        private GameObject _coin;
        private GameObject _coinBackground;

        public int coinIndex = 1;

        public float time;
        public float timer;

        private void Update()
        {
            time += 1 * Time.deltaTime;
            if (time >= timer && GameManager.Instance.state == State.Gameplay)
            {
                time = 0;
                GetCoin();

            }
        }

        public void GetCoin()
        {
            _coin = PoolManager.Instance.GetPoolObject(0);
            _coinBackground = PoolManager.Instance.GetPoolObject(0);

            for (int i = 0; i < coinIndex; i++)
            {
                _coin.transform.position = coinBases[coinIndex % coinBases.Length].position;
                _coinBackground.transform.position = _coin.transform.position - Vector3.back * 0.1f;
            }
        }
    }
}
