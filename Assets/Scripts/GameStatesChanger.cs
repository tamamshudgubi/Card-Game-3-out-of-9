using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatesChanger : MonoBehaviour
{
    [SerializeField] private List<Button> _cards;

    [SerializeField] private CardsAdder _cardsAdder;

    [SerializeField] private Player _player;

    private float _secondsToChoose = 3f;

    private void OnEnable()
    {
        _cardsAdder.CardsAdded += OnCardsAdded;
        _player.AllCardsChoosen += OnAllCardsChoosen;
    }

    private void OnDisable()
    {
        _cardsAdder.CardsAdded -= OnCardsAdded;
        _player.AllCardsChoosen -= OnAllCardsChoosen;
    }

    private void GetAllCardsOnScene()
    {
        Button[] TempCards = FindObjectsOfType<Button>();

        for (int i = 0; i < TempCards.Length; i++)
        {
            _cards.Add(TempCards[i]);
        }
    }

    private void RandomizeAllCardsOnScene()
    {
        int length = _cards.Count;

        while (length > 1)
        {
            int RandomPlace = Random.Range(0,length--);

            if (RandomPlace != length)
            {
                CardInfo TempCardInfo = _cards[length].GetComponent<CardDisplay>().Card;
                _cards[length].GetComponent<CardDisplay>().Card = _cards[RandomPlace].GetComponent<CardDisplay>().Card;
                _cards[RandomPlace].GetComponent<CardDisplay>().Card = TempCardInfo;
            }
        }

        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].GetComponent<CardDisplay>().SetValues();
        }
    }

    private void CloseAllCards()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].GetComponent<CardCondition>().CloseCard();
        }
    }

    private void AddListener(List<Button> cards)
    {
        foreach (var button in cards)
        {
            button.onClick.AddListener(() => _player.ChooseCard(button.GetComponent<CardDisplay>().Card));
        }
    }

    private void RemoveListener(List<Button> cards)
    {
        foreach (var button in cards)
        {
            button.onClick.RemoveListener(() => _player.ChooseCard(button.GetComponent<CardDisplay>().Card));
        }
    }

    private void OnCardsAdded()
    {
        GetAllCardsOnScene();
        StartCoroutine(MixCards());
        AddListener(_cards);
    }

    private void OnAllCardsChoosen()
    {
        StartCoroutine(MixCards());
    }

    private void NotAvailableToChoose(List<Button> cards)
    {
        foreach (var card in cards)
        {
            card.enabled = false;
        }
    }

    private void AvailableToChoose(List<Button> cards)
    {
        foreach (var card in cards)
        {
            card.enabled = true;
        }
    }

    IEnumerator MixCards()
    {
        NotAvailableToChoose(_cards);

        yield return new WaitForSeconds(_secondsToChoose);

        CloseAllCards();
        RemoveListener(_cards);

        yield return new WaitForSeconds(_secondsToChoose);

        RandomizeAllCardsOnScene();
        AvailableToChoose(_cards);
    }
}
