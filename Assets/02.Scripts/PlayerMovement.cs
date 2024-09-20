using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    private Vector3 Velocity_y = Vector3.zero;

    private float Speed = 4.0f;
    private float Gravity = -25f;
    private float JumpHeight = 1.5f;

    private Vector3 movePos = Vector3.zero;
    public Vector3 MovePos
    {
        get { return movePos; }
        set { movePos = value; }
    }
    [SerializeField] private Vector2 moveRot = Vector2.zero;
    public Vector2 MoveRot
    { 
        get { return moveRot; }
        set { moveRot = value.normalized; } 
    }
    private bool isJump;
    public bool IsJump
    {
        get { return isJump; }
        set 
        {
            isJump = value;
        }
    }
    private bool isGround;
    public bool IsGround
    {
        get { return isGround; }
        set { isGround = value; }
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        CheckJumpState();

        Vector3 move = transform.TransformDirection(MovePos);
        characterController.Move(move * Speed * Time.deltaTime);
    }
    private void CheckJumpState()
    { 
        if (IsGround) //∂•ø° ¥Íæ∆¿÷¿ª ∂ß
        {
            Velocity_y.y = 0;
            if(IsJump)
            {
                Velocity_y.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            }
        }
        else
        {
            Velocity_y.y += Gravity * Time.deltaTime;
            IsJump = false;
        }
        characterController.Move(Velocity_y *  Time.deltaTime);
    }
}
