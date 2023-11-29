using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _playerInputHorizontal;
    [SerializeField]private float _jumpForce = 5;
    [SerializeField]private float _speed = 5;
    Rigidbody2D _rBody2D;
    [SerializeField] Animator _animator;
    GroundSensor _groundSensor;
    public GameManager _gameManager;


    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponentInChildren<Animator>();
        _groundSensor = gameObject.GetComponentInChildren<GroundSensor>();

    }
  
    void Update()
    {
        PlayerMovement();

        if(Input.GetButtonDown("Jump") && _groundSensor._isGrounded)
        {
            Jump();
            _animator.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate()
    {
        _rBody2D.velocity = new Vector2(_playerInputHorizontal * _speed, _rBody2D.velocity.y);
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    void PlayerMovement()
    {
        _playerInputHorizontal = Input.GetAxis("Horizontal");

        if(_playerInputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if(_playerInputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Star"))
        {
            _gameManager.Win();
        }
    }
}
