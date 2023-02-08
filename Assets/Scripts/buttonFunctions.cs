using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{
    public bool confirmDropEnabled = true;
    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void confirm()
    {
        if(confirmDropEnabled)
        {
            
        }
    }
}
