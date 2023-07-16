using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get {
            return instance;
        }
    }
    private float experienceBar;
    public float ActionRaduis;
    public int TotalMoney;
    public int Level;
    public int InstrumentLevel;
    public float Stamina;
    public float TimeToPlant;
    public float TimeToCollect;
    public float TimeToDestroy;
    public float TimeToWater;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        PlayerController.OnCompletedAction += AddExperience;
    }

    private void OnDisable()
    {
        PlayerController.OnCompletedAction -= AddExperience;
    }

    private void AddExperience(int exp)
    {
        experienceBar += exp;

        if (experienceBar % 40 == 0)
        {
            UpdateLevel();
        }
    }

    private void UpdateLevel()
    {
        Level++;

        TimeToCollect -= 0.1f;
        TimeToDestroy -= 0.1f;
        TimeToPlant -= 0.1f;
        TimeToWater -= 0.1f;
    }
    private void UpgradeInstruments()
    {
        InstrumentLevel++;
    }

}
