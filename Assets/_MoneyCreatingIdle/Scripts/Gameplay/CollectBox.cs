using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace KeyboredGames
{

    public class CollectBox : MonoBehaviour
    {
        List<Rigidbody> rigidbodies_Coins = new List<Rigidbody>();
        List<Transform> transforms_Coins = new List<Transform>();
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Coin"))
            {
                other.GetComponent<Animator>().enabled = false;
                rigidbodies_Coins.Add(other.GetComponent<Rigidbody>());
                transforms_Coins.Add(other.GetComponent<Transform>());
                if (rigidbodies_Coins.Count > 5)
                {
                    GoBox();
                }

            }
        }
        void InBox()
        {
            foreach (var item in rigidbodies_Coins)
            {
                item.isKinematic = true;

            }
        }
        void GoBox()
        {
            InBox();
            transform.DOMove(transform.position + Vector3.back, 1f);
            foreach (var item in transforms_Coins)
            {
                 item.DOMove(transform.position + Vector3.back, 1f);
                 PoolManager.Instance.SetPoolObject(item.gameObject,0);
            } 
        }

    }
}
