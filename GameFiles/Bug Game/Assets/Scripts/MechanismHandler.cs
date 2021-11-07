using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanismHandler : MonoBehaviour
{
    public ButtonControl b1, b2, b3, b4;
    public Exit trigger;
    bool B1 = false, B2 = false, B3 = false, B4 = false, Exit = false;
    public Animator anim;
    float speed = 0.15f;
    Vector3 Movement;

    private void Update()
    {
        if(b1.isButtonClicked && !B1)
        {
            Debug.Log("Button Clicked in MechHandler");
            anim.SetTrigger("isMoving");
            StartCoroutine("MoveUp");
            B1 = true;
        }
        if (b2.isButtonClicked && !B2)
        {
            Debug.Log("Button Clicked in MechHandler");
            anim.SetTrigger("isMoving");
            StartCoroutine("MoveUp");
            B2 = true;
        }
        if (b3.isButtonClicked && !B3)
        {
            Debug.Log("Button Clicked in MechHandler");
            anim.SetTrigger("isMoving");
            StartCoroutine("MoveUp");
            B3 = true;
        }
        if (b4.isButtonClicked && !B4)
        {
            Debug.Log("Button Clicked in MechHandler");
            anim.SetTrigger("isMoving");
            StartCoroutine("MoveUp");
            B4 = true;
        }
        if(trigger.triggered && !Exit)
        {
            Debug.Log("Exit!");
            anim.SetTrigger("isMoving");
            StartCoroutine("MoveDown");
            Exit = true;
        }
    }

    IEnumerator MoveUp()
    {
        Vector3 Goal = new Vector3(transform.position.x, (transform.position.y + 40 / 4), transform.position.z);
        while (true)
        {
            if (transform.position == Goal)
            {
                anim.ResetTrigger("isMoving");
                yield break;
            }

            Movement = Vector3.MoveTowards(transform.position, Goal, speed);
            transform.position = Movement;
            yield return null;
        }
    }

    IEnumerator MoveDown()
    {
        Vector3 Goal = new Vector3(transform.position.x, (transform.position.y - 40), transform.position.z);
        while (true)
        {
            if (transform.position == Goal)
            {
                anim.ResetTrigger("isMoving");
                yield break;
            }

            Movement = Vector3.MoveTowards(transform.position, Goal, speed/4);
            transform.position = Movement;
            yield return null;
        }
    }
}
