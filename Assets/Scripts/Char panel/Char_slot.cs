using UnityEngine;
using UnityEngine.UI;

public class Char_slot : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _closedPanel;
    [SerializeField] private GameObject _NotEnoughGoldPanel;

    [Space]
    [Header("UI elements")]
    [SerializeField] private Image _heroIcon;
    [SerializeField] private Text _heroRank_text;
    [SerializeField] private Text _heroLevel_text;
    [SerializeField] private Text _heroGoldProfit_text;
    [SerializeField] private Text _heroGoldToLevelUp_text;
    [Space]
    public Hero m_CurrentHero;
    public bool m_IsEmpty { get; set; } = true;

        
    public void DisplayHeroInfirmation() // переписать ранк на куб
    {
        m_CurrentHero.Initialise();
        _heroIcon.sprite = m_CurrentHero.Icon;
        _heroRank_text.text = m_CurrentHero.Rank.ToString();
        _heroLevel_text.text = m_CurrentHero.Level.ToString();
        _heroGoldProfit_text.text = ConvertText.FormatNumb(m_CurrentHero.GetGoldProfit());
        _heroGoldToLevelUp_text.text = ConvertText.FormatNumb(m_CurrentHero.GoldToGrade);

        if (m_CurrentHero.isOpened)
            OpenHero();
        else
            CloseHero();
        if (Gold.GetCurrentGold() >= m_CurrentHero.GoldToGrade)
            _NotEnoughGoldPanel.SetActive(false);
        else
            _NotEnoughGoldPanel.SetActive(true);
    }

    private void OnEnable()
    {
        DisplayHeroInfirmation();
    }
    public void UpgradeHero()
    {

        if (Gold.GetCurrentGold() >= m_CurrentHero.GoldToGrade)
        {
            Gold.SpendGold(m_CurrentHero.GoldToGrade);
            m_CurrentHero.LevelUp();

            //    DisplayHeroInfirmation();
            GlovalEventSystem.HeroUpgrade(m_CurrentHero);
            SoundControl._instance.UpgradeHero();
        }
        else
        {
            SoundControl._instance.NoMoney();
        }
    }
    public void OpenStats() => GlovalEventSystem.OpenHeroStats(m_CurrentHero);
   
    public void OpenHero()
    {
        _closedPanel.SetActive(false);
    }
    public void CloseHero()
    {
        _closedPanel.SetActive(true);
    }
}
