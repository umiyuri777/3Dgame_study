using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Sphereと何かが衝突");
        if (other.gameObject.tag == "player")
        {  
            Debug.Log("Sphereとプレイヤーが衝突");
            Destroy(this.gameObject);
        }
    }
}
