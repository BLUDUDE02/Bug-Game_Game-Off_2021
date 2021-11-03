using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform lookAt;
    public Camera camera;
    public GameObject Activator;

    public Color Active = new Color(255, 4, 0);
    public Color inActive = new Color(0, 156, 255);

    public float distance = 10.0f;
    private float currentX = 0.0f;
    public float sensivity = 2500.0f;

    public bool canDrag = false;

    private void Start()
    {
        camera = GetComponent<Camera>();
        Pan();
    }

    void LateUpdate()
    {
        //Camera Move Control
        if(Input.GetMouseButtonDown(0))
        {
            InteractionScreenRay();
        }
        if (Input.GetMouseButtonUp(0))
        {
            canDrag = false;
        }
        if(canDrag == true)
        {
            Pan();
        }
    }

    void InteractionScreenRay()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && canDrag == false)
        {
            Activator = hit.transform.gameObject;
            ActivationHandler();
        }
        else
        {
            canDrag = true;
        }
    }

    //Camera Move Function
    void Pan()
    {
        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;

        Vector3 Direction = new Vector3(0, 5, -distance);
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        transform.position = lookAt.position + rotation * Direction;
        transform.LookAt(lookAt.position);
    }

    void ActivationHandler()
    {
        //Change Color on select (Replace with anim)
        if(Activator.gameObject.CompareTag("Activator"))
        {
            Animator activateAnimator = Activator.GetComponent<Animator>();
            activateAnimator.Play("Color Change");
        }
    }
}
