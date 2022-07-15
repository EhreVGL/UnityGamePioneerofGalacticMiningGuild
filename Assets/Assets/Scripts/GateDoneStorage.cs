using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public sealed class GateDoneStorage
{
    private static GateDoneStorage instance;
    public static GateDoneStorage singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GateDoneStorage();
                PlayerPrefs.GetInt("GlobalMap1", 0);
                PlayerPrefs.GetInt("GlobalMap2", 0);
                PlayerPrefs.GetInt("GlobalMap3", 0);
                PlayerPrefs.GetInt("RedMap1", 0);
                PlayerPrefs.GetInt("RedMap3", 0);
                PlayerPrefs.GetInt("GreenMap1", 0);
                PlayerPrefs.GetInt("GreenMap3", 0);
                PlayerPrefs.GetInt("NavyBlueMap1", 0);
                PlayerPrefs.GetInt("NavyBlueMap3", 0);
                PlayerPrefs.GetInt("MagentaMap1", 0);
                PlayerPrefs.GetInt("MagentaMap3", 0);
                PlayerPrefs.GetInt("BrownMap1", 0);
                PlayerPrefs.GetInt("BrownMap3", 0);
                PlayerPrefs.GetInt("LimeMap1", 0);
                PlayerPrefs.GetInt("LimeMap3", 0);
                PlayerPrefs.GetInt("TealMap1", 0);
                PlayerPrefs.GetInt("TealMap3", 0);
                PlayerPrefs.GetInt("IndigoMap1", 0);
                PlayerPrefs.GetInt("IndigoMap3", 0);
                PlayerPrefs.GetInt("DarkBlueMap1", 0);
                PlayerPrefs.GetInt("DarkBlueMap3", 0);
            }
            return instance;
        }
    }
    public void ResetAll()
    {

        PlayerPrefs.SetInt("GlobalMap1", 0);
        PlayerPrefs.SetInt("GlobalMap2", 0);
        PlayerPrefs.SetInt("GlobalMap3", 0);
        PlayerPrefs.SetInt("RedMap1", 0);
        PlayerPrefs.SetInt("RedMap3", 0);
        PlayerPrefs.SetInt("GreenMap1", 0);
        PlayerPrefs.SetInt("GreenMap3", 0);
        PlayerPrefs.SetInt("NavyBlueMap1", 0);
        PlayerPrefs.SetInt("NavyBlueMap3", 0);
        PlayerPrefs.SetInt("MagentaMap1", 0);
        PlayerPrefs.SetInt("MagentaMap3", 0);
        PlayerPrefs.SetInt("BrownMap1", 0);
        PlayerPrefs.SetInt("BrownMap3", 0);
        PlayerPrefs.SetInt("LimeMap1", 0);
        PlayerPrefs.SetInt("LimeMap3", 0);
        PlayerPrefs.SetInt("TealMap1", 0);
        PlayerPrefs.SetInt("TealMap3", 0);
        PlayerPrefs.SetInt("IndigoMap1", 0);
        PlayerPrefs.SetInt("IndigoMap3", 0);
        PlayerPrefs.SetInt("DarkBlueMap1", 0);
        PlayerPrefs.SetInt("DarkBlueMap3", 0);
    }
    public int GetGate(string gate)
    {
        return PlayerPrefs.GetInt(gate, 0);
    }
    public void GateDone(string gate)
    {
        PlayerPrefs.SetInt(gate, GetGate(gate) + 1);
    }
    public int AllDone(int value)
    {
        
        if (PlayerPrefs.GetInt("GlobalMap1", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("GlobalMap2", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("GlobalMap3", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("RedMap1", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("RedMap3", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("GreenMap1", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("GreenMap3", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("NavyBlueMap1", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("NavyBlueMap3", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("MagentaMap1", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("MagentaMap3", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("BrownMap1", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("BrownMap3", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("LimeMap1", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("LimeMap3", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("TealMap1", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("TealMap3", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("IndigoMap1", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("IndigoMap3", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("DarkBlueMap1", 0) >= 1) { value++; }
        if (PlayerPrefs.GetInt("DarkBlueMap3", 0) >= 1) { value++; }

        return value;
    }
}
