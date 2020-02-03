using UnityEngine;
using TMPro;

public class PlayerStatsText : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _firstCurrency;

    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.RewardReceived += OnRewardReceived;
    }

    private void OnDisable()
    {
        _player.RewardReceived -= OnRewardReceived;
    }

    private void OnRewardReceived(int Level, int FirstCurrency)
    {
        _level.text = Level.ToString();
        _firstCurrency.text = FirstCurrency.ToString();
    }
}
