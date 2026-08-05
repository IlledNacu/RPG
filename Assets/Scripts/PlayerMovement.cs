using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float runSpeed = 8;
    public int facingDirection = 1; // 1 for right, -1 for left

    public Rigidbody2D rb;
    public Animator anim;

    // Nuevo sistema de acción (movimiento)
    public InputAction moveAction;
    public InputAction runAction;

    private void OnEnable()
    {
        moveAction.Enable();
        runAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        runAction.Disable();
    }

    // Update: this method is called once per frame, so it's a good place to check for inputs
    // FixedUpdate: is called 50 times per frame
    private void FixedUpdate()
    {
        // Leemos el input directamente como un Vector2 (X para horizontal, Y para vertical)
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        bool isRunning = runAction.IsPressed();
        float currentSpeed = isRunning ? runSpeed : speed;

        rb.linearVelocity = moveInput * currentSpeed; // Aplicamos la velocidad

        if(moveInput.x > 0 && transform.localScale.x < 0
            || moveInput.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        anim.SetFloat("horizontal", Mathf.Abs(moveInput.x));
        anim.SetFloat("vertical", Mathf.Abs(moveInput.y));

        bool isMoving = moveInput.magnitude > 0;
        anim.SetBool("isRunning", isRunning && isMoving);
    }

    void Flip()
    {
        facingDirection *= -1;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
