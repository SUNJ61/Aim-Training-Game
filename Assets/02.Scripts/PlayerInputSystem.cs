using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;
//인풋 값만 보내도록 한다.
public class PlayerInputSystem : MonoBehaviour
{
    private PlayerMovement playerMove;
    private PlayerFire playerFire;

    [SerializeField] private Vector3 MovePos = Vector3.zero;
    [SerializeField] private Vector2 MoveRot = Vector2.zero;

    private float FireState;
    private float JumpState;

    [SerializeField] private bool isFire = false;
    [SerializeField] private bool isJump = false;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMovement>();
        playerFire = GetComponent<PlayerFire>();
    }
    private void Update()
    {
        CheckState();
        SendData();
    }

    private void OnMove(InputValue value) //플레이어 이동
    {
        Vector2 dir = value.Get<Vector2>();
        MovePos = new Vector3(dir.x, 0f, dir.y);
    }
    private void OnLook(InputValue value) //화면 회전
    {
        MoveRot = value.Get<Vector2>();
    }
    private void OnJump(InputValue value) //함수 호출 시 true를 보내기, bool변수 업데이트는 동작에서
    {
        JumpState = value.Get<float>();
    }
    private void OnFire(InputValue value) //함수 호출 시 true를 보내기, bool변수 업데이트는 발사에서, 총을 눈에서 발사, 총기는 이펙트만 내기, 
    {
        FireState = value.Get<float>();
    }

    private void CheckState()
    {
        if (FireState != 0)
            isFire = true;
        else
            isFire = false;

        if(JumpState != 0)
            isJump = true;
        else
            isJump = false;
    }
    private void SendData()
    {
        playerMove.MovePos = MovePos;
        playerMove.MoveRot = MoveRot;
        playerMove.IsJump = isJump;
        playerFire.IsFire = isFire;
    }
}
