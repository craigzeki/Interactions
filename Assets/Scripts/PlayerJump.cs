using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{

    public enum JumpState
    {
        NOT_JUMPING = 0,
        JUMPING,
        NUM_OF_JUMP_STATES
    }

    //[SerializeField] private float _jumpSpeed = 0.5f;
    //[SerializeField] private float _jumpHeight = 2.0f;
    [SerializeField] private Vector3 _jumpVector = new Vector3(0, 1, 1);
    [SerializeField] private float _jumpMagnitude = 2f;

    private JumpState _jumpState = JumpState.NOT_JUMPING;
    private bool _isGrounded = false;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void DoJumping()
    {
        switch (_jumpState)
        {
            case JumpState.NOT_JUMPING:
                if ((DetectBlow.Instance.BlowDetected && _isGrounded) || (Input.GetKeyDown(KeyCode.Space)))
                {
                    _jumpState = JumpState.JUMPING;
                    _rigidbody.AddForce((_jumpVector * _jumpMagnitude), ForceMode.Impulse);
                    _isGrounded = false;
                }
                break;
            case JumpState.JUMPING:
                //transform.position += new Vector3(0, _jumpSpeed * Time.deltaTime, 0);
                //if (transform.position.y >= _jumpHeight)
                //{
                //    transform.position = new Vector3(transform.position.x, _jumpHeight, transform.position.z);
                //    _jumpState = JumpState.NOT_JUMPING;
                //}
                   
                if(_isGrounded)
                {
                    _jumpState = JumpState.NOT_JUMPING;
                    DetectBlow.Instance.BlowDetected = false;
                }
                break;
            case JumpState.NUM_OF_JUMP_STATES:
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        DoJumping();
        
    }


    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.tag == "Ground"))
        {
            _isGrounded = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
}
