using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class MarkAccordingToFloor : MonoBehaviour
{
	[SerializeField] int floor;
	[SerializeField] Transform cells;
	[SerializeField] bool doIt;
	[SerializeField] bool updateAll;
	[SerializeField] int childCount;
	[SerializeField] Vector3 moveVector;
	[SerializeField] bool moveCells;
	private void Update()
	{
		childCount = cells.childCount;
		if (moveCells)
			MoveAllCells();
		if (doIt)
		{
			doIt = false;
			print("DOING IT");		
   DOIT();
		}
		if (updateAll)
			UpdateAll();
	}

	private void UpdateAll()
	{
		for (int i = 0; i < cells.childCount; i++)
		{
			var child = cells.GetChild(i).GetComponent<Cell>();
			child.UpdateCell();
		}
		updateAll = false;
	}

	private void DOIT()
	{
		for (int i = 0; i < cells.childCount; i++)
		{
			var child = cells.GetChild(i).GetComponent<Cell>();
			if(child.IsStairs())
			{
				var final = floor.ToString() + " Stairs";
				child.ChangeName(final);
			}
			if (child.GetCellName().Length>1)
			{
				var a = child.GetCellName();
				var final = "Р-" + floor.ToString() + a.Substring(3);
				print(final);
				child.ChangeName(final);
			}
		}
	}

	void MoveAllCells()
	{
		for (int i = 0; i < cells.childCount; i++)
		{
			var child = cells.GetChild(i);
			child.Translate(moveVector, Space.Self);
		}
		moveCells = false;
	}
}
