using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //  throw new System.Exception(" 2This is a Backtrace Error");
        try
        {
            throw new System.Exception("This is a Backtrace Error !:]");
        }
        catch (System.Exception exp)
        {
            Debug.LogError(exp, this);
        }

    }
}

