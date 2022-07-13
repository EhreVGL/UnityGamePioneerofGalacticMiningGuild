using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LootTile : MonoBehaviour
{
    [HideInInspector] public bool triggerPlayer;
    private bool isInteractable;
    private int childValue;
    private WaitForSeconds oneSecond, tenSeconds;
    private Transform playerTransform;

    private Queue<GameObject> crystalPool;
    private Sequence crystalSequence;
    private Vector3 sequenceMovement;
    private Vector3 crystalDefaultPos;

    private void Awake()
    {
        triggerPlayer = false;
        isInteractable = true;
        childValue = 2;
        oneSecond = new WaitForSeconds(1.5f);
        tenSeconds = new WaitForSeconds(10f);
        playerTransform = null;

        crystalPool = new Queue<GameObject>();
        for(int i = 0; i < 4; i++)
        {
            crystalPool.Enqueue(transform.GetChild(i + 3).gameObject);
        }
        sequenceMovement = Vector3.zero;
        crystalDefaultPos = new Vector3(-0.5f, 0.5f, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerPlayer && isInteractable)
        {
            isInteractable = false;
            StartCoroutine(DropChildObj());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            playerTransform = other.transform;
        }
    }

    private void SpawnCrystal()
    {
        
        GameObject crystal = crystalPool.Dequeue();
        crystal.SetActive(true);
        crystalPool.Enqueue(crystal);
        MoveCrystal(crystal);
    }

    private void MoveCrystal(GameObject crystal)
    {
        sequenceMovement.x = Random.Range(-2, 2);
        sequenceMovement.y = Random.Range(1f, 2);
        sequenceMovement.z = Random.Range(-2, 2);
        crystalSequence = DOTween.Sequence();
        crystalSequence.Append(crystal.transform.DOLocalMove(sequenceMovement, 0.5f));
        crystalSequence.Join(crystal.transform.DOBlendableLocalRotateBy(new Vector3(360, 0, 0), 1f, RotateMode.FastBeyond360));
        crystalSequence.Append(crystal.transform.DOMove(playerTransform.position, 0.5f)).OnComplete(() => { crystal.SetActive(false); });
        crystal.transform.localPosition = crystalDefaultPos;

        InventoryStorage.singleton.IncreaseCrystal(crystal.name, 1);
        Debug.Log(crystal.name + ": " + InventoryStorage.singleton.GetCrystal(crystal.name));
    }
    IEnumerator DropChildObj()
    {
        transform.GetChild(childValue).gameObject.SetActive(false);
        childValue--;

        for(int i = 0; i < 2; i++)
        {
            SpawnCrystal();
        }

        if (childValue < 0)
        {
            yield return tenSeconds;
            childValue = 2;
            for(int i = 0; i < childValue+1; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            yield return oneSecond;
        }
        isInteractable = true;
    }
}
