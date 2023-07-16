using UnityEngine;
using UnityEngine.UI;
using System;

public class SoldShopButton : MonoBehaviour
{
    [SerializeField] private FruitSO fruit;
    [SerializeField] private int priceSold;
    public static Action<FruitSO> OnBuyingSeed;
    private PlayerStats playerStats;
    private Button soldButton;
    private void Start()
    {
        soldButton = GetComponent<Button>();
        soldButton.onClick.AddListener(SoldFruits);
    }
    private void SoldFruits()
    {

    }
}
