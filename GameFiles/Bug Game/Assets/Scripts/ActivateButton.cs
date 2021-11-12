using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public ButtonControl button;
    public ButtonControl button1;
    public Transform lift;
    public Transform exit;
    public bool canRotate = true;
    public bool canMove = true;
    public bool canMove1 = true;
    public Player player;
    public Animator anim1, anim2, anim3, anim4, anim5, anim6, anim7, anim8, anim9, anim10, anim11, anim12, anim13, anim14;

    private void Update()
    {
        if(button.isButtonClicked)
        {
            moveDown();
        }
        if (button1.isButtonClicked)
        {
            moveUp();
        }
    }

    public void Rotate()
    {
        if(canRotate)
        {
            float end = transform.rotation.y + 90;
            StartCoroutine(Rotate(end));
            button.ButtonisActive = true;
            canRotate = false;
        }
    }

    public void moveDown()
    {
        if (canMove)
        {
            Vector3 end = new Vector3(transform.position.x, transform.position.y - 50, transform.position.z);
            StartCoroutine(MoveDown(end));
            button.ButtonisActive = true;
            canMove = false;
        }   
    }

    public void moveUp()
    {
        if (canMove1)
        {
            Vector3 end = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
            StartCoroutine(MoveUp(end));
            button1.ButtonisActive = true;
            canMove1 = false;
            anim1.SetTrigger("done");
        }
    }

    IEnumerator Rotate(float end)
    {
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(Vector3.forward, -1);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator MoveDown(Vector3 end)
    {
        for (int i = 0; i < 50; i++)
        {
            lift.transform.position = new Vector3(lift.transform.position.x, lift.transform.position.y - 1, lift.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }

    }

    IEnumerator MoveUp(Vector3 end)
    {
        for (int i = 0; i < 50; i++)
        {
            exit.transform.position = new Vector3(exit.transform.position.x, exit.transform.position.y + 1, exit.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        anim2.speed = 0;
        anim3.speed = 0;
        anim4.speed = 0;
        anim5.speed = 0;
        anim6.speed = 0;
        anim7.speed = 0;
        anim8.speed = 0;
        anim9.speed = 0;
        anim10.speed = 0;
        anim11.speed = 0;
        anim12.speed = 0;
        anim13.speed = 0;
        anim14.speed = 0;
    }

}
