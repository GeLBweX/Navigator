using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private string cellName;
    [SerializeField] private Vector3Int coords;
    [SerializeField] private bool isStairs;
    
    public void SetCoord(Vector3Int newCoord) => coords = newCoord;
    public bool IsStairs() => isStairs;
    public Vector3Int GetVector3() => coords;
    public string GetCellName() => cellName;
}
