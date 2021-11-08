using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    Animator anim;
    public bool isButtonClicked = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(isButtonClicked == false)
            {
                isButtonClicked = true;
                anim.Play("ButtonDown");
                Debug.Log("Button Pressed!");              
            }
            
        }
    }
}
