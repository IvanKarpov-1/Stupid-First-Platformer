using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTransition : Transition
{
    private bool isDied = false;

    private void OnEnable()
    {
        GetComponent<Enemy>().Dying.AddListener(OnDying);
    }
    private void OnDisable()
    {
        GetComponent<Enemy>().Dying.RemoveListener(OnDying);
    }

    private void Update()
    {
        if (isDied)
            NeedTransit = true;
    }

    private void OnDying()
    {
        isDied = true;
    }
}
