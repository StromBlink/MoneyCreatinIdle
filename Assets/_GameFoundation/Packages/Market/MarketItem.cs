using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KeyboredGames
{

    public class MarketItem : MonoBehaviour
    {
        public GameObject[] costIcon;
        public TextMeshProUGUI textCost;
        public TextMeshProUGUI textName;
        public TextMeshProUGUI textAdsFree;
        private bool isSelect = false;


        public GameObject selected;
        public GameObject select;
        public GameObject objCost;
        public GameObject objAds;
        public Image imageItem;
        public Image sliderAds;
        public MarketItemData marketItemData;
        int adsvalue;

        public string dataSaveString = "item {0}";


        public void InitItem()
        {
            GetComponent<Button>().onClick.AddListener(() => { Click_List(); });
        }

        public void SetList()
        {
            selected.SetActive(false);
            select.SetActive(false);
            objCost.SetActive(false);
            objAds.SetActive(false);


            textName.text = marketItemData.itemName;


            //Unlock check
            if (marketItemData.id == 0)
            {
                marketItemData.isUnlock = true;
            }
            else
            {
                marketItemData.isUnlock = PlayerPrefs2.GetBool(string.Format(dataSaveString, marketItemData.id));
            }


            imageItem.sprite = marketItemData.sprite;
            //imageItem.SetNativeSize();

            if (marketItemData.isUnlock)
            {
                //Turn on the select button when unlocked
                select.SetActive(true);
            }
            else
            {
                //If not unlocked, set to suit the purchase type
                for (int i = 0; i < costIcon.Length; i++) { costIcon[i].SetActive(false); }

                switch (marketItemData.costType)
                {
                    //Purchase with coins
                    case CostType.Coin:
                        costIcon[0].SetActive(true);
                        objCost.SetActive(true);
                        break;
                    //Purchase with gems
                    case CostType.Gem:
                        costIcon[1].SetActive(true);
                        objCost.SetActive(true);
                        break;
                    //Purchase with ads
                    case CostType.Ads:
                        adsvalue = PlayerPrefs.GetInt(string.Format(dataSaveString, marketItemData.id) + "adsValue", 3);
                        //Debug.Log("AA : " + adsvalue);
                        sliderAds.fillAmount = (float)adsvalue / (float)3;
                        //Debug.Log("Bb : " + (float)adsvalue / (float)3);
                        textAdsFree.text = string.Format("watchAd" + "\n<color=#ffffff><size=20>{0}/3</size></color>", adsvalue);

                        objAds.SetActive(true);
                        break;
                }


            }
        }

        public void UnSelect()
        {
            if (!isSelect) return;
            isSelect = false;

            selected.gameObject.SetActive(false);
            select.gameObject.SetActive(true);
        }

        public void Select()
        {
            if (isSelect) return;
            isSelect = true;


            if (MarketManager.Instance.currenMarketSelectedItem != null)
            {
                MarketManager.Instance.currenMarketSelectedItem.UnSelect();
            }
            else
            {

                Debug.LogWarning("SELECTEDNONFOUND");
            }


            MarketManager.Instance.currenMarketSelectedItem = this;
            selected.gameObject.SetActive(true);
            select.gameObject.SetActive(false);

        }


        public void Click_List()
        {
            if (marketItemData.isUnlock)
            {
                Select();
                MarketManager.Instance.Select(marketItemData.id);
            }
            else
            {
                Buy();
            }
        }

        //Purchase
        void Buy()
        {
            if (GameData.Coin >= marketItemData.cost)
            {
                //There is enough money
                 BuySuccess();
            }
            else
            {
                //Not enough money
                //PlayManager.Instance.commonUI.SetToast("noCoin");
            }
        }

        public void BuySuccess()
        {
            switch (marketItemData.costType)
            {
                case CostType.Coin:
                    GameData.Coin -= marketItemData.cost;
                    //PlayManager.Instance.commonUI._CoinGem.SetCoin();
                    break;

                case CostType.Gem:
                    GameData.Gem -= marketItemData.cost;
                    //PlayManager.Instance.commonUI._CoinGem.SetGem();
                    break;
            }

            //SoundManager.Instance.PlayEffect(SoundList.sound_common_sfx_get_skinmp3);
            //AchievementManager.Instance.CoverBuyed();
            ItemUnlockByID();
            SetList();
        }

        void ItemUnlockByID()
        {
            PlayerPrefs2.SetBool(string.Format(dataSaveString, marketItemData.id), true);
        }
    }
}