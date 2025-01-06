using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerManager : MonoBehaviour
{
    //컨트롤러들 사이의 인수전달 및 관리
    //Var delivers and Manages between Controller

    AttackController attackcontroller;
    PlayerMoveController movecontroller;
    PlayerStatusController statuscontroller;
    SpecialMoveController specilmovecontroller;

    PlayerStateMechine currentState;

    [Header("References")]
    [Tooltip("플레이어의 차지공격 인풋시스템의 입력 콘텍스 변수")]
    [SerializeField] InputActionReference PlayerChargeAttack;

    public float moveX { get; set; } //X이동값
    public bool nowCharge { get; set; } //차지 상태
    //차지중인지, movex, 스테미나 값 이동상태도 가져와야하나.....

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

    void OnChargeAttackStarted(InputAction.CallbackContext context)//공격키를 누르기 시작함
    {
        Debug.Log("차지 시작!");
        attackcontroller.ChargeAttackStart_Run();

    }
    void OnChargeAttackCanceled(InputAction.CallbackContext context)//공격키를 뗌
    {
        Debug.Log("차지 끝! 발사!!");
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
