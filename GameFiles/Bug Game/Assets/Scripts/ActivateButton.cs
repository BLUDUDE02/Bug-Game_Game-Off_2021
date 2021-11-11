using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public ButtonControl button;
    public Transform self;
    bool canRotate = true;

    private void Awake()
    {
        self = transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
            {
                if (hit.transform.gameObject.CompareTag("Button") && canRotate)
                {
                    float end = transform.rotation.y + 90;
                    StartCoroutine(Rotate(end));
                    button.ButtonisActive = true;
                    canRotate = false;
                }
            }
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
}
