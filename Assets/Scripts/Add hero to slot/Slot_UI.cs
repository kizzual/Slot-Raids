using UnityEngine;
using UnityEngine.UI;

public class Slot_UI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image _currentHeroImage;
    [SerializeField] private Text _currentRank;
    [SerializeField] private Text _currentLvl;
    [SerializeField] private Text _goldProfit;
    [Space]
    [Header("Panels")]
    [SerializeField] private GameObject _freePanel;
    [SerializeField] private GameObject _choosePanel;
    [SerializeField] private GameObject _closedHero;


    public Hero m_CurrentHero;
    public void Initialise()
    {
        m_CurrentHero.Initialise();
        Debug.Log("slot=  " + m_CurrentHero.currentRaidSlot);
        _currentHeroImage.sprite = m_CurrentHero.Icon;
        _currentRank.text = m_CurrentHero.Rank.ToString();
        _currentLvl.text = m_CurrentHero.Level.ToString();
        _goldProfit.text = ConvertText.FormatNumb(m_CurrentHero.GetGoldProfit());
        if (m_CurrentHero.isOpened)
            _closedHero.SetActive(false);
        else
            _closedHero.SetActive(true);
        if (m_CurrentHero.currentRaidSlot != 0)
        {
            _freePanel.SetActive(true);
            _choosePanel.SetActive(false);
        }
        else
        {
            _freePanel.SetActive(false);
            _choosePanel.SetActive(true);
        }
    }

    private void OnEnable()
    {
        Initialise();
    }
    public void OpenStats() => GlovalEventSystem.OpenHeroStats(m_CurrentHero);

}
