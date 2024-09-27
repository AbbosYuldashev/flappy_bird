using UnityEngine;
using UnityEngine.InputSystem;

public class TapToHideCanvas : MonoBehaviour
{
    [SerializeField] private GameObject canvas; // Assign your "Tab Tab" canvas here

    void Start()
    {
        // Ensure the canvas is visible at the beginning
        canvas.SetActive(true);
    }

    void Update()
    {
        // Check for a tap or click input
        if (Mouse.current.leftButton.wasPressedThisFrame || Touchscreen.current.primaryTouch.press.isPressed)
        {
            // Hide the canvas when the player taps or clicks
            canvas.SetActive(false);
        }
    }
}
