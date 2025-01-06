using System.Collections;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    //기본공격, 차지공격
    //Original Attack, Charge Attack=

    //플레이어의 컨트롤 전체를 관리하는 함수 받아오기
    PlayerControllerManager playerControllerManager;


    //Settings
    int ChargeAttackCount = 0;//차지어택을 얼마나 누르고 있었는가

    bool Charging = false;//차지상태인가
    bool NowRight = true;//플레이어가 오른쪽을 바라보고 있는가
    bool Attackright = true;//플레이어의 공격이 오른쪽으로 나가야 하는 가
    bool CanParrying = false;//패링이 가능한 상태인가(플레이어가 기본 공격중인 상태일때 패링이 가능)
    bool CanAvoid = false;//회피가 가능한 상태인가(플레이어가 구르기를 하였을때 사용 가능)

    Animator playerAnimationController;

    private void Start()
    {
        playerAnimationController = GetComponent<Animator>();
        playerControllerManager = GetComponent<PlayerControllerManager>();
    }

    #region 플레이어의 상태에 관한 bool값 설정 함수들
    void SetCanParrying()//패링이 가능한 상태인가
    {
        if (CanParrying)CanParrying = false;
        else CanParrying=true;
    }
    void SetCanAvoid()//구르기(회피)가 가능한 상태인가
    {
        if (CanAvoid) CanAvoid = false;
        else CanAvoid = true;
    }
    #endregion

    #region inputCallbackContext

    public void ChargeAttackStart_Run()//공격키를 누르기 시작함
    {
        ChargeAttackCount = 0;
        Charging = true;
        StartCoroutine(ChargeAttackCharging());
        playerAnimationController.SetTrigger("StartCharge");

    }
    public void ChargeAttackCanceled_Run()//공격키를 뗌
    {
        Charging = false;
        StopCoroutine(ChargeAttackCharging());
        playerControllerManager.nowCharge = false;
        Attack();
    }
    #endregion 

    void Attack()//기본공격? 강공격? 판단하는 함수
    {
        if (ChargeAttackCount < 2)
        {
            playerAnimationController.SetTrigger("Attack");
        }
        else
        {
            Attackright = NowRight;
            playerAnimationController.SetTrigger("ChargeAttack");
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)//플레이어가 어떤 트리거에 들어갔다면 적의 공격이나 어떤 이벤트
    {
        #region 적의 공격에 대한 판단
        if (coll.CompareTag("EnemyAttack")){
            if (CanParrying)
            {
                Debug.Log("패링성공!! 하하 경직맛이 어떠냐아!!!");
            }
            else if(CanAvoid){
                Debug.Log("굴러서 회피!");
            }
            else
            {
                Debug.Log("피격...");
            }
        }
        #endregion
    }
    IEnumerator ChargeAttackCharging()//차지카운트 세는 코루틴
    {
        while (Charging)
        {
            ChargeAttackCount++;
            if (ChargeAttackCount > 1) playerControllerManager.nowCharge = true;
            Debug.Log(ChargeAttackCount);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
