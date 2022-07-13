using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private Vector3 distance;
    
    //enable when bridge become active
    
    // Start is called before the first frame update
    void Start()
    {
        InventoryStorage.singleton.ResetAll();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
