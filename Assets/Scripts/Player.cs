using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private int _firstCurrency = 250;
    private int _secondCurrency = 0;

    private int _firstMaterialAmount;
    private double _secondMaterialAmount;
    private int _thirdMaterialAmount;

    private int _firstSpellCharges;
    private int _secondSpellCharges;
    private int _thirdSpellCharges;

    private int _playerLevel = 1;

    private int _freeChances = 3;
    private int _maxChances = 5;
    private int _fourthCardCost = 1;
    private int _fifthCardCost = 3;
    private int _currentChanceNumber;

    public event Action<int, int> RewardReceived;
    public event Action AllCardsChoosen;
    public event Func<int, int> TryingLevelUp;

    public void ChooseCard(CardInfo reward)
    {
        _currentChanceNumber++;

        if (_currentChanceNumber <= _freeChances)
        {
            GetReward(reward);
        }
        else if (_currentChanceNumber > _freeChances && _currentChanceNumber < _maxChances)
        {
            _firstCurrency -= _fourthCardCost;

            GetReward(reward);
        }
        else if (_currentChanceNumber == _maxChances)
        {
            _firstCurrency -= _fifthCardCost;

            GetReward(reward);

            AllCardsChoosen?.Invoke();

            _currentChanceNumber = 0;
        }

        RewardReceived?.Invoke(_playerLevel, _firstCurrency);
    }

    private void GetReward(CardInfo reward)
    {
        switch (reward.Number)
        {
            case 1:
                _secondCurrency += reward.RewardAmount * _playerLevel;

                break;
            case 2:
                _secondCurrency += reward.RewardAmount * _playerLevel;

                break;
            case 3:
                _secondCurrency += reward.RewardAmount * _playerLevel;

                break;
            case 4:
                _firstMaterialAmount += reward.RewardAmount * _playerLevel;

                break;
            case 5:
                _secondMaterialAmount += Math.Ceiling((double)reward.RewardAmount * _playerLevel / 2);

                break;
            case 6:
                _thirdMaterialAmount += reward.RewardAmount;

                break;
            case 7:
                _firstSpellCharges += reward.RewardAmount;

                break;
            case 8:
                _secondSpellCharges += reward.RewardAmount;

                break;
            case 9:
                _thirdSpellCharges += reward.RewardAmount;

                break;
        }

        _playerLevel += (int)TryingLevelUp?.Invoke(_firstMaterialAmount);
    }
}
