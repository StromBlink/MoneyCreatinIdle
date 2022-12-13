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
        [Header("Materials")]
        [SerializeField] private Material coinFirstStateMaterial;
        [SerializeField] private Material coinSecondStateMaterial;

        [Header("Meshes")]
        [SerializeField] private MeshRenderer firtMesh;
        [SerializeField] private MeshRenderer stampMesh;

        [SerializeField] Animator animator;
        [Header("Transforms")]
        [SerializeField]
        private Transform coinBasePoint;
        [SerializeField] Transform invertory;
        [Header("EarnCanva")]
        [SerializeField] GameObject earnCanva;

        private GameObject _coin;
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
                Instantiate(earnCanva, coinBasePoint.position, new Quaternion(0.116089985f, -0.219164997f, 0.0236491859f, 0.96846813f));
                MyUiManager.instance.coin += MyUiManager.instance.incomeCoin;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Knife"))
            {
                AudioManager.Instance.CutClip();
            }
        }
    }
}
