using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] CrystalValueTexts;
    private string[] defaultTexts;

    private void Start()
    {
        defaultTexts = new string[CrystalValueTexts.Length];

        for (int i = 0; i < CrystalValueTexts.Length; i++)
        {
            defaultTexts[i] = CrystalValueTexts[i].text;
        }
    }
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < CrystalValueTexts.Length; i++)
        {
            CrystalValueTexts[i].text = defaultTexts[i] + " " + InventoryStorage.singleton.GetCrystal(CrystalValueTexts[i].name.Substring(0, CrystalValueTexts[i].name.IndexOf("_"))).ToString();
        }
    }
}
