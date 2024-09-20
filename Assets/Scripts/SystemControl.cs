using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartProject();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitProject();
        }
    }

    //重启程序
    void RestartProject()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //关闭程序
    void ExitProject()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
