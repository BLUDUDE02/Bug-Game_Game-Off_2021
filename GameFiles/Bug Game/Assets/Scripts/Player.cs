using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    float speed = 0.005f;
    Vector3[] path;
    Vector3 moveDirection;
    public Animator animator;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                PathRequestManager.RequestPath(transform.position, hit.point, OnPathFound);
                Debug.Log("Click Pos: " + hit.point);
                animator.SetTrigger("IsWalking");
            }
        }
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if(pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];

        int targetIndex = 0;

        while(true)
        {
            if(transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    animator.ResetTrigger("IsWalking");
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }

            moveDirection = Vector3.MoveTowards(transform.position, currentWaypoint, speed);
            transform.position = moveDirection;
            transform.LookAt(currentWaypoint);
            yield return null;
        }
    }
}
