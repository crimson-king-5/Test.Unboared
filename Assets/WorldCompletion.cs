using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;
    [SerializeField] GameWinPanel levelIsComplet;
    StageTime stageTime;
    PauseManager pauseManager;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
        pauseManager = FindObjectOfType<PauseManager>();
        levelIsComplet = FindObjectOfType<GameWinPanel>(true);  
    }

    private void Update()
    {
        if(stageTime.time > timeToCompleteLevel) 
        { 
            pauseManager.PauseGame();
            levelIsComplet.gameObject.SetActive(true);
        }
    }
}
