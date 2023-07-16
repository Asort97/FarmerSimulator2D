using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text selectedModeText;
    [SerializeField] private TMP_Text selectedSeedText;
    [SerializeField] private GameObject shopSeedPanel;
    [SerializeField] private GameObject soldFruitsPanel;
    [SerializeField] private GameObject instrumentPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private TMP_Text currentDayText;
    [SerializeField] private TMP_Text totalMoneyText;
    [SerializeField] private TMP_Text currentLevelText;
    [SerializeField] private TMP_Text currentLevelInstrText;
    [SerializeField] private TMP_Text fruitStrawberryCountT;
    [SerializeField] private TMP_Text fruitMelonCountT;
    [SerializeField] private TMP_Text fruitCornCountT;
    [SerializeField] private TMP_Text seedStrawberryCountT;
    [SerializeField] private TMP_Text seedMelonCountT;
    [SerializeField] private TMP_Text seedCornCountT;

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = PlayerStats.Instance;
    }

    private void OnEnable()
    {
        Inventory.OnCountSeeds += UpdateSeeds;      
        Inventory.OnCountFruits += UpdateFruits;         
        PlayerStats.OnNewLevel += UpdateLevel;
        PlayerStats.OnMoneyUpdate += UpdateMoney;
        PlayerStats.OnNewInstrumentLevel += UpdateInstLevel;
        DaysManager.OnSkipDay += UpdateDay;
        SeedSwitcher.OnSeedSwitch += UpdateSelectedSeed;
        ModeSwitcher.OnSwitchMode += UpdateSelectedMode;
    }
    
    private void OnDisable()
    {
        Inventory.OnCountSeeds -= UpdateSeeds;      
        Inventory.OnCountFruits -= UpdateFruits;
        PlayerStats.OnNewLevel -= UpdateLevel;
        PlayerStats.OnMoneyUpdate -= UpdateMoney;
        PlayerStats.OnNewInstrumentLevel -= UpdateInstLevel;
        DaysManager.OnSkipDay -= UpdateDay;
        SeedSwitcher.OnSeedSwitch -= UpdateSelectedSeed;
        ModeSwitcher.OnSwitchMode -= UpdateSelectedMode;
    }

    private void UpdateMoney(int money)
    {
        totalMoneyText.text = $"MONEY: {money}";
    }

    private void UpdateSeeds(int corn, int strawberry, int melon)
    {
        Debug.Log(corn + strawberry + melon);

        seedCornCountT.text = corn.ToString();
        seedStrawberryCountT.text = strawberry.ToString();
        seedMelonCountT.text = melon.ToString();
    }

    private void UpdateFruits(int corn, int strawberry, int melon)
    {
        Debug.Log(corn + strawberry + melon);

        fruitCornCountT.text = corn.ToString();
        fruitStrawberryCountT.text = strawberry.ToString();
        fruitMelonCountT.text = melon.ToString();
    }

    private void UpdateLevel(int level)
    {
        currentLevelText.text = $"LVL: {level}";
    }

    private void UpdateInstLevel(int levelInstrument)
    {
        currentLevelInstrText.text = $"LEVEL:{levelInstrument}";
    }
    private void UpdateDay(int day)
    {
        currentDayText.text = $"DAY:{day}"; 
    }
    private void UpdateSelectedMode(string mode)
    {
        selectedModeText.text = mode;
    }
    private void UpdateSelectedSeed(string seed)
    {
        selectedSeedText.text = seed;
    }
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
