using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    private const string IsRunning = "isRunning";
    private const string Horizontal = "Horizontal";

    private bool facingRight = true;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _moveInput;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _moveInput = Input.GetAxis(Horizontal);

        if (facingRight == false && _moveInput < 0)
            FlipX();
        else if (facingRight == true && _moveInput > 0)
            FlipX();

        if (_moveInput == 0)
            _animator.SetBool(IsRunning, false);
        else
            _animator.SetBool(IsRunning, true);
    }

    private void FlipX()
    {
        facingRight = !facingRight;
        _spriteRenderer.flipX = facingRight;
    }
}