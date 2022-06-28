using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExperienceDisplay : MonoBehaviour
{
    [SerializeField] private Player_old _player;
    [SerializeField] private TMP_Text _experienceDisplay;

    private void OnEnable()
    {
        _player.ExperienceChanged.AddListener(OhExperienceChanged);
    }

    private void OhExperienceChanged(int experience)
    {
        _experienceDisplay.text = $"Experience: {experience}";
    }
}
