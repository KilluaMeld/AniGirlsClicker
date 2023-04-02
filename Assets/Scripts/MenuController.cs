using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _backMenuPanel;
    [SerializeField] private GameObject _prestigePanel;
    [SerializeField] private GameObject _achievementsPanel;
    [SerializeField] private GameObject _updateLogPanel;
    [SerializeField] private GameObject _feedbackPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _moreGames;
    
    public void Open_Close_backMenuPanel()
    {
        _backMenuPanel.SetActive(!_backMenuPanel.activeSelf);
    }
    public void Open_Close_prestigePanel()
    {
        _backMenuPanel.SetActive(false);
        _prestigePanel.SetActive(!_prestigePanel.activeSelf);
    }
    public void Open_Close_achievementsPanel()
    {
        _backMenuPanel.SetActive(false);
        _achievementsPanel.SetActive(!_achievementsPanel.activeSelf);
    }
    public void Open_Close_updateLogPanel()
    {
        _backMenuPanel.SetActive(false);
        _updateLogPanel.SetActive(!_updateLogPanel.activeSelf);
    }
    public void Open_Close_feedbackPanel()
    {
        _backMenuPanel.SetActive(false);
        _feedbackPanel.SetActive(!_feedbackPanel.activeSelf);
    }
    public void Open_Close_settingsPanel()
    {
        _backMenuPanel.SetActive(false);
        _settingsPanel.SetActive(!_settingsPanel.activeSelf);
    }
    public void Open_Close_moreGames()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Minor");
    }

}
