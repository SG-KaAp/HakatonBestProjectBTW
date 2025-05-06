using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class MenuLogic : MonoBehaviour
{
    [SerializeField] CanvasGroup SettingsPanel;
    public void SceneLoad(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Quit() => Application.Quit();
    public void OpenSettings()
    {
        SettingsPanel.gameObject.SetActive(true);
        SettingsPanel.DOFade(1,0.5f);
    }
    public void CloseSettings() => SettingsPanel.DOFade(0,0.5f).OnComplete(() => SettingsPanel.gameObject.SetActive(false));
    public void SetLanguage (int lang) =>   SettingsManager.SetLanguage(lang);
    public void VSyncSet(bool enable) => SettingsManager.EnableVSync(enable ? 1 : 0);
    public void MSAASet(Int32 value)
    {
        if (value == 0)
            value = 1;
        else if (value == 1)
            value = 2;
        else if (value == 2)
            value = 4;
        else if (value == 3)
            value = 8;
        SettingsManager.EnableMSAA(value);
    }
}
