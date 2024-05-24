using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class playerStat : ScriptableObject
{
	public List<playerStatEntity> playerData; // Replace 'EntityType' to an actual type that is serializable.
}
