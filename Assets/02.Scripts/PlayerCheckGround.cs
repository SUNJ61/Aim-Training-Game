using UnityEngine;

public class PlayerCheckGround : MonoBehaviour
{
    private PlayerMovement playerMove;
    private CharacterController characterController;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMovement>();
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        CheckGround();
    }
    private void CheckGround()
    {
        if (characterController.isGrounded) playerMove.IsGround = true;
        else
        {
            RaycastHit hit;
            playerMove.IsGround = Physics.Raycast(transform.position, Vector3.down, out hit, 0.15f);
            Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        }
    }
}
