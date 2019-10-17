using System;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class Cell : MonoBehaviour
{
    [SerializeField] private string cellName;
    [SerializeField] private Vector3Int coords;
    [SerializeField] private bool isStairs;
    [SerializeField] GameObject stairSign;
    [SerializeField] private bool showName = false;
    [SerializeField] private Text text;

    private void Start()
    {
        if(cellName!="")
        {
            text.text=cellName;
            text.gameObject.SetActive(true);
        }
        if(isStairs)
            stairSign.SetActive(true);
    }

    private void Update()
    {
        if(cellName!="")
        {
            text.text=cellName;
            text.gameObject.SetActive(true);
        }
        if(isStairs)
            stairSign.SetActive(true);
    }

    public void SetCoord(Vector3Int newCoord) => coords = newCoord;
    public bool IsStairs() => isStairs;
    public Vector3Int GetVector3() => coords;
    public string GetCellName() => cellName;
}
