using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private DefaultPlayerActions _defaultPlayerActions;

    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _sprintAction;

    private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private float _walkSpeed = 4f; // Vitesse normale
    [SerializeField] private float _sprintSpeed = 6f; // Vitesse de sprint

    private float currentSpeed; // Stocker la vitesse actuelle

    private float lastMoveX = 0;
    private float lastMoveY = -1;

    private void Awake()
    {
        _defaultPlayerActions = new DefaultPlayerActions();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _moveAction = _defaultPlayerActions.Player.Move;
        _moveAction.Enable();

        _sprintAction = _defaultPlayerActions.Player.Sprint;
        _sprintAction.Enable();

        _lookAction = _defaultPlayerActions.Player.Look;
        _lookAction.Enable();

        _defaultPlayerActions.Player.Fire.performed += OnFire;
        _defaultPlayerActions.Player.Fire.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();
        _sprintAction.Disable();
        _defaultPlayerActions.Player.Fire.performed -= OnFire;
        _defaultPlayerActions.Player.Fire.Disable();
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        //  Code pour les attaques
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = _moveAction.ReadValue<Vector2>(); // Lire les valeurs de direction
        
        if(_sprintAction.IsPressed())
        {
            currentSpeed = _sprintSpeed; // Active la vitesse de sprint
            animator.SetBool("IsSprinting", moveDir != Vector2.zero);
            animator.SetBool("IsWalking", false);
        }
        else
        {
            currentSpeed = _walkSpeed; // Revenir à la vitesse normale
            animator.SetBool("IsWalking", moveDir != Vector2.zero);
            animator.SetBool("IsSprinting", false);
        }

        // Aplliquer la vitesse au personnage
        Vector3 vel = rb.velocity;
        vel.x = currentSpeed * moveDir.x;
        vel.y = currentSpeed * moveDir.y;
        rb.velocity = vel;

        if(moveDir != Vector2.zero)
        {
            lastMoveX = moveDir.x;
            lastMoveY = moveDir.y;
        }

        animator.SetFloat("MoveX", moveDir.x);
        animator.SetFloat("MoveY", moveDir.y);

        if (moveDir == Vector2.zero)
        {
            animator.SetFloat("LastMoveX", lastMoveX);
            animator.SetFloat("LastMoveY", lastMoveY);
        }

        Vector2 lookDir = _moveAction.ReadValue<Vector2>();
        Debug.Log($"move: {lookDir}");
    }
}
