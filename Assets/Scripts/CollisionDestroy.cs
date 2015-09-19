using UnityEngine;
using System.Collections;

public class CollisionDestroy : MonoBehaviour {

    public string objectTag;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == objectTag) {
            Destroy(col.gameObject);
        }
    }
}
