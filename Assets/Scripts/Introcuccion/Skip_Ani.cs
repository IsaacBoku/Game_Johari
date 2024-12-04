using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip_Ani : MonoBehaviour
{
    public Animation_Pass skip;


    private void Start()
    {
        skip = FindAnyObjectByType<Animation_Pass>();
    }

    public void SkipTrue()
    {
        skip.isSkip = true;
    }
}
