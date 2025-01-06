using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusController : MonoBehaviour
{
    //플레이어 상태에 관한 UI 관리
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

