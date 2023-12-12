using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;
    [SerializeField] private List<UpgradButton> upgradButtons;
    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    private void Start()
    {
        HideButtons();
    }

    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {
        Clean();
        pauseManager.PauseGame();
        panel.SetActive(true);

       
        for (int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradButtons[i].gameObject.SetActive(true);
            upgradButtons[i].set(upgradeDatas[i]);
        }
    }

    public void Clean()
    {
        for (int i = 0; i < upgradButtons.Count; i++)
        {
            upgradButtons[i].Clean();
        }
    }
    
    public void Upgrade(int pressedButtonID)
    {
        GameManager.instance.playerTransform.GetComponent<Level>().Upgrades(pressedButtonID);
        ClosePanel();
    }
    
    public void ClosePanel()
    {
        HideButtons();
        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    private void HideButtons()
    {
        for (int i = 0; i < upgradButtons.Count; i++)
        {
            upgradButtons[i].gameObject.SetActive(false);
        }
    }
}
