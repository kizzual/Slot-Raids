using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;
using TMPro;

public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager instance;

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    //Step 1 create your products
    private string coins_10m = "10m_coins"; 
    private string coins_100m = "100m_coins";  
    private string bottles_10 = "10_bottles"; 
    private string bottles_50 = "50_bottles";  
    private string Combo = "100m_50_bottles";
    // secondary link bn
    [SerializeField] private ShopIAP shopIAP;
    [SerializeField] private Boost_Controll Boost_Controll;

    public ParticleSystem gold_10m;
    public ParticleSystem gold_100m;
    public ParticleSystem bottle_10b;
    public ParticleSystem bottle_50b;
    public ParticleSystem combo_bottle;
    public ParticleSystem combo_gold;

    public TextMeshProUGUI green;
    public TextMeshProUGUI blue;
    public TextMeshProUGUI yellow;
    public TextMeshProUGUI red;

    public GameObject Bottle_green;
    public GameObject Bottle_blue;
    public GameObject Bottle_yellow;
    public GameObject Bottle_red;

    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Step 2 choose if your product is a consumable or non consumable
        builder.AddProduct(coins_10m, ProductType.Consumable);
        builder.AddProduct(coins_100m, ProductType.Consumable);
        builder.AddProduct(bottles_10, ProductType.Consumable);
        builder.AddProduct(bottles_50, ProductType.Consumable);
        builder.AddProduct(Combo, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    //Step 3 Create methods
    public void Buy10mCoins() => BuyProductID(coins_10m);
    public void Buy100mCoins() => BuyProductID(coins_100m);
    public void Buy10bottles() => BuyProductID(bottles_10);
    public void Buy50bottles() => BuyProductID(bottles_50);
    public void BuyCombo() => BuyProductID(Combo);




    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, coins_10m, StringComparison.Ordinal))
        {
            Debug.Log(" START Buy coins_10m ");
            gold_10m.GetComponent<ParticleAdaptive>().Initialise();
            try
            {
                Gold.AddGold(10000000);
                Debug.Log(" Gold Added");
            }
            catch
            {
                Debug.Log("Gold not added");
            }
            try
            {
                if (gold_10m != null)
                {
                    gold_10m.Play();
                    Debug.Log(" gold_10m played");
                }
                else
                {
                    Debug.Log("gold_10m not found");
                }
            }
            catch
            {
                Debug.Log("gold_10m not played");
            }
            try
            {
                SoundControl._instance.PlayCash();
            }
            catch { }

            Debug.Log(" coins_10m Succesful");
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coins_100m, StringComparison.Ordinal))
        {
            Debug.Log("START coins_100m ");
            try
            {
                Gold.AddGold(100000000);
                Debug.Log(" Gold Added");
            }
            catch
            {
                Debug.Log("Gold not added");
            }
            try
            {
                if (gold_100m != null)
                {
                    gold_100m.Play();
                    Debug.Log(" gold_100m played");
                }
                else
                {
                    Debug.Log("gold_100m not found");
                }
            }
            catch
            {
                Debug.Log("gold_100m not played");
            }

            SoundControl._instance.PlayCash();
            Debug.Log("coins_100m Succesful");
        }
        else if (String.Equals(args.purchasedProduct.definition.id, bottles_10, StringComparison.Ordinal))
        {
            Debug.Log("START bottles_10 ");
            try
            {
                Boost_Controll.AddBottles(10);
                Debug.Log(" bottle Added");
            }
            catch
            {
                Debug.Log("bottle not added");
            }
            try
            {
                if (bottle_10b != null)
                {
                    bottle_10b.Play();
                    Debug.Log(" bottle_10b played");
                }
                else
                {
                    Debug.Log("bottle_10b not found");
                }
            }
            catch
            {
                Debug.Log("bottle_10b not played");
            }
            DisplayBottleInfo();

            SoundControl._instance.PlayCash();
            Debug.Log("bottles_10 Succesful (IAP)");
        }
        else if (String.Equals(args.purchasedProduct.definition.id, bottles_50, StringComparison.Ordinal))
        {
            Debug.Log("START bottles_50 ");

            try
            {
                Boost_Controll.AddBottles(50);
                Debug.Log(" bottle Added");
            }
            catch
            {
                Debug.Log("bottle not added");
            }
            try
            {
                if (bottle_50b != null)
                {
                    bottle_50b.Play();
                    Debug.Log(" bottle_50b played");
                }
                else
                {
                    Debug.Log("bottle_50b not found");
                }
            }
            catch
            {
                Debug.Log("bottle_50b not played");
            }
            DisplayBottleInfo();

            SoundControl._instance.PlayCash();
            Debug.Log("bottles_50 Succesful");
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Combo, StringComparison.Ordinal))
        {
            Debug.Log("START Combo ");

            try
            {
                Gold.AddGold(100000000);
                Debug.Log(" Gold Added");
            }
            catch
            {
                Debug.Log("Gold not added");
            }
            try
            {
                if (combo_gold != null)
                {
                    combo_gold.Play();
                    Debug.Log(" combo_gold played");
                }
                else
                {
                    Debug.Log("combo_gold not found");
                }
            }
            catch
            {
                Debug.Log("combo_gold not played");
            }

            try
            {
                Boost_Controll.AddBottles(50);
                Debug.Log(" bottle Added");
            }
            catch
            {
                Debug.Log("bottle not added");
            }
            try
            {
                if (combo_bottle != null)
                {
                    combo_bottle.Play();
                    Debug.Log(" combo_bottle played");
                }
                else
                {
                    Debug.Log("combo_bottle not found");
                }
            }
            catch
            {
                Debug.Log("combo_bottle not played");
            }
            DisplayBottleInfo();
            SoundControl._instance.PlayCash();

            Debug.Log("Combo Succesful");
        }
        else
        {
            Debug.Log("Purchase Failed");
        }

        Debug.Log("PurchaseProcessingResult.Complete");
        return PurchaseProcessingResult.Complete;
    }
    private void DisplayBottleInfo()
    {
        // text
        try
        {
            if (green != null)
            {
                green.text = Boost_Controll.getBottlesCount().ToString();
            }
            else
            {
                Debug.Log("green  = NULL (IAP)");
            }
        }
        catch
        {
            Debug.Log("bottles_count_green  NOT displayed (IAP)");
        }
        try
        {
            if (blue != null)
            {
                blue.text = Boost_Controll.getBottlesCount().ToString();
            }
            else
            {
                Debug.Log("blue  = NULL (IAP)");
            }
        }
        catch
        {
            Debug.Log("bottles_count blue  NOT displayed (IAP)");
        }
        try
        {
            if (yellow != null)
            {
                yellow.text = Boost_Controll.getBottlesCount().ToString();
            }
            else
            {
                Debug.Log("yellow  = NULL (IAP)");
            }
        }
        catch
        {
            Debug.Log("bottles_count_yellow  NOT displayed (IAP)");
        }
        try
        {
            if (red != null)
            {
                red.text = Boost_Controll.getBottlesCount().ToString();
            }
            else
            {
                Debug.Log("red  = NULL (IAP)");
            }
        }
        catch
        {
            Debug.Log("bottles_count_red  NOT displayed (IAP)");
        }

        // image

        try
        {
            if (Boost_Controll.getBottlesCount() > 0)
            {
                try
                {
                    if(Bottle_green != null)
                    {
                        Bottle_green.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Bottle_green image NULL");
                    }
                }
                catch
                {
                    Debug.Log("Bottle_green  NOT DISPLAYED");
                }
                try
                {
                    if (Bottle_blue != null)
                    {
                        Bottle_blue.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Bottle_blue image NULL");
                    }
                }
                catch
                {
                    Debug.Log("Bottle_blue  NOT DISPLAYED");
                }
                try
                {
                    if (Bottle_yellow != null)
                    {
                        Bottle_yellow.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Bottle_yellow image NULL");
                    }
                }
                catch
                {
                    Debug.Log("Bottle_yellow  NOT DISPLAYED");
                }
                try
                {
                    if (Bottle_red != null)
                    {
                        Bottle_red.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Bottle_red image NULL");
                    }
                }
                catch
                {
                    Debug.Log("Bottle_red  NOT DISPLAYED");
                }

            }
            else
            {
                try
                {
                    if (Bottle_green != null)
                    {
                        Bottle_green.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Bottle_green image NULL");
                    }
                }
                catch
                {
                    Debug.Log("Bottle_green  NOT DISPLAYED");
                }
                try
                {
                    if (Bottle_blue != null)
                    {
                        Bottle_blue.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Bottle_blue image NULL");
                    }
                }
                catch
                {
                    Debug.Log("Bottle_blue  NOT DISPLAYED");
                }
                try
                {
                    if (Bottle_yellow != null)
                    {
                        Bottle_yellow.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Bottle_yellow image NULL");
                    }
                }
                catch
                {
                    Debug.Log("Bottle_yellow  NOT DISPLAYED");
                }
                try
                {
                    if (Bottle_red != null)
                    {
                        Bottle_red.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Bottle_red image NULL");
                    }
                }
                catch
                {
                    Debug.Log("Bottle_red  NOT DISPLAYED");
                }

            }
            Debug.Log("Image diplayed (boost control)");
        }
        catch
        {
            Debug.Log("Image NOT diplayed (boost control)");
        }
    }
    private void EventSender(PurchaseEventArgs args)
    {
        if (!PlayerPrefs.HasKey("FirstPurchaseEvent"))
        {
            PlayerPrefs.SetInt("FirstPurchaseEvent", 1);
            ApsFlyerEvents.FirstPurchase_event(args);
        }
        ApsFlyerEvents.Purchase_event(args);
        
    }
    #region Tests
    public void Test()
    {
        try
        {
            Gold.AddGold(100000000);
            Debug.Log(" Gold Added");
        }
        catch
        {
            Debug.Log("Gold not added");
        }
        try
        {
            if (gold_100m != null)
            {
                gold_100m.Play();
                Debug.Log(" gold_100m played");
            }
            else
            {
                Debug.Log("gold_100m not found");
            }
        }
        catch
        {
            Debug.Log("gold_100m not played");
        }

        SoundControl._instance.PlayCash();


        Debug.Log("coins_100m Succesful");
    }
    public void Test2()
    {
        Debug.Log("START bottles_50 ");

        try
        {
            Boost_Controll.AddBottles(50);
            Debug.Log(" bottle Added");
        }
        catch
        {
            Debug.Log("bottle not added");
        }
        try
        {
            if (bottle_50b != null)
            {
                bottle_50b.Play();
                Debug.Log(" bottle_50b played");
            }
            else
            {
                Debug.Log("bottle_50b not found");
            }
        }
        catch
        {
            Debug.Log("bottle_50b not played");
        }
        DisplayBottleInfo();
        SoundControl._instance.PlayCash();
        Debug.Log("bottles_50 Succesful");
    }



    public ReceiptData GetReceiptData(PurchaseEventArgs e)

    {
        ReceiptData data = new ReceiptData();

        if (e != null)
        {
            //Main receipt root
            string receiptString = e.purchasedProduct.receipt;
            Debug.Log("receiptString " + receiptString);
            var receiptDict = (Dictionary<string, object>)MiniJson.JsonDecode(receiptString);
            Debug.Log("receiptDict COUNT" + receiptDict.Count);

            //Next level Paylod dict
            string payloadString = (string)receiptDict["Payload"];
            Debug.Log("payloadString " + payloadString);
            var payloadDict = (Dictionary<string, object>)MiniJson.JsonDecode(payloadString);

            //Stuff from json object
            string jsonString = (string)payloadDict["json"];    
            Debug.Log("jsonString " + jsonString);
            var jsonDict = (Dictionary<string, object>)MiniJson.JsonDecode(jsonString);
            string orderIdString = (string)jsonDict["orderId"];
            Debug.Log("orderIdString " + orderIdString);
            string packageNameString = (string)jsonDict["packageName"];
            Debug.Log("packageNameString " + packageNameString);
            string productIdString = (string)jsonDict["productId"];
            Debug.Log("productIdString " + productIdString);

            double orderDateDouble = Convert.ToDouble(jsonDict["purchaseTime"]);
            Debug.Log("orderDateDouble " + orderDateDouble);

            string purchaseTokenString = (string)jsonDict["purchaseToken"];
            Debug.Log("purchaseTokenString " + purchaseTokenString);

            //Stuff from skuDetails object
            string skuDetailsString = (string)payloadDict["skuDetails"];
            Debug.Log("skuDetailsString " + skuDetailsString);
            var skuDetailsDict = (Dictionary<string, object>)MiniJson.JsonDecode(skuDetailsString);
            long priceAmountMicrosLong = Convert.ToInt64(skuDetailsDict["price_amount_micros"]);
            Debug.Log("priceAmountMicrosLong " + priceAmountMicrosLong);
            string priceCurrencyCodeString = (string)skuDetailsDict["price_currency_code"];
            Debug.Log("priceCurrencyCodeString " + priceCurrencyCodeString);

            //Creating UTC from Epox
            DateTime orderDateTemp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            orderDateTemp = orderDateTemp.AddMilliseconds(orderDateDouble);

            data.orderId = orderIdString;
            data.packageName = packageNameString;
            data.productId = productIdString;   //sku
            data.purchaseToken = purchaseTokenString;
            data.priceAmountMicros = priceAmountMicrosLong;
            data.priceCurrencyCode = priceCurrencyCodeString;
            data.orderDate = orderDateTemp;
            data.receipt = receiptString;
            Debug.Log("GetReceiptData succesfull");
        }
        else
        {
            Debug.Log("PurchaseEventArgs is NULL");
        }

        return data;
    }
   
    private void Test(PurchaseEventArgs e)
    {
        var gpDetails = JObject.Parse(e.purchasedProduct.receipt);
        gpDetails["Payload"] = JObject.Parse((string)gpDetails["Payload"]);
        gpDetails["Payload"]["json"] = JObject.Parse((string)gpDetails["Payload"]["json"]);

        var gpSign = (string)gpDetails["Payload"]["signature"]; 

        Debug.Log(gpSign + " sign");
    }

    #endregion


    //**************************** Dont worry about these methods ***********************************
    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(3f);
        if (m_StoreController == null) { InitializePurchasing(); }
    }
    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }


}
public class ReceiptData
{
    public string orderId;
    public string packageName;
    public string productId;
    public string purchaseToken;
    public long priceAmountMicros;
    public string priceCurrencyCode;
    public DateTime orderDate;
    public string receipt;
}
