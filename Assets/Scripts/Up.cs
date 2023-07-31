using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{   
    private float speed = 3f;

    private void Start() {
        Invoke("DestroyUp", 2f);
    }

    private void FixedUpdate() {
        transform.Translate(Vector3.up * Time.fixedDeltaTime * speed);
    }   
    
    public void DestroyUp(){
        Destroy(gameObject);
    }
    
}
