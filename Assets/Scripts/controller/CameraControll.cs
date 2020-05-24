using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public Transform targetTr;
    public float dist = 10f;
    public float height = 3.0f;
    public float dampTrace = 20.0f;

    public Transform tr;
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // tr.position = Vector2.Lerp(tr.position, targetTr.position - (targetTr.forward * dist) , Time.deltaTime * dampTrace);
        tr.position = targetTr.position + new Vector3(0, 0, -10);
        
        tr.LookAt(targetTr.position);
    }


}
