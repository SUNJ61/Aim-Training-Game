using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;
//��ǲ ���� �������� �Ѵ�.
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

    private void OnMove(InputValue value) //�÷��̾� �̵�
    {
        Vector2 dir = value.Get<Vector2>();
        MovePos = new Vector3(dir.x, 0f, dir.y);
    }
    private void OnLook(InputValue value) //ȭ�� ȸ��
    {
        MoveRot = value.Get<Vector2>();
    }
    private void OnJump(InputValue value) //�Լ� ȣ�� �� true�� ������, bool���� ������Ʈ�� ���ۿ���
    {
        JumpState = value.Get<float>();
    }
    private void OnFire(InputValue value) //�Լ� ȣ�� �� true�� ������, bool���� ������Ʈ�� �߻翡��, ���� ������ �߻�, �ѱ�� ����Ʈ�� ����, 
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
