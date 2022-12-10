using AppsFlyerSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class ApsFlyerEvents : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void Purchase_event(PurchaseEventArgs args)//, ReceiptData receipt)
    {
        Dictionary<string, string> purchaseEvent = new Dictionary<string, string>();
        Debug.Log("SKU =  " + args.purchasedProduct.definition.id + "    TRANSACTION_ID =   " + args.purchasedProduct.transactionID);
        purchaseEvent.Add(AFInAppEvents.CURRENCY, args.purchasedProduct.metadata.isoCurrencyCode);
        purchaseEvent.Add(AFInAppEvents.REVENUE, args.purchasedProduct.metadata.localizedPrice.ToString());
        purchaseEvent.Add("product_id", args.purchasedProduct.definition.id);
        purchaseEvent.Add("SKU", args.purchasedProduct.definition.id);
        purchaseEvent.Add("TRANSACTION_ID", args.purchasedProduct.transactionID);
        AppsFlyer.sendEvent("af_purchase", purchaseEvent);
    }
    public static void FirstPurchase_event(PurchaseEventArgs args)
    {
        Dictionary<string, string> uniquepuEvent = new Dictionary<string, string>();
        uniquepuEvent.Add("product_id", args.purchasedProduct.definition.id);
        AppsFlyer.sendEvent("unique_pu", uniquepuEvent);
    }

    public static void ADS_rewarded_event(string rewardName)
    {
        Debug.Log("Events 'ADS_rewarded_event' sended with parametrs:  rewardName = " + rewardName);
        Dictionary<string, string> rvfinishEvent = new Dictionary<string, string>();
        rvfinishEvent.Add("placement", rewardName);
        AppsFlyer.sendEvent("rv_finish", rvfinishEvent);
    }

    public static void Level_event(string lvl_name, int id)
    {
        Debug.Log("Events 'Level_event' sended with parametrs:  lvl_name = " + lvl_name + "  *id = " + id);
        Dictionary<string, string> levelEvent = new Dictionary<string, string>();
        levelEvent.Add("level_number", id.ToString());
        levelEvent.Add("level_name", lvl_name);
        AppsFlyer.sendEvent("level", levelEvent);
    }

    public static void Quest_event(string status, int id, string block_name)
    {
        Debug.Log("Events 'Quest_event' sended with parametrs:  status = " + status + "  *id = " + id + "  *block_name = " + block_name);
        Dictionary<string, string> questEvent = new Dictionary<string, string>();
        questEvent.Add("status", status);
        questEvent.Add("quest_number", id.ToString());
        questEvent.Add("quest_name", id.ToString());
        questEvent.Add("quest_type", block_name);
        questEvent.Add("level_number", " - ");
        questEvent.Add("level_name", " - ");

        AppsFlyer.sendEvent("quest", questEvent);
    }
    public static void Tutorial_event(int step)
    {
        Debug.Log("Events 'Tutorial_event' sended with parametrs:  " + "  *step = " + step);
        Dictionary<string, string> tutorialEvent = new Dictionary<string, string>();
        tutorialEvent.Add("step", step.ToString());
        tutorialEvent.Add("step_name", step.ToString());
        AppsFlyer.sendEvent("tutorial", tutorialEvent);
    }

    public static void SoftTutorial_event(string tutorial_name, int step)
    {
        Debug.Log("Events 'SoftTutorial_event' sended with parametrs:  tutorial_name = " + tutorial_name + "  *step = " + step);

        Dictionary<string, string> softtutorialEvent = new Dictionary<string, string>();
        softtutorialEvent.Add("tutorial_name", tutorial_name);
        softtutorialEvent.Add("step", step.ToString());
        softtutorialEvent.Add("step_name", tutorial_name);
        AppsFlyer.sendEvent("soft_tutorial", softtutorialEvent);
    }

}
