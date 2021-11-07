using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bushes : MonoBehaviour
{
    Animator Anim;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit!");
            Anim.SetTrigger("isMoving");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Anim.ResetTrigger("isMoving");
    }
}
