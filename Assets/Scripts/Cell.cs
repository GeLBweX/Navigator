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
    [SerializeField] private Text text;
	[SerializeField] GameObject canvas;
	[SerializeField] bool updateCell;

	public void UpdateCell()
	{
		text.text = cellName;
		var gotName = cellName != "";
		canvas.SetActive(gotName);
		text.gameObject.SetActive(gotName);
		if (isStairs)
			stairSign.SetActive(true);
		updateCell = false;	
 }


	private void Update()
	{
		if (updateCell)
			UpdateCell();
	}

	public void ChangeName(string newName)
	{
		cellName = newName;
		UpdateCell();
	}
    public void SetCoord(Vector3Int newCoord) => coords = newCoord;
    public bool IsStairs() => isStairs;
    public Vector3Int GetVector3() => coords;
    public string GetCellName() => cellName;
}
