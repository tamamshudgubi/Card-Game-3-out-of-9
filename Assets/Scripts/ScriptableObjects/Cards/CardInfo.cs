using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardInfo : ScriptableObject
{
    [SerializeField] private int _number;

    [SerializeField] private string _rewardDesignation;
    [SerializeField] private int _rewardAmount;

    public int Number { get => _number; set => _number = value; }

    public int RewardAmount { get => _rewardAmount; }

    public string Reward { get => _rewardDesignation; }
}
