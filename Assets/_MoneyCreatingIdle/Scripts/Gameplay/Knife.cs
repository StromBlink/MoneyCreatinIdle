using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace KeyboredGames
{
    public class Knife : MonoBehaviour
    {
        [SerializeField] Transform knife;
        private float _knifeRotatinSpeed;

        private void Update()
        {
            CutterAnimation(knife);
        }

        public void CutterAnimation(Transform knife)
        {
            _knifeRotatinSpeed += Time.deltaTime * AnimationController.Instance.animationSpeed * 100;
            knife.rotation = Quaternion.Euler(0, -180, _knifeRotatinSpeed);
        }
    }
}