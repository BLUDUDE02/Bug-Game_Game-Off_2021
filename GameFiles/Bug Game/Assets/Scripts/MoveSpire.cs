using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpire : MonoBehaviour
{
    public ButtonControl button1, button2, button3;
    public bool b1 = false, b2 = false, b3 = false;

    private void Update()
    {
        if(button1.isButtonClicked && !b1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (48 / 3), transform.position.z);
            b1 = true;
        }
        if (button2.isButtonClicked && !b2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (48 / 3), transform.position.z);
            b2 = true;
        }
        if (button3.isButtonClicked && !b3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (48 / 3)+0.08f, transform.position.z);
            b3 = true;
        }
    }
}
