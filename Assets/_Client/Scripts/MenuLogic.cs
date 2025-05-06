using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
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
}
