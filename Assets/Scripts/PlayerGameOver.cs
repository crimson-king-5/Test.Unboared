using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;
   public void GameOver()
    {
     
        Debug.Log("Over");
        GetComponent<PlayerMovement>().enabled = false;
        gameOverPanel.SetActive(true); 
        weaponParent.SetActive(false);

    }
}
