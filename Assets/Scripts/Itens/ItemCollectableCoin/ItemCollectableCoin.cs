using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectBase
{
    [SerializeField] ItemManager ItemManager;

    #region UNITY METHODS
    private void Start()
    {
        if(ItemManager == null)
        {
            ItemManager = FindObjectOfType<ItemManager>();
        }
    }
    #endregion

    #region PRIVATE METHODS
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.AddCoins(1);
    }
    #endregion

}
