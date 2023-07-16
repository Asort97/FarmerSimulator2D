using UnityEngine;
using UnityEngine.UI;
using System;

public class SoldShopButton : MonoBehaviour
{
    [SerializeField] private FruitSO fruit;
    [SerializeField] private int priceSold;
    public static Action<FruitSO, int> OnSoldFruit;
    private Button soldButton;

    private void Start()
    {
        soldButton = GetComponent<Button>();
        soldButton.onClick.AddListener(SoldFruits);
    }

    private void SoldFruits()
    {
        OnSoldFruit?.Invoke(fruit, priceSold);
    }
}
