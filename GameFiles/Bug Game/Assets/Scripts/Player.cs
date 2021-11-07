using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject clickSprite;
    public float speed = 5f;
    public Grid grid;
    Vector3[] path;
    Vector3 moveDirection;
    public Animator animator;
    public Exit exit;
    bool exited = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
            {
                PathRequestManager.RequestPath(transform.position, hit.point, OnPathFound);
                Node targetNode = grid.GetNodeFromWorldPos(hit.point);
                clickSprite.transform.position = new Vector3(targetNode.worldPosition.x, hit.point.y +0.1f, targetNode.worldPosition.z);
                clickSprite.GetComponent<Animator>().Play("Click", -1, 0f);
                Debug.Log("Click Pos: " + hit.point);               
            }
        }
        if (exit.triggered == true && exited == false)
        {
            animator.Play("Exit");
            exited = true;
        }
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if(pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            animator.SetTrigger("IsWalking");
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
            Vector3 Movement = new Vector3(moveDirection.x, transform.position.y, moveDirection.z);
            transform.position = Movement;
            transform.LookAt(currentWaypoint);
            yield return null;
        }
    }
}
