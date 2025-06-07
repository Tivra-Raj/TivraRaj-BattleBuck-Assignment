using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public Enemy EnemyPrefab;
    public EnemyType EnemyType;
}

public enum EnemyType
{
    Saw,
    SpikeHead,
    Spike,
}
