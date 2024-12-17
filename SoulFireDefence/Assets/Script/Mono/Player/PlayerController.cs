using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float dash;
    float movex;
    Animator playerAnimationController;

    private void Start()
    {
        playerAnimationController = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (movex != 0) playerAnimationController.SetBool("Walk", true);
        else playerAnimationController.SetBool("Walk", false);
        Vector3 movevex = new Vector3(movex,0f,0f) * speed * Time.deltaTime;
        transform.position += movevex;
    }
    void OnMove(InputValue input)
    {
        movex = input.Get<Vector2>().x;
        if(movex < 0) GetComponent<SpriteRenderer>().flipX = true;
        else GetComponent<SpriteRenderer>().flipX = false;
    }
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
    yield return new WaitForSeconds(0.2f);
        rb.gravityScale = originalgravityscale;
        rb.linearVelocityX = 0;

    }
}
