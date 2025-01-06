using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusController : MonoBehaviour
{
    //�÷��̾� ���¿� ���� UI ����
    //UI Manager about Player Status
    [SerializeField] Slider SteminaSlider;
    PlayerControllerManager playerControllerManager;

    int MaxStemina = 100;
    int recentStemina;
    
    void Start()
    {
        recentStemina = MaxStemina;
        StartCoroutine(SteminaHeal());

        playerControllerManager = GetComponent<PlayerControllerManager>();

    }

    IEnumerator SteminaHeal()
    {
        if (recentStemina < MaxStemina)
        {
            recentStemina++;
            SteminaSlider.value = recentStemina;
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(SteminaHeal());
    }
}

