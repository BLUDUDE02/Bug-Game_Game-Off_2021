using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuHandler : MonoBehaviour
{
    public Button Menu, Exit;
    Animator anim1, anim2;
    bool isClicked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Exit.gameObject.SetActive(false);
        anim1 = Exit.gameObject.GetComponent<Animator>();
        anim2 = Menu.gameObject.GetComponent<Animator>();
    }

    public void HandleMenu()
    {
        if (!isClicked)
        {
            OpenMenu();
            isClicked = true;
        }
        else if (isClicked)
        {
            CloseMenu();
            isClicked = false;
        }
    }

    void CloseMenu()
    {
        anim1.ResetTrigger("IsClicked");
        anim2.ResetTrigger("IsClicked");
        anim1.SetTrigger("IsntClicked");
        anim2.SetTrigger("IsntClicked");
        StartCoroutine("CloseExitAnim");
    }

    void OpenMenu()
    {
        Exit.gameObject.SetActive(true);
        anim2.ResetTrigger("IsntClicked");
        anim1.ResetTrigger("IsntClicked");
        anim1.SetTrigger("IsClicked");
        anim2.SetTrigger("IsClicked");
    }

    IEnumerator CloseExitAnim()
    {
        yield return new WaitForSeconds(1f);
        Exit.gameObject.SetActive(false);
    }
}
