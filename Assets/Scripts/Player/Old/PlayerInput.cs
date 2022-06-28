using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent PrimaryButtonPressing;
    public UnityEvent SecondaryButtonPressing;
    public UnityEvent SpacePressing;
    public UnityEvent<float> MovementKeysPressing;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PrimaryButtonPressing.Invoke();
        }
        if (Input.GetMouseButtonDown(1))
        {
            SecondaryButtonPressing.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpacePressing.Invoke();
        }
        MovementKeysPressing.Invoke(Input.GetAxis("Horizontal"));
    }
}
