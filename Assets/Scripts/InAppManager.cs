using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace InAppManager
{
    public class InAppManager : MonoBehaviour, IStoreListener
    {
        private static IStoreController m_StoreController;
        private static IExtensionProvider m_StoreExtensionProvider;

        public const string pCrystal1 = "2500crystal_game";
        public const string pCrystal2 = "7500crystal_game";
        public const string pCrystal3 = "20000crystal_game";        
        public const string pGold1 = "2_5gold_game";
        public const string pGold2 = "10_0gold_game";
        public const string pGold3 = "150_0gold_game";
        public const string pPremium = "premium1_game";


        public const string pCrystal1AppStore = "2500crystal_game";
        public const string pCrystal2AppStore = "7500crystal_game";
        public const string pCrystal3AppStore = "20000crystal_game";
        public const string pGold1AppStore = "2_5gold_game";
        public const string pGold2AppStore = "10_0gold_game";
        public const string pGold3AppStore = "150_0gold_game";
        public const string pPremiumAppStore = "premium1_game";

        public const string pCrystal1GooglePlay = "2500crystal_game";
        public const string pCrystal2GooglePlay = "7500crystal_game";
        public const string pCrystal3GooglePlay = "20000crystal_game";
        public const string pGold1GooglePlay = "2_5gold_game";
        public const string pGold2GooglePlay = "10_0gold_game";
        public const string pGold3GooglePlay = "150_0gold_game";
        public const string pPremiumGooglePlay = "premium1_game";
        public string test = "premium1_game";

        [SerializeField] BonusShop _bs;
        [SerializeField] MoneyInShop _mis;

        void Start()
        {
            if (m_StoreController == null)
            {
                InitializePurchasing();
            }
        }

        public void InitializePurchasing()
        {
            if (IsInitialized())
            {
                return;
            }

            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct(pCrystal1, ProductType.Consumable, new IDs() { { pCrystal1AppStore, AppleAppStore.Name }, { pCrystal1GooglePlay, GooglePlay.Name } });
            builder.AddProduct(pCrystal2, ProductType.Consumable, new IDs() { { pCrystal2AppStore, AppleAppStore.Name }, { pCrystal2GooglePlay, GooglePlay.Name } });
            builder.AddProduct(pCrystal3, ProductType.Consumable, new IDs() { { pCrystal3AppStore, AppleAppStore.Name }, { pCrystal3GooglePlay, GooglePlay.Name } });
            builder.AddProduct(pGold1, ProductType.Consumable, new IDs() { { pGold1AppStore, AppleAppStore.Name }, { pGold1GooglePlay, GooglePlay.Name } });
            builder.AddProduct(pGold2, ProductType.Consumable, new IDs() { { pGold2AppStore, AppleAppStore.Name }, { pGold2GooglePlay, GooglePlay.Name } });
            builder.AddProduct(pGold3, ProductType.Consumable, new IDs() { { pGold3AppStore, AppleAppStore.Name }, { pGold3GooglePlay, GooglePlay.Name } });
            builder.AddProduct(pPremium, ProductType.Consumable, new IDs() { { pPremiumAppStore, AppleAppStore.Name }, { pPremiumGooglePlay, GooglePlay.Name } });


            UnityPurchasing.Initialize(this, builder);
        }

        private bool IsInitialized()
        {
            return m_StoreController != null && m_StoreExtensionProvider != null;
        }

        public void BuyProductID(string productId)
        {
            try
            {
                if (IsInitialized())
                {
                    Product product = m_StoreController.products.WithID(productId);

                    if (product != null && product.availableToPurchase)
                    {
                        Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
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
            catch (Exception e)
            {
                Debug.Log("BuyProductID: FAIL. Exception during purchase. " + e);
            }
        }

        public void RestorePurchases()
        {
            if (!IsInitialized())
            {
                Debug.Log("RestorePurchases FAIL. Not initialized.");
                return;
            }

            if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
            {
                Debug.Log("RestorePurchases started ...");

                var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
                apple.RestoreTransactions((result) =>
                {
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
            Debug.Log("OnInitialized: Completed!");

            m_StoreController = controller;
            m_StoreExtensionProvider = extensions;
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            if (String.Equals(args.purchasedProduct.definition.id, pCrystal1, StringComparison.Ordinal))
            {
                _mis.BuyGem1();
            }
            else if (String.Equals(args.purchasedProduct.definition.id, pCrystal2, StringComparison.Ordinal))
            {
                _mis.BuyGem2();
            }
            else if (String.Equals(args.purchasedProduct.definition.id, pCrystal3, StringComparison.Ordinal))
            {
                _mis.BuyGem3();
            }
            else if (String.Equals(args.purchasedProduct.definition.id, pGold1, StringComparison.Ordinal))
            {
                _mis.BuyGold1();
            }
            else if (String.Equals(args.purchasedProduct.definition.id, pGold2, StringComparison.Ordinal))
            {
                _mis.BuyGold2();
            }
            else if (String.Equals(args.purchasedProduct.definition.id, pGold3, StringComparison.Ordinal))
            {
                _mis.BuyGold3();
            }
            else if (String.Equals(args.purchasedProduct.definition.id, pPremium, StringComparison.Ordinal))
            {
                _bs.BuyPremium();
            }

            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }
    }
}