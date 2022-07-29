using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.UI_Handler
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class UpdateCoinsUI : MonoBehaviour
    {
        [SerializeField]private Enums.Currency currentCurrency =  Enums.Currency.coins;
        [SerializeField] private GameObject UnlimIcon;
        private TextMeshProUGUI _currencyText;
        
        private void Start()
        {
            _currencyText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            StartCoroutine(Subscribe());
        }
        private void OnDisable()
        {
            HandlerUserWallet.Instance.updateWallet.RemoveListener(UpdateUI);
        }

        private IEnumerator Subscribe()
        {
            yield return new WaitUntil(() => HandlerUserWallet.Instance != null);
            HandlerUserWallet.Instance.updateWallet.AddListener(UpdateUI);
            if (SceneManager.GetActiveScene().buildIndex == 1)
                UpdateUI();
        }
        // Update is called once per frame
        private void UpdateUI()
        {
            StopAllCoroutines();
            switch (currentCurrency)
            {
                case Enums.Currency.coins:
                    StartCoroutine(SmoothChange(HandlerUserWallet.Instance.CoinsData));
                    break;
                case Enums.Currency.points:
                    StartCoroutine(SmoothChange(HandlerUserWallet.Instance.PointData));
                    break;
                case Enums.Currency.premium:
                    StartCoroutine(SmoothChange(HandlerUserWallet.Instance.PremiumData));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (HandlerUserWallet.Instance.IsNeoUnlimited && SceneManager.GetActiveScene().buildIndex == 1)
            {
                switch (currentCurrency)
                {
                    case Enums.Currency.coins:
                    case Enums.Currency.premium:
                        UnlimIcon.SetActive(true);
                        _currencyText.gameObject.SetActive(false);
                        break;
                    case Enums.Currency.points:
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                if(SceneManager.GetActiveScene().buildIndex == 1) UnlimIcon.SetActive(false);
                _currencyText.gameObject.SetActive(true);
            }
        }
        
        private IEnumerator SmoothChange(CurrencyData currencyData)
        {
            var currTime = 0f;
            const float time = 1.3f;

            yield return new WaitUntil(() => LoadingHelper.Instance.LoadingEnd);
            yield return new WaitForSeconds(0.3f);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                switch (currentCurrency)
                {
                    case Enums.Currency.coins:
                        if (currencyData.CurrencyAdded != 0)
                        {
                            GiftAnimated.Instance.AddCoin(currencyData.CurrencyAdded);
                        }
                        break;
                    case Enums.Currency.points:
                        if (currencyData.CurrencyAdded != 0)
                        {
                            GiftAnimated.Instance.AddPoint(currencyData.CurrencyAdded);
                        }
                        break;
                    case Enums.Currency.premium:
                        if (currencyData.CurrencyAdded != 0)
                        {
                            GiftAnimated.Instance.AddPremium(currencyData.CurrencyAdded);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            //задержка для того чтобы анимация добавления сердец поспевала
            yield return new WaitForSeconds(0.3f);
            do
            {
                //TODO сделать что-то с парсингом из текста в число, идиотически если честно
                var curRoundToInt = Mathf.RoundToInt(float.Parse(_currencyText.text));
            
                curRoundToInt = (int)Mathf.Lerp(curRoundToInt, currencyData.Currency, currTime / time);

                _currencyText.text = curRoundToInt.ToString();

                currTime += Time.deltaTime;
                yield return null;
            } while (currTime <= time);

            //чтобы значения гарантированно были актуальные
            _currencyText.text = currencyData.Currency.ToString();
        }
    }
}
