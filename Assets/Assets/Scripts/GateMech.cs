using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GateMech : MonoBehaviour
{
    private bool triggerPlayer;
    private string CrystalName;
    private int valueInGate;
    private int valueNeeded;
    private WaitForSeconds waitTime;
    private bool[] transferCompleted;
    private bool[] crystalLoaded;
    private int transferCompletedValue;
    private int crystalLoadedValue;
    [SerializeField] private TextMeshProUGUI[] CrystalsTextsInGate;
    [SerializeField] private GameObject OutsideCollider;
    [SerializeField] private GameObject Portal;
    private void Awake()
    {
        triggerPlayer = false;
        CrystalName = "";
        valueInGate = 0;
        valueNeeded = 0;
        waitTime = new WaitForSeconds(0.05f);
        transferCompleted = new bool[3];
        crystalLoaded = new bool[3];
        transferCompletedValue = 0;
        crystalLoadedValue = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GateDoneStorage.singleton.GetGate(SceneManager.GetActiveScene().name + this.gameObject.name) >= 1)
        {
            //Bridge is enabled
            triggerPlayer = false;
            Portal.SetActive(true);
            OutsideCollider.SetActive(false);
            this.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (triggerPlayer)
        {
            StartCoroutine(TransferCrystal());
        }
        for(int i = 0; i < 3; i++)
        {
            if (crystalLoaded[i])
            {
                crystalLoadedValue++;
            }
            else
            {
                crystalLoadedValue = 0;
                break;
            }
        }
        if(crystalLoadedValue >= 3)
        {
            //Bridge is enabled
            triggerPlayer = false;
            Portal.SetActive(true);
            OutsideCollider.SetActive(false);

            GateDoneStorage.singleton.GateDone(SceneManager.GetActiveScene().name + this.gameObject.name);

            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            triggerPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            triggerPlayer = false;
        }
    }

    IEnumerator TransferCrystal()
    {
        while (true)
        {
            for (int i = 0; i < CrystalsTextsInGate.Length; i++)
            {
                CrystalName = CrystalsTextsInGate[i].gameObject.name.Substring(0, CrystalsTextsInGate[i].gameObject.name.IndexOf("_"));
                int.TryParse(CrystalsTextsInGate[i].text.Substring(0, CrystalsTextsInGate[i].text.IndexOf("/")), out valueInGate);
                int.TryParse(CrystalsTextsInGate[i].text.Substring(CrystalsTextsInGate[i].text.IndexOf("/")+1, CrystalsTextsInGate[i].text.Length - (CrystalsTextsInGate[i].text.IndexOf("/")+1)), out valueNeeded);


                if (valueInGate < valueNeeded)
                {
                    if (InventoryStorage.singleton.GetCrystal(CrystalName) > 0)
                    {
                        InventoryStorage.singleton.DecreaseCrystal(CrystalName, 1);
                        valueInGate++;
                        CrystalsTextsInGate[i].text = valueInGate + "/" + valueNeeded;  
                    }
                    else
                    {
                        transferCompleted[i] = true;
                    }
                }
                else
                {
                    crystalLoaded[i] = true;
                }

                yield return waitTime;
            }

            for (int i = 0; i < CrystalsTextsInGate.Length; i++)
            {
                    if (transferCompleted[i])
                    {
                        transferCompletedValue++;
                    }
            }
            if(transferCompletedValue == 3)
            {
                triggerPlayer = false;
            }
            else
            {
                transferCompletedValue = 0;
            }
            if(triggerPlayer == false)
            {
                for (int i = 0; i < CrystalsTextsInGate.Length; i++)
                {
                    transferCompleted[i] = false;
                    transferCompletedValue = 0;
                }
                break;
            }
        }
    }
}
