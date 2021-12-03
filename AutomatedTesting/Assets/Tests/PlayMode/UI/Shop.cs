using System.Collections;
using System.Collections.Generic;
using Knights;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class Shop
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
        public void OneTimeSetup()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }
        [UnityTest]
        public IEnumerator BuyCoinsTest()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator BuyDiamondsTest()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator BuyBoostsTest()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator BuyHeadStartTest()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator BuyMysteryBoxesTest()
        {
            // Before Click Test
            GameObject shopButton = CustomID.testingInstance.GetGameObject(shopButtonID);
            Assert.IsNotNull(shopButton);
            string actualText = shopButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(shopButtonText, actualText);

            // OnClick Test
            automation.Click(shopButton);
            yield return seconds;
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(mainMenuPanelAfterClick);
            GameObject shopPanelAfterClick = CustomID.testingInstance.GetGameObject(shopPanelID);
            Assert.IsNotNull(shopPanelAfterClick);

            GameObject mysteryBoxButton = CustomID.testingInstance.GetGameObject(openMysteryBoxButtonID);
            Assert.IsNotNull(mysteryBoxButton);
            automation.Click(mysteryBoxButton);
            yield return seconds;

            // Get Mystery Box Button
            GameObject openMysteryBoxButton = CustomID.testingInstance.GetGameObject(openMysteryBoxButtonID1);
            Assert.IsNotNull(openMysteryBoxButton);
            GameObject tapToReturnButton = CustomID.testingInstance.GetGameObject(tapToReturnButtonID);
            Assert.IsNull(tapToReturnButton);

            // Click Open Mystery Box Button
            automation.Click(openMysteryBoxButton);
            yield return seconds;
            GameObject tapToReturnButton1 = CustomID.testingInstance.GetGameObject(tapToReturnButtonID);
            Assert.IsNotNull(tapToReturnButton1);

            // Click TapToReturn
            automation.Click(tapToReturnButton1);
            yield return seconds;
            GameObject mysteryBoxPopUp1 = CustomID.testingInstance.GetGameObject(mysteryBoxPopUpID);
            Assert.IsNull(mysteryBoxPopUp1);

        }

        [UnityTest]
        public IEnumerator OpenMysteryBoxTest()
        {
            yield return null;
        }

        // Must Run at the end
        [UnityTest]
        public IEnumerator Z_BackButtonTest()
        {
            GameObject shopBackButton = CustomID.testingInstance.GetGameObject(shopBackButtonID);
            Assert.IsNotNull(shopBackButton);

            GameObject shopPanel = CustomID.testingInstance.GetGameObject(shopPanelID);
            GameObject mainMenuPanel = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(shopPanel);
            Assert.IsNull(mainMenuPanel);

            automation.Click(shopBackButton);
            yield return seconds;

            GameObject shopPanel1 = CustomID.testingInstance.GetGameObject(shopPanelID);
            GameObject mainMenuPanel1 = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(shopPanel1);
            Assert.IsNotNull(mainMenuPanel1);

        }
    }
}
