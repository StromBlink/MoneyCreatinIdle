using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatueGames.Foundation
{

    [CreateAssetMenu(fileName = "MarketInfo", menuName = "Market/MarketData")]
    public class MarketData : ScriptableObject
    {
        public string marketDataName;
        public MarketItemData[] marketItemDataes;
    }
    [System.Serializable]
    public class MarketItemData
    {
        [HideInInspector]
        public int id;
        [HideInInspector]
        public bool isUnlock;

        public string itemName;
        public CostType costType;
        public int cost;
        public Sprite sprite;
    }

    public enum CostType
    {
        Default,
        Coin,
        Gem,
        Progress,
        Ads
    }
    public enum MarketItemCostType
    {
        Default,
        Coin,
        Gem,
        Progress,
        Ads
    }
}