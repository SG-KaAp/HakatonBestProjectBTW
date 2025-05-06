using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslatorDialouges : MonoBehaviour
{
    [SerializeField] private bool translateOnStart = true;
    [SerializeField] private DialougeSO dialougeSO;
    [SerializeField] private string translateFileName;
    [SerializeField] private string translateLanguage = "English";
    private StreamReader translateFile;
    private List<string> translatesList = new List<string>();

    private void Start()
    {
        SettingsManager.ReloadTranslates += Translate;
        if (translateOnStart)
        {
            Translate();
        }
    }

    private void OnDestroy()
    {
        SettingsManager.ReloadTranslates -= Translate;
    }

    public void Translate()
    {
        translateLanguage = SettingsManager.Language;
        translateFile = new StreamReader("Translate/" + translateLanguage + "/" + translateFileName + ".txt");
        translatesList.Clear();
        while (!translateFile.EndOfStream)
        {
            translatesList.Add(translateFile.ReadLine());
        }
        dialougeSO.phrases.Clear();
        foreach (string s in translatesList)
        {
            dialougeSO.phrases.Add(s);
        }
    }
}
