using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class MonsterDB : ScriptableObject
{
	public List<MonsterEntity> Monster; // Replace 'EntityType' to an actual type that is serializable.
}
