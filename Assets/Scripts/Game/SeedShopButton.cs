using UnityEngine;
using System;
using UnityEngine.UI;

public class SeedShopButton : MonoBehaviour
{
    [SerializeField] private SeedSO seed;
    [SerializeField] private int price;
    private Button buyButton;
    public static Action<SeedSO, int> OnBuyingSeed;

    private void Start()
    {
        buyButton = GetComponent<Button>();
        buyButton.onClick.AddListener(BuySeed);
    }

    public void BuySeed()
    {
        OnBuyingSeed?.Invoke(seed, price);
    }
}
