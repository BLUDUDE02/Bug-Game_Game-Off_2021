using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpire : MonoBehaviour
{
    public ButtonControl button1, button2, button3, button4;
    public bool b1 = false, b2 = false, b3 = false, b4 = false;

    private void Update()
    {
        if(button1.isButtonClicked && !b1)
        {
            StartCoroutine(MoveDown());
            b1 = true;
        }
        if (button2.isButtonClicked && !b2)
        {
            StartCoroutine(MoveDown());
            b2 = true;
        }
        if (button3.isButtonClicked && !b3)
        {
            StartCoroutine(MoveDown());
            b3 = true;
        }
        if (button4.isButtonClicked && !b4)
        {
            StartCoroutine(MoveDown());
            b4 = true;
        }
    }

    IEnumerator MoveDown()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y - (48 / 4), transform.position.z);
        while (true)
        {
            if (transform.position == newPos)
            {
                yield break;
            }
            transform.position = Vector3.MoveTowards(transform.position, newPos, 0.1f);
            yield return null;
        }
    }
}
