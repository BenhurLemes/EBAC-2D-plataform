using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ebac.core.Singleton;

public class GameManager : Singleton<GameManager>
{
    [Header("Players")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<EnemyPrefs> enemiePrefs;

    [Header("preferences")]
    public Transform StartPoint;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = 1f;
    public Ease ease = Ease.OutBack;

    private GameObject _currentPlayer;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = StartPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);

    }
}
