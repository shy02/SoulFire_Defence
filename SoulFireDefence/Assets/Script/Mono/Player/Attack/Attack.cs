using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject HitEffect;
    public Transform EffectParent;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 pos = contact.point;
            Vector2 normal = contact.normal;
            Debug.Log("Å¸°Ý : " + pos);
            Instantiate(HitEffect, new Vector3(pos.x, pos.y, 0), Quaternion.identity, EffectParent);
        }
    }
}
