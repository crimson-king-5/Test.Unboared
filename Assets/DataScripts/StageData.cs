using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StageEventType
{
    SpawnEnemy,
    SpawnObject,
    Winstage
}
[Serializable]
public class StagerEvent
{
    public StageEventType eventType;
    public int time;
    public string message;
    
    public EnemyData enemyToSpawn;
    public GameObject objectToSpawn;
    public int count;
}




[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public List<StagerEvent> stageEvents;
}
