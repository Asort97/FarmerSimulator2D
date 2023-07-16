using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject shopSeedPanel;
    [SerializeField] private GameObject soldFruitsPanel;
    [SerializeField] private GameObject instrumentPanel;
    [SerializeField] private GameObject shopPanel;

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
    }

    public void EnableSeedPan()
    {
        soldFruitsPanel.SetActive(false);
        instrumentPanel.SetActive(false);
        shopSeedPanel.SetActive(true);
    }

    public void EnableSoldFruits()
    {
        soldFruitsPanel.SetActive(true);
        instrumentPanel.SetActive(false);
        shopSeedPanel.SetActive(false);
    }        

    public void EnableInstrPan()
    {
        soldFruitsPanel.SetActive(false);
        instrumentPanel.SetActive(true);
        shopSeedPanel.SetActive(false);
    }                
    
}
