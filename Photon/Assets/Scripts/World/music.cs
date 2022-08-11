using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public static music instance;
<<<<<<< Updated upstream
 
=======

>>>>>>> Stashed changes
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
<<<<<<< Updated upstream

=======
     
>>>>>>> Stashed changes
    }
}
