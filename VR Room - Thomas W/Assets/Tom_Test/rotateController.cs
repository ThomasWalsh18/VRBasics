using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDestroy()
    {
        //Rotation.SetIsRotating(false);
    }
    // Update is called once per frame
    void Update()
    {
         this.transform.Rotate(0f, 4, 0.0f);
    }
}
