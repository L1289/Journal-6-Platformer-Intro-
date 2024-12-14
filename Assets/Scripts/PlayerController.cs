using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public enum FacingDirection
    {
        left, right
    }

    public float speed;
    public Rigidbody2D playerBody;
    private Vector2 velocity;
    public float acceleration = 3f;
    public float postiveSpeedLimit = 6f;
    public float negativeSpeedLimit = 6f;
    private FacingDirection direction = FacingDirection.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsWalking();
        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.
        Vector2 playerInput = new Vector2();
        playerInput.x = Input.GetAxisRaw("Horizontal");
        MovementUpdate(playerInput);

        playerBody.velocity = velocity;
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        if (playerInput.x != 0)
        {
            //moves the player and updates their postion based on the current speed they are going at 
            velocity.x += acceleration * playerInput.x * Time.deltaTime;
            velocity.x = Mathf.Clamp(velocity.x, -negativeSpeedLimit, postiveSpeedLimit);
        }
        
        else
        {
            velocity.x = 0;
        }

        if (velocity.x > 0)
        {
            direction = FacingDirection.right;
        }
        else if (velocity.x < 0)
        {
            direction = FacingDirection.left;
        }


    }

    public bool IsWalking()
    {
        if (velocity.x != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsGrounded()
    {
        if (velocity.y != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public FacingDirection GetFacingDirection()
    {
        return direction;
    }
}
