using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatus", menuName = "Scriptable Objects/CharacterStatus")]
public class CharacterStatus : ScriptableObject
{
    [Header("Settings")]
    [Tooltip("ĳ������ ü�� ����")]
    public float HP;
    [Tooltip("ĳ������ ���ݷ� ����")]
    public float Force;
    [Tooltip("ĳ������ ���� ����")]
    public float Defence;
}
