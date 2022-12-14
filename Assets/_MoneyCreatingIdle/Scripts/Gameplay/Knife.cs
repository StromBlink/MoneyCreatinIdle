using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace KeyboredGames
{
    public class Knife : MonoBehaviour
    {
        public static Knife Instance;
        [SerializeField] Transform knifeMechanic;
        private float _knifeRotation;
        public float knifeRotationSpeed;
        public GameObject[] knifes;
        public GameObject[] circles;

        private void Awake()
        {
            Instance = this;
            knifeRotationSpeed = GameData.Save_Turn;
        }

        private void Update()
        {
            CutterAnimation(knifeMechanic);
        }

        public void CutterAnimation(Transform knife)
        {

            _knifeRotation += Time.deltaTime * knifeRotationSpeed;
            knife.rotation = Quaternion.Euler(0, -180, _knifeRotation);
        }

        public void GetKnife(int index)
        {
            foreach (GameObject knife in knifes)
            {
                knife.SetActive(false);
            }
            knifes[index].SetActive(true);
        }
        public void GetCircle(int index)
        {
            circles[index].SetActive(true);
        }
    }
}