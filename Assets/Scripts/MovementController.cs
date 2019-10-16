using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private static List<Vector3Int> _fullPath;
    private static Vector3Int _finish;
    [SerializeField] private Vector3Int finish; //x,y- положение на карте, z - этаж
    [SerializeField] private Transform player;
    [SerializeField] private float stepTime;
    [SerializeField] private Vector3Int playerPos;
    [SerializeField]
    private bool _movingInProcess;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            SetFinal(finish);
        if (playerPos != _finish && !_movingInProcess)
        {
            StartCoroutine(MovingRoutine());
        }
    }

    private IEnumerator MovingRoutine()
    {
        var onSameFloor = playerPos.z == _finish.z;
        var a = onSameFloor ? _finish : Map.GetFloor().GetClosestStair(playerPos).GetVector3(); 
        _fullPath = GetPoints(Map.FindPath(playerPos, a));
        _movingInProcess = true;
        while (_fullPath.Count > 0)
        {
            MakeStep();
            yield return new WaitForSeconds(stepTime); 
            _fullPath.RemoveAt(0);
        }

        if (!onSameFloor)
        {
            Map.ChangeFloor(_finish);
        }

        _movingInProcess = false;
    }

    private void MakeStep()
    {
        var point = _fullPath[0];
        player.position = new Vector3(point.x * Map.CellSize, -point.y * Map.CellSize, player.position.z);
        playerPos = Map.ConvertGlobalPosToMapPos(player.position, _finish.z);
        playerPos.y *= -1;
    }
    
    private static List<Vector3Int> GetPoints(SinglyLinkedList<Vector3Int> list)
    {
        var result = new List<Vector3Int>();
        if (list == null) return new List<Vector3Int>();
        while (list.Previous!=null)
        {
            result.Add(list.Value);
            list = list.Previous;
        }
        result.Reverse();
        return result;
    }

    public static List<Vector3Int> GetPath() => _fullPath;

    public static void SetFinal(Vector3Int pos)
    {
        _finish = pos;
    }

    public static void SetFinal(string roomName)
    {
        _finish = Map.GetCell(roomName).GetVector3();
        print(_finish);
    }
}