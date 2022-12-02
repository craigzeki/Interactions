using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum JumpState
    {
        NOT_JUMPING = 0,
        JUMPING,
        NUM_OF_JUMP_STATES
    }

    [SerializeField] private float _jumpSpeed = 0.5f;
    [SerializeField] private float _jumpHeight = 2.0f;

    private JumpState _jumpState = JumpState.NOT_JUMPING;
    private bool _isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void DoJumping()
    {
        switch (_jumpState)
        {
            case JumpState.NOT_JUMPING:
                if ((DetectBlow.Instance.BlowDetected && _isGrounded) || (Input.GetKeyDown(KeyCode.Space)))
                {
                    _jumpState = JumpState.JUMPING;
                    _isGrounded = false;
                }
                break;
            case JumpState.JUMPING:
                transform.position += new Vector3(0, _jumpSpeed * Time.deltaTime, 0);
                if (transform.position.y >= _jumpHeight)
                {
                    //transform.position = new Vector3(transform.position.x, _jumpHeight, transform.position.z);
                    _jumpState = JumpState.NOT_JUMPING;
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
        if ((collision.gameObject.tag == "Ground") && (_jumpState == JumpState.NOT_JUMPING))
        {
            _isGrounded = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
}
