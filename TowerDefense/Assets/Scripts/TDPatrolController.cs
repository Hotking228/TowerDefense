using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;
using System;
public class TDPatrolController : AIController
{
    private Path m_Path;
    private int pathIndex = 0;


    public void SetPath(Path path)
    {
        m_Path = path;
        SetPatrolBehaviour(path[pathIndex]);
    }

    protected override void GetNewPoint()
    {
        pathIndex++;
        if (m_Path.Length > pathIndex)
        {
            SetPatrolBehaviour (m_Path[pathIndex]);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
