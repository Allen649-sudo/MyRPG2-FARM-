using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    private PlayerControls playerControls;

    public static Action<Vector2> OnMove;
    [SerializeField] private Chest chest;
    private Chest chestScript;

    Vector2 moveDirection;
    Vector3 playerPos;

    public Rigidbody2D rb;

    void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Player.Enable();

        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        chestScript = chest.GetComponent<Chest>();
    }

    void Update()
    {
        moveDirection = playerControls.Player.Move.ReadValue<Vector2>();
        Move(moveDirection);

        playerControls.Player.Close.performed += Close;
    }

    void Move(Vector2 moveDirection)
    {
        float speed = 4.3f;

        Vector3 direction = new Vector3(moveDirection.x, moveDirection.y);
        rb.velocity = direction * speed;
        OnMove?.Invoke(moveDirection);
    }

    void Close(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        chest.DeactivateChild();
    }
}
