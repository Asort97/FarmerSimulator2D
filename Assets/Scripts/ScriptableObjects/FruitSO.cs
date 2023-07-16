using UnityEngine;

[CreateAssetMenu(fileName = "Fruit", menuName = "Garden/New Fruit")]
public class FruitSO : ScriptableObject
{
    public string NameId;
    public int Price;
}
