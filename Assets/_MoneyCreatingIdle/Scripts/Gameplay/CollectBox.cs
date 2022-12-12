using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace KeyboredGames
{

    public class CollectBox : MonoBehaviour
    {
        [SerializeField] Animator conveyor_Animator;
        [SerializeField] Transform other_Box;
        [SerializeField] Transform box_cover;

        List<Transform> transforms_Coins = new List<Transform>();
        private void Start()
        {
            conveyor_Animator.speed = 0;
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Coin"))
            {
                InBox(other);
                if (transforms_Coins.Count > 1)
                {
                    GoBox();
                }

            }
        }
        void InBox(Collider other)
        {
            other.GetComponent<Animator>().enabled = false;
            other.transform.SetParent(transform);
            transforms_Coins.Add(other.GetComponent<Transform>());

        }
        void GoBox()
        {
            conveyor_Animator.speed = 1;
            GetBox();

            box_cover.DOLocalRotateQuaternion(Quaternion.identity, 0.6f).SetEase(Ease.Linear);
            transform.DOMove(transform.position + Vector3.back, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                ClearLists();
                transform.position = new Vector3(1.90600002f, -0.379999995f, -6.79500008f);

            });
        }
        void GetBox()
        {


            Vector3 _conveyorTopPosition = new Vector3(1.12199998f, -0.379999995f, -6.79500008f);
            Vector3 _collectionArea = new Vector3(1.12199998f, -0.379999995f, -7.7670002f);

            other_Box.DOMove(_conveyorTopPosition, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            other_Box.GetChild(1).Rotate(new Vector3(240f, 0, 0));
            other_Box.DOMove(_collectionArea, 0.3f).SetEase(Ease.Linear);
            conveyor_Animator.speed = 0;
        });

        }
        void SetPoolObject()
        {
            foreach (var item in transforms_Coins)
            {
                PoolManager.Instance.SetPoolObject(item.gameObject, 0);

            }

        }
        void ClearLists()
        {
            SetPoolObject();
            transforms_Coins.Clear();

        }
    }
}
