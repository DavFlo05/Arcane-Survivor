using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerControls controls;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();
    }

    void Start()
    {
        rb.linearVelocity = Vector2.zero;
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        float speed = GameManager.instance.playerStats["Speed"];
        rb.linearVelocity = moveInput.normalized * speed;
    }
}