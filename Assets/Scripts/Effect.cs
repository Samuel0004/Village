using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float deleteTime;

    private void Update()
    {
        deleteTime -= Time.deltaTime;
        if (deleteTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
