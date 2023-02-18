using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private float _waitTime;

    private const string IsWalk = "isWalk";
    private bool facingRight = false;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Transform[] _points;
    private int _currentPoint;
    private float _startWaitTime;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _startWaitTime = _waitTime;

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void FixedUpdate()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        _animator.SetBool(IsWalk, true);

        if (transform.position == target.position)
        {
            if (_waitTime <= 0)
            {
                FlipX();
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }

                _waitTime = _startWaitTime;
            }
            else
            {
                _animator.SetBool(IsWalk, false);
                _waitTime -= Time.deltaTime;
            }
        }
    }

    private void FlipX()
    {
        facingRight = !facingRight;
        _spriteRenderer.flipX = facingRight;
    }
}