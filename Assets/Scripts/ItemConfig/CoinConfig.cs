using UnityEngine;

[CreateAssetMenu(fileName = "CoinConfig", menuName = "Configs/CoinConfig")]
public class CoinConfig : ScriptableObject
{
    public GameObject coinPrefab;
    public int value;
    public AudioClip collectSound;
}