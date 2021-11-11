using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform turner;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
            {
                if (hit.transform.gameObject.CompareTag("Rotator"))
                {
                    float end = transform.rotation.y + 90;
                    StartCoroutine(Rotate(end));
                }
            }
        }


    }

    IEnumerator Rotate(float end)
    {
        for(int i = 0; i < 90; i ++)
        {
            transform.Rotate(Vector3.up, 1);
            turner.Rotate(Vector3.up, -5);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
