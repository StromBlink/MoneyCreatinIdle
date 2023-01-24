using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace KeyboredGames
{

    public class CamAnim : MonoBehaviour
    {
        public static CamAnim Instance;
        private Vector3 _targetPoint;

        private void Awake()
        {
            Instance = this;
        }

        public void CamAnimation()
        {
            _targetPoint = new Vector3(0.0209999997f, 2.3499999f, -10.3210001f);
            transform.DOMove(_targetPoint,1.2f);
            transform.DORotate(new Vector3(27.6413708f,3.29428649f,2.00119495f),1f);
        }
        
        
    }
}