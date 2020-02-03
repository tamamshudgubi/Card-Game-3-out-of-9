using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{    
    [SerializeField] private TMP_Text _number;
    [SerializeField] private TMP_Text _reward;
    [SerializeField] private TMP_Text _rewardAmount;

    private CardInfo _card;

    public CardInfo Card { get => _card; set => _card = value; }

    public void SetValues()
    {
        _number.text = _card.Number.ToString();
        _reward.text = _card.Reward.ToString();
        _rewardAmount.text = _card.RewardAmount.ToString();
    }
}
