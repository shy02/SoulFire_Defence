using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMoveController : MonoBehaviour
{
    [Header("Reference")]
    [Tooltip("좌측 순찰 위치")]
    [SerializeField] Transform Patrolpos1_trans;
    [Tooltip("우측 순찰 위치")]
    [SerializeField] Transform Patrolpos2_trans;
    

    [Header("Settings")]
    [SerializeField] float Speed;
    [SerializeField] float CloseDis;
    Vector3 Patrolpos1;
    Vector3 Patrolpos2;

    Vector3 Moverot;

    public GameObject target;
    Vector3 targetpos;//플레이어의 위치

    public bool findTarget = false; //플레이어를 찾았나
    public bool runPatrol = true; // 추적 실행 여부
    bool returnPatrol = false; //순찰 위치로 돌아가야 하는지 여부

    public Animator enemyAnimationControl;

    float distance;


    private void Start()
    {
        Patrolpos1 = Patrolpos1_trans.position;
        Patrolpos2 = Patrolpos2_trans.position;

        transform.position = Patrolpos1;

        enemyAnimationControl = GetComponent<Animator>();
        Moverot = new Vector3(Speed, 0, 0);
    }
    private void FixedUpdate()
    {
        //순찰
        if (runPatrol)
        {
            moveTo(Patrolpos1.x, Patrolpos2.x);
        }
        //적 찾음
        if (findTarget) 
        {
            targetpos = target.transform.position;
            Vector3 dis = targetpos - transform.position;
            float sqrLen = dis.sqrMagnitude;
            if (sqrLen < CloseDis * CloseDis) { //충분히 가까움
                enemyAnimationControl.SetBool("Move", false);
                if(!enemyAnimationControl.GetBool("Attack")) enemyAnimationControl.SetBool("Attack", true);
            }
            else//충분히 가깝지 않음
            {
                if (sqrLen > 100)
                {
                    enemyAnimationControl.SetBool("Move", false);
                    findTarget = false;
                    runPatrol = true;
                    enemyAnimationControl.SetBool("Move", true);
                }
                else
                {
                    enemyAnimationControl.SetBool("Move", true);
                    moveTo(targetpos.x);
                }
            }
        }

    }

    void moveTo(float xpos)
    {
        if (transform.position.x <= xpos)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x >= xpos)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        this.transform.Translate(Moverot);
    }
    void moveTo(float xpos1, float xpos2)
    {
        if (transform.position.x <= xpos1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x >= xpos2)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        this.transform.Translate(Moverot);
    }

    void SetAnimationAttack()
    {
        enemyAnimationControl.SetBool("Attack", false);
    }
    public void think()
    {
        if (runPatrol)
        {
            enemyAnimationControl.SetBool("Move", true);
        }
        if (findTarget)
        {
            enemyAnimationControl.SetBool("Move", false);
        }
    }
}
