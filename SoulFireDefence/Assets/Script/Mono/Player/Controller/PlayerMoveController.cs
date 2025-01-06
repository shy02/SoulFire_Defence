using System.Collections;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    //플레이어의 이동을 관리하는 스크립트
    //Controller Script for player Move
    [SerializeField] float speed; // 이동 속도, MoveSpeed
    [SerializeField] float dashpower;// 대쉬 속도, DashSpeed

    bool NowRight = true;//오른쪽을 보고 있는지 판별하는 bool 변수
    bool NowCharge;

    float moveX;//이동하기 위한 x위치값

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
