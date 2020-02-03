using UnityEngine;
using System.Collections;
using System;

public class CardsAdder : MonoBehaviour
{
    [SerializeField] private CardInfo[] _cards;

    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _cardsField;

    private int _cardsAmount = 9;

    private float _secondsToAdd = 0.1f;

    public CardInfo[] CardsTemplate { get => _cards; }

    public event Action CardsAdded;

    private void Awake()
    {
        StartCoroutine(AddCards());
    }

    private void AddCardsOnScene(int number)
    {
        GameObject card = Instantiate(_cardPrefab);

        card.GetComponent<CardDisplay>().Card = _cards[number];
        card.GetComponent<CardDisplay>().SetValues();
        card.transform.SetParent(_cardsField, false);
    }

    IEnumerator AddCards()
    {
        for (int i = 0; i < _cardsAmount; i++)
        {
            yield return new WaitForSeconds(_secondsToAdd);

            AddCardsOnScene(i);
        }

        CardsAdded?.Invoke();
    }
}
