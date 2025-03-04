using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player potentialPlayer = other.GetComponent<Player>();

        if (potentialPlayer != null)
        {
            int toLoad = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(toLoad + 1);
        }
    }

}

