using UnityEngine;
using UnityEngine.Events;

public class LeverSwitch : MonoBehaviour, IInteractive
{
    private bool _isActive = false;
    private bool _isTriggered;

    public UnityEvent StateSwitched;

    private void Update()
    {
        if (_isTriggered)
        {
            if (Input.GetMouseButtonDown(1))
                Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isTriggered = false;
    }

    public void Interact()
    {
        _isActive = !_isActive;
        StateSwitched.Invoke();
    }
}
