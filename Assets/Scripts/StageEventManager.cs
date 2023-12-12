using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    private bool hasSpawn = false;
    [SerializeField] StageData stageData;
    [SerializeField] EnemiesManager enemiesManager;

    StageTime stageTime;
    int eventIndexer;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEntityLoop());
    }

    IEnumerator SpawnEntityLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(stageData.stageEvents[eventIndexer].time);
            SpawnEntity();
            Debug.Log(stageData.stageEvents[eventIndexer].message);
            if (eventIndexer < stageData.stageEvents.Count-1)
            {
                eventIndexer += 1;
            }
        }

        yield break;
    }

    public void SpawnEntity()
    {
        for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
        {
            switch (stageData.stageEvents[eventIndexer].eventType)
            {
                case StageEventType.SpawnEnemy:
                    enemiesManager.SpawnEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn);

                    break;

                case StageEventType.SpawnObject:

                    SpawnManager.instance.SpawnObject(GameManager.instance.playerTransform.position,
                        stageData.stageEvents[eventIndexer].objectToSpawn
                    );

                    break;

                case StageEventType.Winstage:

                    break;
            }
        }
    }
}