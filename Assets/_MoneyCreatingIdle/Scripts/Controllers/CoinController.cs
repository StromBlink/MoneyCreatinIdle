using System;
using System.Collections;
using System.Collections.Generic;
using KeyboredGames;
using Unity.VisualScripting;
using UnityEngine;
using State = KeyboredGames.State;

public class CoinController : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material coinFirstStateMaterial;
    [SerializeField] private Material coinSecondStateMaterial;
    [SerializeField] private Material coinThirdStadeMaterial;

    [Header("Transforms")] 
    [SerializeField] private Transform[] coinBases;

    private GameObject _coin;
    
    public int coinIndex = 1;

    private float _time;
    private void Update()
    {
        _time += 1 * Time.deltaTime;
        
        if (_time >= 3 && GameManager.Instance.state == State.Gameplay);
        {
            GetCoin();
            _time = 0;
        }
    }

    public void GetCoin()
    {
        _coin = PoolManager.Instance.GetPoolObject(0);
        
        for (int i = 0; i < coinIndex; i++)
        {
            _coin.transform.position = coinBases[coinIndex % coinBases.Length].position;
            _coin.transform.position = coinBases[coinIndex % coinBases.Length].position - Vector3.back * 0.106f;
        }
    }
}
