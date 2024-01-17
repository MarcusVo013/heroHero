using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDisable : MonoBehaviour
{
    public void DisableFunctionality()
    {
        // Disable or stop the desired functionality of the class
        // For example, you can set a flag to prevent updates or disable specific components
        enabled = false;  // Disable the script
        // Other code to disable functionality...
    }

   public void EnabledFunctionality()
    {
        enabled = true;
    }
}
