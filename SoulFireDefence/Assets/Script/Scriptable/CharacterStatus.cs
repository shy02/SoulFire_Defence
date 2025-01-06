using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatus", menuName = "Scriptable Objects/CharacterStatus")]
public class CharacterStatus : ScriptableObject
{
    [Header("Settings")]
    [Tooltip("캐릭터의 체력 정보")]
    public float HP;
    [Tooltip("캐릭터의 공격력 정보")]
    public float Force;
    [Tooltip("캐릭터의 방어력 정보")]
    public float Defence;
}
