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
        if(Mathf.Abs(transform.position.y - 0.3f) > 0.1)
        {
            rec.recycle();
        }
        else if (Mathf.Abs(transform.position.x) > 4)
        {
            rec.recycle();
        }
    }
}
