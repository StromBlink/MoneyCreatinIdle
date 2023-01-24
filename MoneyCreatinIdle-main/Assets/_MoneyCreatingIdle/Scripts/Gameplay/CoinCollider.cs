using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Coin"))
        {
            other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<Animator>().enabled = false;
        }
    }
}
