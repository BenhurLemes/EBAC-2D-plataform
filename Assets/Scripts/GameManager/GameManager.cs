using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Ebac.core.Singleton;

public class GameManager : Singleton<GameManager>
{
    [Header("Variáveis Players")]
    private GameObject _currentPlayer;
    public GameObject playerPrefab;

    //--------------------------//

    [Header("Variáveis Enemies")]
    public List<EnemyPrefs> enemiePrefs;

    //--------------------------//

    [Header("Variáveis privadas")]
    public Transform StartPoint;

    //--------------------------//

    [Header("Variáveis Animação")]
    public float duration = .2f;
    public float delay = 1f;
    public Ease ease = Ease.OutBack;

    //--------------------------//

    [Header("Variáveis Moedas")]
    [SerializeField] private TextMeshProUGUI textCoin;
    [SerializeField] ItemManager itemManager;

    #region UNITY METHODS
    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        textCoin.text = itemManager.getCoinAmount().ToString();
    }
    #endregion

    #region PRIVATE METHODS
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
    #endregion
}
