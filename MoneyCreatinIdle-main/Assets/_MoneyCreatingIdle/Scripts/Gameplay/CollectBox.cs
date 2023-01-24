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
        int ID;
        private void Start()
        {
            conveyor_Animator.speed = 0;
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Coin") && ID != other.GetInstanceID())
            {
                ID = other.GetInstanceID();
                InBox(other);
                if (transforms_Coins.Count >= 35 && transforms_Coins.Count < 36)
                {
                    GoBox();
                }

            }
        }
        void InBox(Collider other)
        {

            other.transform.SetParent(transform);
            transforms_Coins.Add(other.GetComponent<Transform>());

        }
        void GoBox()
        {
            conveyor_Animator.speed = AnimationController.Instance.animationSpeed;
            GetBox();

            box_cover.DOLocalRotateQuaternion(Quaternion.identity, 0.6f).SetEase(Ease.Linear);
            transform.DOMove(transform.position + Vector3.back, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                conveyor_Animator.speed = 0;

                ClearLists();
                transform.position = new Vector3(1.90600002f, -0.379999995f, -6.79500008f);

            });
        }
        void GetBox()
        {
            Vector3 _conveyorTopPosition = new Vector3(1.12199998f, -0.379999995f, -6.79500008f);
            Vector3 _collectionArea = new Vector3(1.12199998f, -0.379999995f, -7.7670002f);

            other_Box.DOMove(_conveyorTopPosition, 0.3f).OnComplete(() =>
        {
            other_Box.GetChild(1).localRotation = new Quaternion(-0.878455997f, 0f, 0f, 0.477823377f);

            other_Box.DOMove(_collectionArea, 0.6f).SetEase(Ease.Linear);

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
