using UnityEngine;
//플레이어의 상태 : 가만히, 점프, 달리기, 공격, 피격, 패링(= 방어가능), 령화 선택
public interface PlayerStateMechine
{
    void Enter(PlayerControllerManager player);
    void Execute(PlayerControllerManager player);
    void Exit(PlayerControllerManager player);
}
public class IdleState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("가만히 상태 진입");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("가만히 멍때리는 중...");
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("가만히 있기 끝!");

    }
}
public class JumpState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("점프 상태 진입");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("점프하는 중...");
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("착지!");

    }
}
public class RunState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("달리기 상태 진입");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("달리는 중...");
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("달리기 끝!");

    }
}
public class AttackState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("공격상태 진입");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("공격하는 중...");
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("공격 끝!");

    }
}
public class GetDamageState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("피격상태 진입");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("크윽...");
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("고통 끝");

    }
}
public class ParryingState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("패링 상태 진입");//패링대기 시작
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("패링 대기 중...");//일정초까지 대기해야 패링 가능 상태가 됨 만약 공격을 받을때까지 계속 대기중이라면 방어가 됨
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("패링!");//적의 공격을 받고 있다면 패링 성공 받고 있지 않다면 아무일도 일어나지 않음

    }
}

public class SelectSoulFire : PlayerStateMechine
{
    public void Enter( PlayerControllerManager player)
    {
        Debug.Log("령화 선택 시작");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("령화 선택 중");//일정초까지 대기해야 패링 가능 상태가 됨
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("령화 선택 끝!");//마우스가 가르키고 있는 령화가 선택된 령화!

    }
}
