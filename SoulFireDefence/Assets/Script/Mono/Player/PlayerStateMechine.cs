using UnityEngine;
//�÷��̾��� ���� : ������, ����, �޸���, ����, �ǰ�, �и�(= ����), ��ȭ ����
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
        Debug.Log("������ ���� ����");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("������ �۶����� ��...");
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("������ �ֱ� ��!");

    }
}
public class JumpState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("���� ���� ����");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("�����ϴ� ��...");
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("����!");

    }
}
public class RunState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("�޸��� ���� ����");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("�޸��� ��...");
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("�޸��� ��!");

    }
}
public class AttackState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("���ݻ��� ����");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("�����ϴ� ��...");
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("���� ��!");

    }
}
public class GetDamageState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("�ǰݻ��� ����");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("ũ��...");
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("���� ��");

    }
}
public class ParryingState : PlayerStateMechine
{
    public void Enter(PlayerControllerManager player)
    {
        Debug.Log("�и� ���� ����");//�и���� ����
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("�и� ��� ��...");//�����ʱ��� ����ؾ� �и� ���� ���°� �� ���� ������ ���������� ��� ������̶�� �� ��
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("�и�!");//���� ������ �ް� �ִٸ� �и� ���� �ް� ���� �ʴٸ� �ƹ��ϵ� �Ͼ�� ����

    }
}

public class SelectSoulFire : PlayerStateMechine
{
    public void Enter( PlayerControllerManager player)
    {
        Debug.Log("��ȭ ���� ����");
    }
    public void Execute(PlayerControllerManager player)
    {
        Debug.Log("��ȭ ���� ��");//�����ʱ��� ����ؾ� �и� ���� ���°� ��
    }
    public void Exit(PlayerControllerManager player)
    {
        Debug.Log("��ȭ ���� ��!");//���콺�� ����Ű�� �ִ� ��ȭ�� ���õ� ��ȭ!

    }
}
