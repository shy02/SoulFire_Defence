using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerManager : MonoBehaviour
{
    //��Ʈ�ѷ��� ������ �μ����� �� ����
    //Var delivers and Manages between Controller

    AttackController attackcontroller;
    PlayerMoveController movecontroller;
    PlayerStatusController statuscontroller;
    SpecialMoveController specilmovecontroller;

    PlayerStateMechine currentState;

    [Header("References")]
    [Tooltip("�÷��̾��� �������� ��ǲ�ý����� �Է� ���ؽ� ����")]
    [SerializeField] InputActionReference PlayerChargeAttack;

    public float moveX { get; set; } //X�̵���
    public bool nowCharge { get; set; } //���� ����
    //����������, movex, ���׹̳� �� �̵����µ� �����;��ϳ�.....

    private void Start()
    {
        attackcontroller = GetComponent<AttackController>();
        movecontroller = GetComponent<PlayerMoveController>();
        statuscontroller = GetComponent<PlayerStatusController>();
        specilmovecontroller = GetComponent<SpecialMoveController>();

    }

    private void Update()
    {
        currentState.Execute(this);
    }
    #region AttackInput
    private void OnEnable()
    {
        PlayerChargeAttack.action.started += OnChargeAttackStarted;
        //PlayerChargeAttack.action.performed += OnChargeAttackPerformed;
        PlayerChargeAttack.action.canceled += OnChargeAttackCanceled;
    }
    #region inputCallbackContext

    void OnChargeAttackStarted(InputAction.CallbackContext context)//����Ű�� ������ ������
    {
        Debug.Log("���� ����!");
        attackcontroller.ChargeAttackStart_Run();

    }
    void OnChargeAttackCanceled(InputAction.CallbackContext context)//����Ű�� ��
    {
        Debug.Log("���� ��! �߻�!!");
        attackcontroller.ChargeAttackCanceled_Run();
    }
    #endregion
    #endregion AttackInput
    #region MoveInput
    void OnMove(InputValue input)
    {
        movecontroller.Move_Run(input.Get<Vector2>().x);
    }
    #endregion
    #region DashInput
    void OnSprint(InputValue input)
    {
        specilmovecontroller.Sprint_Run(moveX);
    }
    #endregion

    public void SetPlayerState(PlayerStateMechine newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

}
