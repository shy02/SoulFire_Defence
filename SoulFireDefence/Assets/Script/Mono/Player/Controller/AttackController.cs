using System.Collections;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    //�⺻����, ��������
    //Original Attack, Charge Attack=

    //�÷��̾��� ��Ʈ�� ��ü�� �����ϴ� �Լ� �޾ƿ���
    PlayerControllerManager playerControllerManager;


    //Settings
    int ChargeAttackCount = 0;//���������� �󸶳� ������ �־��°�

    bool Charging = false;//���������ΰ�
    bool NowRight = true;//�÷��̾ �������� �ٶ󺸰� �ִ°�
    bool Attackright = true;//�÷��̾��� ������ ���������� ������ �ϴ� ��
    bool CanParrying = false;//�и��� ������ �����ΰ�(�÷��̾ �⺻ �������� �����϶� �и��� ����)
    bool CanAvoid = false;//ȸ�ǰ� ������ �����ΰ�(�÷��̾ �����⸦ �Ͽ����� ��� ����)

    Animator playerAnimationController;

    private void Start()
    {
        playerAnimationController = GetComponent<Animator>();
        playerControllerManager = GetComponent<PlayerControllerManager>();
    }

    #region �÷��̾��� ���¿� ���� bool�� ���� �Լ���
    void SetCanParrying()//�и��� ������ �����ΰ�
    {
        if (CanParrying)CanParrying = false;
        else CanParrying=true;
    }
    void SetCanAvoid()//������(ȸ��)�� ������ �����ΰ�
    {
        if (CanAvoid) CanAvoid = false;
        else CanAvoid = true;
    }
    #endregion

    #region inputCallbackContext

    public void ChargeAttackStart_Run()//����Ű�� ������ ������
    {
        ChargeAttackCount = 0;
        Charging = true;
        StartCoroutine(ChargeAttackCharging());
        playerAnimationController.SetTrigger("StartCharge");

    }
    public void ChargeAttackCanceled_Run()//����Ű�� ��
    {
        Charging = false;
        StopCoroutine(ChargeAttackCharging());
        playerControllerManager.nowCharge = false;
        Attack();
    }
    #endregion 

    void Attack()//�⺻����? ������? �Ǵ��ϴ� �Լ�
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

    private void OnTriggerEnter2D(Collider2D coll)//�÷��̾ � Ʈ���ſ� ���ٸ� ���� �����̳� � �̺�Ʈ
    {
        #region ���� ���ݿ� ���� �Ǵ�
        if (coll.CompareTag("EnemyAttack")){
            if (CanParrying)
            {
                Debug.Log("�и�����!! ���� �������� ��ľ�!!!");
            }
            else if(CanAvoid){
                Debug.Log("������ ȸ��!");
            }
            else
            {
                Debug.Log("�ǰ�...");
            }
        }
        #endregion
    }
    IEnumerator ChargeAttackCharging()//����ī��Ʈ ���� �ڷ�ƾ
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
