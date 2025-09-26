using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] int coinAmount = 0;

    public int getCoinAmount()
    {
        return coinAmount;
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coinAmount = 0;
    }

    public void AddCoins(int amount)
    {
        coinAmount += amount;
        Debug.Log("Coins: " + coinAmount);
    }
}
