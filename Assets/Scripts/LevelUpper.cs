using UnityEngine;

public class LevelUpper : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _previousMaterialAmount = 0;
    private int _overMaterialAmount = 1;
    private int _levelToUp = 1;

    private void OnEnable()
    {
        _player.TryingLevelUp += OnTryingLevelUp;
    }

    private void OnDisable()
    {
        _player.TryingLevelUp -= OnTryingLevelUp;
    }

    private int OnTryingLevelUp(int firstMaterialAmount)
    {
        int OverMaterial = firstMaterialAmount - _previousMaterialAmount;

        if (OverMaterial >= _overMaterialAmount)
        {
            _previousMaterialAmount = firstMaterialAmount;

            return _levelToUp;
        }
        else
        {
            return 0;
        }
    }
}
