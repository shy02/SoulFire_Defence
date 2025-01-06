using System.Collections;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    //�÷��̾��� �̵��� �����ϴ� ��ũ��Ʈ
    //Controller Script for player Move
    [SerializeField] float speed; // �̵� �ӵ�, MoveSpeed
    [SerializeField] float dashpower;// �뽬 �ӵ�, DashSpeed

    bool NowRight = true;//�������� ���� �ִ��� �Ǻ��ϴ� bool ����
    bool NowCharge;

    float moveX;//�̵��ϱ� ���� x��ġ��

    Animator playerAnimationController;

    PlayerControllerManager playerControllerManager;

    private void Start()
    {
        playerAnimationController = GetComponent<Animator>();
        playerControllerManager = GetComponent<PlayerControllerManager>();

    }
    
    private void FixedUpdate()
    {
        if (moveX != 0) playerAnimationController.SetBool("Walk", true);
        else playerAnimationController.SetBool("Walk", false);
        Vector3 movevex = new Vector3(moveX, 0f,0f) * speed * Time.deltaTime;
        playerControllerManager.moveX = this.moveX;
        NowCharge = playerControllerManager.nowCharge;
        if (!NowCharge) transform.position += movevex;
    }
    public void Move_Run(float x)
    {
        if (!NowCharge)
        {
            moveX = x;
            if (moveX == -1f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                NowRight = false;
            }
            else if (moveX == 1f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                NowRight = true;
            }
        }
    }
}
