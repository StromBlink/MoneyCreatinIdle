using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace KeyboredGames
{
    public class EarnMoney : MonoBehaviour
    {
        [SerializeField] RectTransform rectTransform;
        [SerializeField] TMP_Text text;

        private void OnEnable()
        {
            text.SetText($"+" + MyUiManager.instance.incomeCoin.ToString());
            rectTransform.DOMoveY(3, 5f);
            text.DOFade(1, 0.7f);
            Destroy(gameObject, 0.8f);
        }
    }
}