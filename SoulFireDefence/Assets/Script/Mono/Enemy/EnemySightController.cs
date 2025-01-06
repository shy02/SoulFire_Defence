using Unity.VisualScripting;
using UnityEngine;

public class EnemySightController : MonoBehaviour
{
    EnemyMoveController moveController;

    private void Start()
    {
        moveController = transform.parent.GetComponent<EnemyMoveController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveController.findTarget = true;
            moveController.runPatrol = false;
            moveController.target = collision.gameObject;
            moveController.think();
        }
    }
}
