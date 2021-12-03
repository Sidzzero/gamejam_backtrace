using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //  Debug.LogError("This is a Backtrace Error", this);
        throw new System.Exception("This is a Backtrace Error");
    }
   
   
}
