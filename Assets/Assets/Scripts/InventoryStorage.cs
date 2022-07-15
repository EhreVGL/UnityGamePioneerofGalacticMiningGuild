using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public sealed class InventoryStorage
{
    private static InventoryStorage instance;
    public static InventoryStorage singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new InventoryStorage();
                PlayerPrefs.GetInt("BlueCrystal", 0);
                PlayerPrefs.GetInt("BrownCrystal", 0);
                PlayerPrefs.GetInt("CyanCrystal", 0);
                PlayerPrefs.GetInt("DarkBlueCrystal", 0);
                PlayerPrefs.GetInt("DeepOrangeCrystal", 0);
                PlayerPrefs.GetInt("DeepPurpleCrystal", 0);
                PlayerPrefs.GetInt("GreenCrystal", 0);
                PlayerPrefs.GetInt("IndigoCrystal", 0);
                PlayerPrefs.GetInt("LightBlueCrystal", 0);
                PlayerPrefs.GetInt("LimeCrystal", 0);
                PlayerPrefs.GetInt("MagentaCrystal", 0);
                PlayerPrefs.GetInt("NavyBlueCrystal", 0);
                PlayerPrefs.GetInt("OrangeCrystal", 0);
                PlayerPrefs.GetInt("PinkCrystal", 0);
                PlayerPrefs.GetInt("PurpleCrystal", 0); 
                PlayerPrefs.GetInt("RedCrystal", 0);
                PlayerPrefs.GetInt("TealCrystal", 0);
                PlayerPrefs.GetInt("YellowCrystal", 0);
            }
            return instance;
        }
    }
    public void ResetAll()
    {
        PlayerPrefs.SetInt("BlueCrystal", 0);
        PlayerPrefs.SetInt("BrownCrystal", 0);
        PlayerPrefs.SetInt("CyanCrystal", 0);
        PlayerPrefs.SetInt("DarkBlueCrystal", 0);
        PlayerPrefs.SetInt("DeepOrangeCrystal", 0);
        PlayerPrefs.SetInt("DeepPurpleCrystal", 0);
        PlayerPrefs.SetInt("GreenCrystal", 0);
        PlayerPrefs.SetInt("IndigoCrystal", 0);
        PlayerPrefs.SetInt("LightBlueCrystal", 0);
        PlayerPrefs.SetInt("LimeCrystal", 0);
        PlayerPrefs.SetInt("MagentaCrystal", 0);
        PlayerPrefs.SetInt("NavyBlueCrystal", 0);
        PlayerPrefs.SetInt("OrangeCrystal", 0);
        PlayerPrefs.SetInt("PinkCrystal", 0);
        PlayerPrefs.SetInt("PurpleCrystal", 0);
        PlayerPrefs.SetInt("RedCrystal", 0);
        PlayerPrefs.SetInt("TealCrystal", 0);
        PlayerPrefs.SetInt("YellowCrystal", 0);
    }
    public int GetCrystal(string crystal)
    {
        return PlayerPrefs.GetInt(crystal, 1);
    }
    public void IncreaseCrystal(string crystal, int value)
    {
        PlayerPrefs.SetInt(crystal, GetCrystal(crystal) + value);
    }
    public void DecreaseCrystal(string crystal, int value)
    {
        PlayerPrefs.SetInt(crystal, GetCrystal(crystal) - value);
    }
}
