using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialMoveController : MonoBehaviour
{
    //�뽬�� ������
    //DASH and Rolling
    PlayerControllerManager playerControllerManager;
    [SerializeField]float dashpower;
    float moveX;
    private void Start()
    {
        playerControllerManager = GetComponent<PlayerControllerManager>();
    }

    #region Dash
    //Dash �뽬
    public void Sprint_Run(float x)
    {
        if (!playerControllerManager.nowCharge)
        {
            moveX = x;
            StartCoroutine(OnDash());
        }
    }

    IEnumerator OnDash()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float originalgravityscale = rb.gravityScale;
        rb.gravityScale = 0;
        rb.linearVelocityX = moveX * dashpower;
        yield return new WaitForSeconds(0.2f);
        rb.gravityScale = originalgravityscale;
        rb.linearVelocityX = 0;
    }
    #endregion

    #region avoid 
    //������, ȸ��
    #endregion
}
