using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    private PlayerControls playerControls;

    public static Action<Vector2> OnMove;

    Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    Vector3 playerPos;

    public Rigidbody2D rb;
    [SerializeField] private GameObject startPos;

    public GameObject crosschair;
    public Animator animator;

    void Awake()
    {
        transform.position = startPos.transform.position;
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls = new PlayerControls();
        playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
    }

    void Update()
    {
        playerControls.Player.MouseClick.performed += OnCLickPlayer;
        moveDirection = playerControls.Player.Move.ReadValue<Vector2>();

        Move(moveDirection);
        Aim();
        Animate();
    }

    void OnCLickPlayer(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PlayerHand.Instance.Shooting();
        }
    }

    void Move(Vector2 moveDirection)
    {
        float speed = 4.3f;

        Vector3 direction = new Vector3(moveDirection.x, moveDirection.y);
        rb.velocity = direction * speed;
        OnMove?.Invoke(moveDirection);

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDirection = moveDirection;
        }
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Camera.main.nearClipPlane; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        if (crosschair != null)
        {
            crosschair.transform.position = new Vector3(worldPos.x, worldPos.y, crosschair.transform.position.z);
        }
    }

    void Animate()
    {
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);
        animator.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        animator.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }
}
