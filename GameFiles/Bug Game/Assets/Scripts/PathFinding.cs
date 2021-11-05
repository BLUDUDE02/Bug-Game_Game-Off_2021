using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    PathRequestManager requestManager;
    Grid grid;

    private void Awake()
    {
        requestManager = GetComponent<PathRequestManager>();
        grid = GetComponent<Grid>();
    }

    public void StartFindPath(Vector3 startPos, Vector3 targetPos)
    {
        StartCoroutine(FindPath(startPos, targetPos));
    }

    IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Vector3[] waypoints = new Vector3[0];
        bool pathSuccess = false;

        Node startNode = grid.GetNodeFromWorldPos(startPos);
        Node targetNode = grid.GetNodeFromWorldPos(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);

        while(openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1;  i < openSet.Count; i++)
            {
                if(openSet[i].fCost() < currentNode.fCost() || openSet[i].fCost() == currentNode.fCost() && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }
            
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if(currentNode == targetNode)
            {
                pathSuccess = true;
                break;
            }

            foreach (Node neighbor in grid.GetNeighbors(currentNode))
            {
                if(!neighbor.walkable || closedSet.Contains(neighbor))
                {
                    //Do Nothing
                }
                else 
                {
                    int newMovementCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);

                    if (newMovementCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                    {
                        neighbor.gCost = newMovementCostToNeighbor;
                        neighbor.hCost = GetDistance(neighbor, targetNode);

                        neighbor.parent = currentNode;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }
        }
        yield return null;
        if(pathSuccess)
        {
            waypoints = RetracePath(startNode, targetNode);
        }
        requestManager.FinishedProcessingPath(waypoints, pathSuccess);
    }

    Vector3[] RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        Vector3[] waypoints = MakePath(path);
        Array.Reverse(waypoints);
        path.Reverse();
        grid.path = path;

        return waypoints;
    }

    Vector3[] MakePath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();

        for (int i = 0; i < path.Count; i++)
        {
            waypoints.Add(path[i].worldPosition);
        }
        return waypoints.ToArray();
    }

    int GetDistance(Node A, Node B)
    {
        int distanceX = Mathf.Abs(A.gridX - B.gridX);
        int distanceY = Mathf.Abs(A.gridY - B.gridY);

        if(distanceX > distanceY)
        {
            return 14 * distanceY + 10 * (distanceX - distanceY);
        }

        return 14 * distanceX + 10 * (distanceY - distanceX);
    }
}
