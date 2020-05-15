using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
       Invoke("LoadFirstScene", 2f);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
