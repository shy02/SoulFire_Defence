using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float dash;

    [SerializeField] InputActionReference PlayerChargeAttack;

    [SerializeField] GameObject ChargeSlash;
    [SerializeField] GameObject HitEffect;

    [SerializeField] Slider SteminaSlider;

    Attack AttackArea;

    int ChargeAttackCount = 0;
    int MaxStemina = 100;
    int recentStemina;

    float movex;

    bool NowCharge = false;
    bool Charging = false;
    bool NowRight = true;

    Animator playerAnimationController;

    Transform ChargeSlashParent;
    Transform EffectParent;


    private void Start()
    {
        playerAnimationController = GetComponent<Animator>();
        ChargeSlashParent = transform.GetChild(0);
        AttackArea = transform.GetChild(1).GetComponent<Attack>();
        AttackArea.EffectParent = this.EffectParent;
        AttackArea.HitEffect = this.HitEffect;

        recentStemina = MaxStemina;

        StartCoroutine(SteminaHeal());
        EffectParent = transform.GetChild(2);


    }
    private void OnEnable()
    {
        PlayerChargeAttack.action.started += OnChargeAttackStarted;
        //PlayerChargeAttack.action.performed += OnChargeAttackPerformed;
        PlayerChargeAttack.action.canceled += OnChargeAttackCanceled;
    }
    private void FixedUpdate()
    {
        if (movex != 0) playerAnimationController.SetBool("Walk", true);
        else playerAnimationController.SetBool("Walk", false);
        Vector3 movevex = new Vector3(movex,0f,0f) * speed * Time.deltaTime;
        if (!NowCharge) transform.position += movevex;
    }
    void OnMove(InputValue input)
    {
        if (!NowCharge)
        {
            movex = input.Get<Vector2>().x;
            if (movex == -1f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                NowRight = false;
            }
            else if (movex == 1f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                NowRight = true;
            }
        }
    }
    #region 대쉬
    void OnSprint(InputValue input)
    {
        Debug.Log(movex);
        StartCoroutine(OnDash());

    }

    IEnumerator OnDash() {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float originalgravityscale = rb.gravityScale;
        rb.gravityScale = 0;
        rb.linearVelocityX = movex*dash;
        if(movex != 0)
        {
            recentStemina -= 10;
            SteminaSlider.value = recentStemina;
        }
        yield return new WaitForSeconds(0.2f);
        rb.gravityScale = originalgravityscale;
        rb.linearVelocityX = 0;

    }
    #endregion

    #region 차지공격,공격

    void OnChargeAttackStarted(InputAction.CallbackContext context)
    {
        Debug.Log("차지 시작!");
        ChargeAttackCount = 0;
        Charging = true;
        StartCoroutine("ChargeAttackCharging");
        playerAnimationController.SetTrigger("StartCharge");

    }
    /*void OnChargeAttackPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("차지중!");
    }*/
    void OnChargeAttackCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("차지 끝! 발사!!");
        Charging = false;
        StopCoroutine("ChargeAttackCharging");
        Attack();
        NowCharge = false;


    }
    void Attack()
    {
        if (ChargeAttackCount < 2)
        {
            playerAnimationController.SetTrigger("Attack");
        }
        else
        {
            recentStemina -= 10;
            SteminaSlider.value = recentStemina;

            playerAnimationController.SetTrigger("ChargeAttack");
        }
    }
    IEnumerator ChargeAttackCharging()
    {
        while (Charging)
        {
            ChargeAttackCount++;
            Debug.Log(ChargeAttackCount);
            if (ChargeAttackCount > 1) NowCharge = true;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void ChargeAttackSlash()
    {
       GameObject Chargeslash =  Instantiate(ChargeSlash,ChargeSlashParent);
        Chargeslash.GetComponent<ChargeSlash>().nowright = NowRight;
        ChargeSlash.GetComponent<ChargeSlash>().HitEffect = this.HitEffect;
        Chargeslash.GetComponent<ChargeSlash>().EffectParent = this.EffectParent;
    }

    #endregion

    IEnumerator SteminaHeal()
    {
        if(recentStemina < MaxStemina)
        {
            recentStemina++;
            SteminaSlider.value = recentStemina;
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(SteminaHeal());
    }


}
