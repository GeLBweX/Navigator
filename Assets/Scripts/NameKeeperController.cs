using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NameKeeperController : MonoBehaviour
{
	[SerializeField]
	bool doIt;
	[SerializeField]
	List<String> namedCells=new List<String>();

	private void Start()
	{
		DoIt();
	}

	private void DoIt()
	{
		var floors = Map.GetFloors();
		foreach(var e in floors)
		{
			var z = e.GetcellsNames();
			namedCells.AddRange(e.GetcellsNames().OrderBy(x=>x).Select(x=>x));
		}
	}
}
