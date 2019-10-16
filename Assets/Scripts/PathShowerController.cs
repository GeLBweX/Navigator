using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathShowerController : MonoBehaviour
{
    private static LineRenderer _lineRenderer;
    [SerializeField] private LineRenderer lineRenderer;
    private Queue<DirectionsEnum> _directionsEnums;

    private void Awake()
    {

        _lineRenderer = lineRenderer;
    }

    private void Update()
    {
        SetPoints();
    }

    private static void SetPoints()
    {
        var path = MovementController.GetPath();
        if (path == null)
        {
            _lineRenderer.positionCount = 0;
            return;
        }

        _lineRenderer.positionCount = path.Count;
        var result = new Vector3[path.Count];
        for (int i = 0; i < path.Count; i++)
        {
            result[i] = new Vector3(path[i].x * Map.CellSize, -path[i].y * Map.CellSize, -1);
        }

        _lineRenderer.SetPositions(result);
    }
}