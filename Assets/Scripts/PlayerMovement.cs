using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;

    // Nuevo sistema de acción (movimiento)
    public InputAction moveAction;

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    // Update: this method is called once per frame, so it's a good place to check for inputs
    // FixedUpdate: is called 50 times per frame
    private void FixedUpdate()
    {
        // Leemos el input directamente como un Vector2 (X para horizontal, Y para vertical)
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = moveInput * speed; // Aplicamos la velocidad
    }
}
