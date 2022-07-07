using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _healthDisplay;

    private void OnEnable()
    {
        //_player.HealthChanged.AddListener(OhHealthChanged);
    }

    private void OhHealthChanged(int health)
    {
        _healthDisplay.text = $"Health: {health}";
    }
}
