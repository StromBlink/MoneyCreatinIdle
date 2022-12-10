using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/* public enum CoinPosition_State { Press_1, Press_2 }; */

public class AnimationController : MonoBehaviour
{
    [SerializeField] Transform Coin;
    [SerializeField] Transform Press;
    [SerializeField] Transform Knife;

    [Header("Coin Path Transforms")]
    [SerializeField] Transform[] fallingPlace;
    [SerializeField] Transform pressPoint;
    [SerializeField] Transform[] fallingPlace_2;
    [SerializeField] Transform pressPoint_2;
    [SerializeField] Transform money_Box;

    [Header("Referance")]
    [SerializeField] Animator Conveyor_1;
    [SerializeField] Animator Conveyor_2;
    [SerializeField] Animator Conveyor_3;
    [SerializeField] ParticleSystem PressSteam;
    [SerializeField] ParticleSystem PressSteam_2;

    [Header("Animation")]
    [SerializeField] float Speed;

    float _conveyor_Speed;
    float _countDown = 0;
    float knifeRotatinSpeed;
    private void Start()
    {
        _conveyor_Speed = Speed;
        CoinPath(Coin, 1f, 1f);
        PressAnimation(Press, 1f, 0.3f, PressSteam);

    }
    void Update()
    {
        _countDown += Time.deltaTime * Speed;
        if (_countDown > 2.3f) { PressAnimation(Press, 1f / Speed, 0.3f / Speed, PressSteam); _countDown = 0; }
        SetAnimation(_conveyor_Speed);
        CutterAnimation(Knife, 10);
    }
    public void CoinPath(Transform coin, float time, float delay)
    {
        int randomInt = Random.Range(0, 4);
        coin.transform.DORotate(new Vector3(0, 0, 90), 1f);
        coin.transform.DOMove(fallingPlace[randomInt].position, time).OnComplete(() =>
        {
            coin.transform.DOMove(pressPoint.position, time).OnComplete(() =>
        {
            coin.transform.DORotate(new Vector3(0, 0, 90), 1f).SetDelay(0.2f);
            coin.transform.DOMove(fallingPlace_2[randomInt].position, time).SetDelay(delay).OnComplete(() =>
        {
            coin.transform.DOMove(pressPoint_2.position, time).OnComplete(() =>
        {
            coin.transform.DOMove(money_Box.position, time).SetDelay(delay).OnComplete(() =>
        {

        });

        });

        });

        });

        });

    }
    public void SetAnimation(float AnimationSpeed)
    {
        Conveyor_1.speed = AnimationSpeed;
        Conveyor_2.speed = AnimationSpeed;
    }
    public void PressAnimation(Transform Press, float time, float delay, ParticleSystem PressSteam)
    {
        Vector3 basePosition = Press.transform.position;
        Vector3 target = new Vector3(Press.transform.position.x, Press.transform.position.y - 0.1f, Press.transform.position.z);
        Press.transform.DOMove(target, time).OnStart(() => { _conveyor_Speed = 0; }).OnComplete(() =>
        {
            PressSteam.Play();
            Press.transform.DOMove(basePosition, time).SetDelay(delay).OnStart(() => { _conveyor_Speed = Speed; });
        });
    }
    public void CutterAnimation(Transform knife, float time)
    {
        knifeRotatinSpeed += Time.deltaTime * Speed * 100;
        knife.rotation = Quaternion.Euler(0, -180, knifeRotatinSpeed);

    }
}
