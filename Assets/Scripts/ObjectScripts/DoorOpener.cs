using UnityEngine;
using UnityEngine.Events;

public class DoorOpener : MonoBehaviour, IInteractive
{
    [SerializeField] private GameObject _leverSwitchGameObject;
    private LeverSwitch _leverSwitch;
    private bool _isOpen = false;
    private bool _isTriggered;

    public UnityEvent DoorOpened;


    private void OnEnable()
    {
        _leverSwitch =_leverSwitchGameObject.GetComponent<LeverSwitch>();        
        _leverSwitch.StateSwitched.AddListener(OnStateSwitched);
    }
    private void Update()
    {
        if (_isOpen && _isTriggered)
        {
            if (Input.GetKeyDown(KeyCode.E))
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

    private void OnStateSwitched()
    {
        _isOpen = !_isOpen;
        DoorOpened.Invoke();
    }

    public void Interact()
    {
        // Next scene
    }
}
