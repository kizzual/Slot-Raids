using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{
    private float m_timer = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        m_timer += Time.fixedDeltaTime;
        if(m_timer > 1f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
