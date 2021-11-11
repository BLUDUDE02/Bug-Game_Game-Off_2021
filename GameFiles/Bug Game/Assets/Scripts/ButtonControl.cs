using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    Animator anim;
    public bool isButtonClicked = false;
    public bool ButtonisActive = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if(transform.GetComponentInParent<ActivateButton>())
        {
            ButtonisActive = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(isButtonClicked == false && ButtonisActive)
            {
                isButtonClicked = true;
                anim.Play("ButtonDown");
                Debug.Log("Button Pressed!");              
            }
            
        }
    }
}
