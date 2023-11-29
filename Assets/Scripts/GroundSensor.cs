using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool _isGrounded;
    public Animator _animator;

    void Start()
    {
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            _isGrounded = true;
            _animator.SetBool("IsJumping", false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            _isGrounded = true;
            _animator.SetBool("IsJumping", false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            _isGrounded = false;
        }
    }
}
