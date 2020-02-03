using UnityEngine;

public class CardCondition : MonoBehaviour
{
    [SerializeField] private GameObject _closeSprite;

    public void CloseCard()
    {
        _closeSprite.SetActive(true);
    }

    public void OpenCard()
    {
        _closeSprite.SetActive(false);
    }
}
