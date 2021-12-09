using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Knights;

namespace Tests
{
    public class InventoryTests
    {
        AutomationTool automation;
        string sceneName = "MainMenu";
        WaitForSeconds seconds = new WaitForSeconds(1);
        string openMysteryBoxButtonID = "mysteryBoxBtn";
        string openMysteryBoxButtonID1 = "openMysteryBoxButton";
        string tapToReturnButtonID = "tapToReturnButton";
        string shopButtonID = "shopButton";
        string shopButtonText = "SHOP";
        string mysteryBoxPopUpID = "mysteryBoxPopup";
        string mainMenuPanelID = "mainMenu";
        string shopPanelID = "shopPanel";
        string shopBackButtonID = "shopBackButton";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }
        
        [UnityTest]
        public IEnumerator BuyCoinsTest()
        {
            
            yield return null;
        }
    }
}
