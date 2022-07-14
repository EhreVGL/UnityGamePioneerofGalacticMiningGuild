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
            }
            return instance;
        }
    }
    public void ResetAll()
    {
        PlayerPrefs.SetInt("GlobalMap1", 0);
        PlayerPrefs.SetInt("GlobalMap2", 0);
        PlayerPrefs.SetInt("GlobalMap3", 0);
    }
    public int GetGate(string gate)
    {
        return PlayerPrefs.GetInt(gate, 1);
    }
    public void GateDone(string gate)
    {
        PlayerPrefs.SetInt(gate, GetGate(gate) + 1);
    }
}
