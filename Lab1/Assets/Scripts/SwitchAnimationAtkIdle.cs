using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SwitchAnimationAtkIdle : MonoBehaviour
{
    private Animator cactusAnimator;
    private GameObject[] spawnedCacti;
    private GameObject session;
    void Start()
    {
        cactusAnimator = GetComponent<Animator>();
        session = GameObject.Find("AR Session Origin");
    }

    void Update()
    {
        if(cactusAnimator != null)
        {
            spawnedCacti = session.GetComponent<ARTapToPlace>().spawnedCacti;
            if (spawnedCacti[0] != null && spawnedCacti[1] != null)
            {
                if (Vector2.Distance(spawnedCacti[0].transform.position, spawnedCacti[1].transform.position) < 0.25)
                {
                    cactusAnimator.ResetTrigger("IdleTigger");
                    cactusAnimator.SetTrigger("AtkTrigger");
                }
                else
                {
                    cactusAnimator.ResetTrigger("AtkTrigger");
                    cactusAnimator.SetTrigger("IdleTrigger");
                }
            }
        }
    }
}
