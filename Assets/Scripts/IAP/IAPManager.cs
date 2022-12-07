using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;

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
    // secondary link
    [SerializeField] private ShopIAP shopIAP;



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
            Debug.Log("coins_10m Succesful");
            ReceiptData receipt = GetReceiptData(args);
            if(!PlayerPrefs.HasKey("FirstPurchaseEvent"))
            {
                PlayerPrefs.SetInt("FirstPurchaseEvent", 1);
                ApsFlyerEvents.FirstPurchase_event(args);
            }
            ApsFlyerEvents.Purchase_event(args, receipt);
            shopIAP.SuccessBuy10m();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coins_100m, StringComparison.Ordinal))
        {
            Debug.Log("coins_100m Succesful");
            ReceiptData receipt = GetReceiptData(args);
            if (!PlayerPrefs.HasKey("FirstPurchaseEvent"))
            {
                PlayerPrefs.SetInt("FirstPurchaseEvent", 1);
                ApsFlyerEvents.FirstPurchase_event(args);
            }
            ApsFlyerEvents.Purchase_event(args, receipt);
            shopIAP.SuccessBuy100m();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, bottles_10, StringComparison.Ordinal))
        {
            Debug.Log("bottles_10 Succesful");
            ReceiptData receipt = GetReceiptData(args);
            if (!PlayerPrefs.HasKey("FirstPurchaseEvent"))
            {
                PlayerPrefs.SetInt("FirstPurchaseEvent", 1);
                ApsFlyerEvents.FirstPurchase_event(args);
            }
            ApsFlyerEvents.Purchase_event(args, receipt);
            shopIAP.SuccessBuy10b();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, bottles_50, StringComparison.Ordinal))
        {
            Debug.Log("bottles_50 Succesful");
            ReceiptData receipt = GetReceiptData(args);
            if (!PlayerPrefs.HasKey("FirstPurchaseEvent"))
            {
                PlayerPrefs.SetInt("FirstPurchaseEvent", 1);
                ApsFlyerEvents.FirstPurchase_event(args);
            }
            ApsFlyerEvents.Purchase_event(args, receipt);
            shopIAP.SuccessBuy50b();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Combo, StringComparison.Ordinal))
        {
            Debug.Log("Combo Succesful");
            ReceiptData receipt = GetReceiptData(args);
            if (!PlayerPrefs.HasKey("FirstPurchaseEvent"))
            {
                PlayerPrefs.SetInt("FirstPurchaseEvent", 1);
                ApsFlyerEvents.FirstPurchase_event(args);
            }
            ApsFlyerEvents.Purchase_event(args, receipt);
            shopIAP.SuccessBuyCombo();
        }
        else
        {
            Debug.Log("Purchase Failed");
        }
        return PurchaseProcessingResult.Complete;
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



    //**************************** Dont worry about these methods ***********************************
    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
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
