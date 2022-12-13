using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace KeyboredGames
{
    public class Knife : MonoBehaviour
    {
        public static Knife Instance;
        [SerializeField] Transform knife;
        private float _knifeRotation;
        public float knifeRotationSpeed;
        private void Awake()
        {
            Instance = this;
            knifeRotationSpeed = GameData.Save_Turn;
        }

        private void Update()
        {
            CutterAnimation(knife);
        }

        public void CutterAnimation(Transform knife)
        {

            _knifeRotation += Time.deltaTime * knifeRotationSpeed;
            knife.rotation = Quaternion.Euler(0, -180, _knifeRotation);
        }
    }
}