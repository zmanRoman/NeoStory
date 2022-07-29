using Script.IAP;
using UnityEngine;
using UnityEngine.Events;

public class HandlerUserWallet : MonoBehaviour
{
    // free choise and outfit
    [SerializeField]private bool isNeoUnlimited;
    public bool IsNeoUnlimited => isNeoUnlimited;

    // Сердца
    [SerializeField]
    private int coins;
    public int Coins => coins;
    public CoinsData CoinsData { get; private set; }

    // Звезды
    [SerializeField]
    private int points;
    public int Points => points;

    public PointData PointData { get; private set; }

    // Премиум валюта
    [SerializeField]
    private int premium;
    public int Premium => premium;
    public PremiumData PremiumData { get; private set; }


    [HideInInspector]public UnityEvent updateWallet = new ();

    public static HandlerUserWallet Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetNeoUnlimited(bool neoUnlimited)
    {
        isNeoUnlimited = neoUnlimited;
        if(IAPUIHelper.Instance != null) IAPUIHelper.Instance.BlockUnlim(neoUnlimited);
    }
    
    //изменение значения исключительно локально
    public void CoinsPlus(int value)
    {
        coins += value;
        updateWallet.Invoke();
    }
    
    //изменение значения исключительно локально
    public void CoinsMinus(int value)
    {
        coins -= value;
        updateWallet.Invoke();
    }

    public void SetUserBalance(Player walletData)
    {
        //данные с сервера
        points = walletData.points;
        PointData = new PointData( walletData.points, walletData.pointsAdded);

        coins = walletData.coins;
        CoinsData = new CoinsData( walletData.coins, walletData.coinsAdded);
        
        premium = walletData.premium;
        PremiumData = new PremiumData( walletData.premium, walletData.premiumAdded);
        
        updateWallet.Invoke();
    }
    
    public void SetUserBalance(int coins, int premium)
    {
        //данные с сервера

        this.coins = coins;
        CoinsData = new CoinsData(coins, 0);
        
        this.premium =  premium;
        PremiumData = new PremiumData(premium, 0);
        
        updateWallet.Invoke();
    }
}
