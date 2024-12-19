using System.Collections;
using UnityEngine;

public class ChargeSlash : MonoBehaviour
{
    [SerializeField] int speed;
    WaitForSeconds movewait = new WaitForSeconds(1f);
    public bool nowright = true;
    public GameObject HitEffect;
    public Transform EffectParent;
    private void Start()
    {
        if (nowright) GetComponent<Rigidbody2D>().linearVelocityX = speed;
        else GetComponent<Rigidbody2D>().linearVelocityX = -speed;
        StartCoroutine(DieSlash());

    }
    IEnumerator DieSlash()
    {
        yield return movewait;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 pos = contact.point;
            Vector2 normal = contact.normal;
            Debug.Log("Å¸°Ý : " + pos);
            Instantiate(HitEffect, new Vector3(pos.x,pos.y,0),Quaternion.identity,EffectParent);
        }
        Destroy(gameObject);
    }
}
