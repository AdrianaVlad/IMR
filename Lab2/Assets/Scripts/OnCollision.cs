using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public Material onHitMaterial;
    public Material notHitMaterial;
    public float delayDuration;
    private MeshRenderer render;
    private GameObject scoreObj;
    private GameObject player;
    private void Start()
    {
        render = GetComponent<MeshRenderer>();
        scoreObj = GameObject.Find("Score");
        //replace in line below: find("Main Camera") or find("Right/Left Controller") depending on what you want to consider as 
        //the place the player threw from (I don't have a headset, this is just the option that made sense to me, might be wrong)
        player = GameObject.Find("Camera Offset");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dart"))
        {
            render.material = onHitMaterial;
            StartCoroutine(ResetDelay(delayDuration));
            scoreObj.GetComponent<UpdateScore>().AddPoints((int)Math.Ceiling(100 * Vector3.Distance(player.transform.position, transform.position)));
        }
    }
    private IEnumerator ResetDelay(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        render.material = notHitMaterial;
    }
}
