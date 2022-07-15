using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSystem : MonoBehaviour
{
    [SerializeField] private int sceneIndexValue;
    private int allDone;
    [SerializeField] private string gateName;
    private void Awake()
    {
        allDone = 0;
    }
    private void Update()
    {
        if (GateDoneStorage.singleton.AllDone(allDone) >= 21)
        {
            GateDoneStorage.singleton.ResetAll();
            InventoryStorage.singleton.ResetAll();
            SceneManager.LoadScene(0);
        }
        allDone = 0;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            SceneManager.LoadScene(sceneIndexValue);
        }
    }
}
