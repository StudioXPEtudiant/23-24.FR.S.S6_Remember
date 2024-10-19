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

    private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private float _speed = 6f;

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
        _lookAction = _defaultPlayerActions.Player.Look;
        _lookAction.Enable();

        _defaultPlayerActions.Player.Fire.performed += OnFire;
        _defaultPlayerActions.Player.Fire.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();
        _defaultPlayerActions.Player.Fire.performed -= OnFire;
        _defaultPlayerActions.Player.Fire.Disable();
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        //  Code pour les attaques
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = _moveAction.ReadValue<Vector2>();
        Vector3 vel = rb.velocity;

        vel.x = _speed * moveDir.x;
        vel.y = _speed * moveDir.y;
        rb.velocity = vel;

        if(moveDir != Vector2.zero)
        {
            lastMoveX = moveDir.x;
            lastMoveY = moveDir.y;
        }

        animator.SetFloat("MoveX", moveDir.x);
        animator.SetFloat("MoveY", moveDir.y);
        animator.SetBool("IsMoving", moveDir != Vector2.zero);

        if (moveDir == Vector2.zero)
        {
            animator.SetFloat("LastMoveX", lastMoveX);
            animator.SetFloat("LastMoveY", lastMoveY);
        }

        Vector2 lookDir = _moveAction.ReadValue<Vector2>();
        Debug.Log($"move: {lookDir}");
    }
}
