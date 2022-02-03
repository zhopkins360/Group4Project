using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOutOfBounds : MonoBehaviour
{
    private Recycle rec;

    void Start()
    {
        rec = gameObject.GetComponent<Recycle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 4.5)
        {
            rec.recycle();
        }
    }
}
