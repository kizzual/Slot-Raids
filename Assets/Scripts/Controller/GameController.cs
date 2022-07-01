using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private ScrollingController scrollingController;

    [SerializeField] List<RaiButtonAnimation> RaidButtons;
    [SerializeField] List<Image> RaidButtons_Filed;
    public Button currentButton;

    [SerializeField] private float CountToFireButton;
    private float _buttonsCount;
    [SerializeField] private int TImeToReloadButton;
    private float _timer;
    private float _afkTimer;
    private bool _afk = false;
    private bool _buttonSoREeloading;

    public List<float> isOpening = new List<float>();
    private List<HeroSlot> heroSlot = new List<HeroSlot>();
    private const float timeToEggOpen = 86400;


    public TowerControl tower;
    private void Awake()
    {
        _buttonsCount = CountToFireButton;
        scrollingController._scrollEnded += ScrollEnded;
        currentButton = RaidButtons[0].GetComponent<Button>();
    }

    private void Update()
    {
        for (int i = 0; i < isOpening.Count; i++)
        {
            isOpening[i] += Time.deltaTime;
            heroSlot[i].DisplayTimer(isOpening[i]);
            if (isOpening[i] >= timeToEggOpen)
            {
                heroSlot[i].SkipEgg();
                heroSlot.RemoveAt(i);
                isOpening.RemoveAt(i);
            }
        }
       
    }
    void FixedUpdate()
    {
        if( _buttonSoREeloading )
        {
            _timer += Time.fixedDeltaTime;

            if (_timer >= TImeToReloadButton)
            {
                ReloadButton();
            }
        }
        if(_afk)
        {
            _afkTimer += Time.fixedDeltaTime;
            if(_afkTimer > 3f)
            {
                _afk = false;
                ShowHeroPanel();
            }
        }
    }
   
    public void SwitchButtons(Zone zone)
    {
        foreach (var item in RaidButtons)
        {
            item.gameObject.SetActive(false);
        }
        if(zone.ZoneElement == Zone.zoneElement.Neutral)
        {
            currentButton = RaidButtons[0].GetComponent<Button>();
            RaidButtons[0].gameObject.SetActive(true);
        }
        else if(zone.ZoneElement == Zone.zoneElement.Undead)
        {
            currentButton = RaidButtons[1].GetComponent<Button>();
            RaidButtons[1].gameObject.SetActive(true);
        }
        else if (zone.ZoneElement == Zone.zoneElement.Order)
        {
            currentButton = RaidButtons[2].GetComponent<Button>();
            RaidButtons[2].gameObject.SetActive(true);
        }
        else if (zone.ZoneElement == Zone.zoneElement.Demon)
        {
            currentButton = RaidButtons[3].GetComponent<Button>();
            RaidButtons[3].gameObject.SetActive(true);
        }
    }
    private void ScrollEnded()
    {
        currentButton.enabled = true;

        _afk = true;
    }
    public void StartRaid()
    {
        int heroCanRaid = 0;
        foreach (var item in scrollingController.scrollingObjects)
        {
            if(item.currentHero != null)
            {
                heroCanRaid ++;
            }    
        }
        if (_buttonsCount > 0 && heroCanRaid > 0  && CheckForReadySlotScrolling())
        {
            Debug.Log("CanRaid");
            HideHeroPanels();
            _afk = false;
            _afkTimer = 0;
            currentButton.enabled = false;

            _buttonSoREeloading = true;
            scrollingController.StartRaid();
            _buttonsCount--;
            currentButton.GetComponent<RaiButtonAnimation>().StartAnimation();
        }
        for (int i = 0; i < RaidButtons_Filed.Count; i++)
        {
            RaidButtons_Filed[i].fillAmount = (_buttonsCount / CountToFireButton);
        }
    }
    private bool CheckForReadySlotScrolling()           //загрушка пока не перепишется получение предметов
    {
       
        for (int i = 0; i <= tower.currentGradeTower; i++)
        {
            Debug.Log("asd");
            if (scrollingController.scrollingObjects[i].currentHero == null)
            {
                return false;
            }
        }
        return true;
    }
    private void ReloadButton()
    {
        _buttonsCount++;
        if(_buttonsCount >= CountToFireButton)
        {
            _buttonSoREeloading = false;
            _timer = 0;
        }
        for (int i = 0; i < RaidButtons_Filed.Count; i++)
        {
            RaidButtons_Filed[i].fillAmount = (_buttonsCount / CountToFireButton);
        }
        _timer = 0;
       
    }
    private void HideHeroPanels()  //добавить анимацию
    {
        for (int i = 0; i < scrollingController.scrollingObjects.Count; i++)
        {
            if (scrollingController.scrollingObjects[i].currentHero != null && scrollingController.scrollingObjects[i].isActive )
            {
                scrollingController.scrollingObjects[i].raidSlotInfo.gameObject.SetActive(false);
            }
        }
    }
    public void ShowHeroPanel()    //добавить анимацию
    {
        for (int i = 0; i < scrollingController.scrollingObjects.Count; i++)
        {
            if (scrollingController.scrollingObjects[i].currentHero != null && scrollingController.scrollingObjects[i].isActive && !scrollingController._isScrolling)
            {
                scrollingController.scrollingObjects[i].raidSlotInfo.gameObject.SetActive(true);
            }
        }
    }


    public void StartEggOpening(HeroSlot slot)
    {
        float tmp = 0f;
        heroSlot.Add(slot);
        isOpening.Add(tmp);
    }
}
