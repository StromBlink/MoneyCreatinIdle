using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;


namespace KeyboredGames
{
    public class AnimationController : MonoBehaviour
    {
        public static AnimationController Instance;
        public float animationSpeed;

        private void Awake()
        {
            Instance = this;
        }
    }

}


