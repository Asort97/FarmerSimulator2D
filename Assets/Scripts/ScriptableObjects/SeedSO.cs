using UnityEngine;
[CreateAssetMenu(fileName = "Seed", menuName = "Garden/New Seed")]
public class SeedSO : ScriptableObject
{
    [System.Serializable]
    public struct StatesSeedSprite
    {
        public Sprite stateSprite;
        public int stateDay;
    }
    public string NameId;
    public Sprite OrganicTrash;
    public FruitSO ResultFruit;
    public int MinCollectableFruits;
    public int AverageDaysToGrow;
    public int DaysToWither;
    public bool IsOneYear = true;
    public StatesSeedSprite[] StatesSeedSprites;
}
