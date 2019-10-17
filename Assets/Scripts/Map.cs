using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    private static List<Floor> _floors;
    public static float CellSize;
    private static int _floorIndex;
    [SerializeField] private float cellSize;
    [SerializeField] private Transform[] floors;

    private void Awake()
    {
        CellSize = cellSize;
        _floors = new List<Floor>();
        for (var i = 0; i < floors.Length; i++)
        {
            _floors.Add(new Floor(floors[i], i));
        }
    }

    public static Cell GetCell(string cellName)
    {
        foreach (var floor in _floors)
        {
            var cell = floor.GetCellByName(cellName);
            if (cell)
                return cell;
        }

        return _floors[0].GetCellByCoord(new Vector3Int(0, 0, 0));
    }

    public static Cell GetCell(Vector3Int coord) => _floors[coord.z].GetCellByCoord(coord);

    public static Vector3Int ConvertGlobalPosToMapPos(Vector3 pos, int floor)
    {
        return new Vector3Int(Mathf.RoundToInt (pos.x / Map.CellSize), Mathf.RoundToInt (pos.y / Map.CellSize), floor);
    }

    public static SinglyLinkedList<Vector3Int> FindPath(Vector3Int start, Vector3Int final)
    {
        var visited = new HashSet<Vector3Int>() {start};
        var queue = new Queue<SinglyLinkedList<Vector3Int>>();
        queue.Enqueue(new SinglyLinkedList<Vector3Int>(start));

        while (queue.Count != 0)
        {
            var node = queue.Dequeue();
            for (int x = -1; x <= 1; x++)
            for (int y = -1; y <= 1; y++)
            {
                var nextPoint = new Vector3Int(node.Value.x + x, node.Value.y + y, start.z);
                var visContains = visited.Contains(nextPoint);
                var isCell = GetCell(nextPoint);
                var contains =
                    visContains ||
                    !isCell ||
                    Math.Abs(x + y) == 2;
                if (contains) continue;
                visited.Add(nextPoint);
                queue.Enqueue(new SinglyLinkedList<Vector3Int>(nextPoint, node));
                if (final == nextPoint)
                    return queue.Reverse().ToList().First();
            }
        }

        return null;
    }

    public static Floor GetFloor() => _floors[_floorIndex];
    public static void ChangeFloor(Vector3Int final)
    {
        _floors[_floorIndex].GetFloorTransform().root.gameObject.SetActive(false);
        _floorIndex = final.z;
        _floors[_floorIndex].GetFloorTransform().root.gameObject.SetActive(true);
    }

    public static bool IsOnStairs(Vector3Int pos)
    {
        var closestStair = _floors[_floorIndex].GetClosestStair(pos);

        return closestStair && closestStair.GetVector3() == pos;
    }
}
