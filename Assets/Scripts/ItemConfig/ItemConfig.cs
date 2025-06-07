using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    public Platform[] PlatformConfig;
    public EnemyConfig[] EnemyConfig;
    public CoinConfig CoinConfig;
}