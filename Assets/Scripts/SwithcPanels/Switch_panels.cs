using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Switch_panels : MonoBehaviour
{
    [SerializeField] private List<GameObject> _panels;
    [SerializeField] private bool _openWithStartPage = false;  
    private void OnEnable()
    {
        if(_openWithStartPage)
        {
            SwitchPanel(1);
        }
    }
    public void SwitchPanel(int PageNumber)
    {
        
        for (int i = 0; i < _panels.Count; i++)
        {
            if (PageNumber - 1 == i)
                _panels[i].SetActive(true);
            else
                _panels[i].SetActive(false);
        }
    }
}
