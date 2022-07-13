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
                PlayerPrefs.GetInt("RedCrystal", 0);
                PlayerPrefs.GetInt("GreenCrystal", 0);
                PlayerPrefs.GetInt("BlueCrystal", 0);
            }
            return instance;
        }
    }
    public void ResetAll()
    {
        PlayerPrefs.SetInt("RedCrystal", 0);
        PlayerPrefs.SetInt("GreenCrystal", 0);
        PlayerPrefs.SetInt("BlueCrystal", 0);
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
