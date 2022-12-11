using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboredGames
{


    public class Coin : MonoBehaviour
    {
        public TrailRenderer trailRenderer;
        public Rigidbody rigidbody;
        
        
        void Update()
        {
            if ((rigidbody.velocity).sqrMagnitude > 1f)
            {
                trailRenderer.gameObject.SetActive(true);
            }
            else
            {
                trailRenderer.gameObject.SetActive(false);
            }
        }
    }
}