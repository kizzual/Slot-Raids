using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Character heroes;
    [SerializeField] private Zone _zone;
    [SerializeField] private ScrollingController scrollingController;

    public int itemPercent;
    public int deathPercent;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void CurrentZone(Zone zone)
    {
        if(!zone.IsClosed)
        {
            _zone = zone;
        }
    }
    public void StartRaid()
    {
        scrollingController.StartRaid();
    }
    public void GenerateSlots() // ������������ ������ �����
    {
          for (int i = 0; i < 9; i++)
          {
   //           scrollingController.FormationSlot(_zone, heroes, i); // �������� �� ����
          }
       // scrollingController.FormationSlot(_zone, heroes, 0); // �������� �� ����
    }
    private void CheckFinishingScrolling()
    {

    }

}
