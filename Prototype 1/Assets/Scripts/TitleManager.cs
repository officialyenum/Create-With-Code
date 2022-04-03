using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Challenge1");
        }

        if (Input.GetKey(KeyCode.Return)) {
			SceneManager.LoadScene("Prototype1");
		}
    }
}
