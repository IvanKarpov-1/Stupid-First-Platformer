using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _levelDisplay;

    private void OnEnable()
    {
        //_player.LevelChanged.AddListener(OhLevelChanged);
    }

    private void OhLevelChanged(int level)
    {
        _levelDisplay.text = $"Level: {level}";
    }
}
 