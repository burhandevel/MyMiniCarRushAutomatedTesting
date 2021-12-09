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
        // Panel and button IDs
        string openMysteryBoxButtonID = "OpenMysteryBoxButton";
        string openMysteryBoxID = "OpenMysteryBox";
        string tapToReturnButtonID = "tapToReturnButton";
        string shopButtonID = "shopButton";
        string shopButtonText = "SHOP";
        string mysteryBoxPopUpID = "mysteryBoxPopup";
        string mainMenuPanelID = "mainMenu";
        string shopPanelID = "shopPanel";
        string shopBackButtonID = "shopBackButton";

        // Inventory related PlayerPrefs IDs in Unity
        string coinsPlayerPrefKey = "COINS";
        string diamondsPlayerPrefKey = "DIAMONDS";
        string MysteryBoxPlayerPrefKey = "MYSTERY_BOX";
        string BoostsPlayerPrefKey = "BOOSTS";
        string HeadStartPlayerPrefKey = "HEAD_START";

        // Inventory related numbers
        int coinsAmountToAdd = 100;
        int coinsCostInDiamonds = 10;

        int diamondsAmountToAdd = 200;

        int boostAmountToAdd = 50;
        int boostCostInCoins = 1000;

        int headStartAmountToAdd = 25;
        int headStartCostInCoins = 5;

        int mysteryBoxAmountToAdd = 10;
        int mysteryBoxCostInCoins = 20;

        // Inventory related ButtonsIDs
        string buyCoinsButtonID = "BuyCoinsButton";
        string buyDiamondsButtonID = "BuyDiamondsButton";
        string buyBoostButtonID = "BuyBoostButton";
        string buyHeadStartButtonID = "BuyHeadStartButton";
        string buyMysteryBoxButtonID = "BuyMysteryBoxButton";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        // Must Run at First
        [UnityTest]
        public IEnumerator A_BuyCoinsTest()
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

            // Check if Buy Coins button is active or not
            GameObject buyCoinsButton = CustomID.testingInstance.GetGameObject(buyCoinsButtonID);
            Assert.IsNotNull(buyCoinsButton);

            // Get the current coins Amount and Click the buyCoins Button
            int currentCoinsAmount = PlayerPrefs.GetInt(coinsPlayerPrefKey);
            int currentDiamondsAmount = PlayerPrefs.GetInt(diamondsPlayerPrefKey);
            automation.Click(buyCoinsButton);
            yield return seconds;
            Assert.AreEqual(currentDiamondsAmount - coinsCostInDiamonds, PlayerPrefs.GetInt(diamondsPlayerPrefKey));
            Assert.AreEqual(currentCoinsAmount + coinsAmountToAdd, PlayerPrefs.GetInt(coinsPlayerPrefKey));
            // Future Assert to compare PlayerPref with displayed Text
        }

        [UnityTest]
        public IEnumerator BuyDiamondsTest()
        {
            // Check if Buy Diamonds button is active or not
            GameObject buyDiamondsButton = CustomID.testingInstance.GetGameObject(buyDiamondsButtonID);
            Assert.IsNotNull(buyDiamondsButton);

            // Get the current diamonds Amount and Click the buyCoins Button
            int currentDiamondsAmount = PlayerPrefs.GetInt(diamondsPlayerPrefKey);
            automation.Click(buyDiamondsButton);
            yield return seconds;
            Assert.AreEqual(currentDiamondsAmount + diamondsAmountToAdd, PlayerPrefs.GetInt(diamondsPlayerPrefKey));
            // Future Assert to compare PlayerPref with displayed Text
        }

        [UnityTest]
        public IEnumerator BuyBoostsTest()
        {
            // Check if Buy Boosts button is active or not
            GameObject buyBoostButton = CustomID.testingInstance.GetGameObject(buyBoostButtonID);
            Assert.IsNotNull(buyBoostButton);

            // Get the current Boost Amount and Click the buyCoins Button
            int currentBoostAmount = PlayerPrefs.GetInt(BoostsPlayerPrefKey);
            int currentCoinsAmount = PlayerPrefs.GetInt(coinsPlayerPrefKey);
            automation.Click(buyBoostButton);
            yield return seconds;
            Assert.AreEqual(currentCoinsAmount - boostCostInCoins, PlayerPrefs.GetInt(coinsPlayerPrefKey));
            Assert.AreEqual(currentBoostAmount + boostAmountToAdd, PlayerPrefs.GetInt(BoostsPlayerPrefKey));
            
            // Future Assert to compare PlayerPref with displayed Text
        }

        [UnityTest]
        public IEnumerator BuyHeadStartTest()
        {
            // Check if Buy Head Start button is active or not
            GameObject buyHeadStartButton = CustomID.testingInstance.GetGameObject(buyHeadStartButtonID);
            Assert.IsNotNull(buyHeadStartButton);

            // Get the current Boost Amount and Click the buyCoins Button
            int currentHeadStartAmount = PlayerPrefs.GetInt(HeadStartPlayerPrefKey);
            int currentCoinsAmount = PlayerPrefs.GetInt(coinsPlayerPrefKey);
            automation.Click(buyHeadStartButton);
            yield return seconds;
            Assert.AreEqual(currentCoinsAmount - headStartCostInCoins, PlayerPrefs.GetInt(coinsPlayerPrefKey));
            Assert.AreEqual(currentHeadStartAmount + headStartAmountToAdd, PlayerPrefs.GetInt(HeadStartPlayerPrefKey));
            // Future Assert to compare PlayerPref with displayed Text
        }

        [UnityTest]
        public IEnumerator BuyMysteryBoxTest()
        {
            // Check if Buy Head Mystery Box button is active or not
            GameObject buyMysteryBoxButton = CustomID.testingInstance.GetGameObject(buyMysteryBoxButtonID);
            Assert.IsNotNull(buyMysteryBoxButton);

            // Get the current Boost Amount and Click the buyCoins Button
            int currentMysteryBoxAmount = PlayerPrefs.GetInt(MysteryBoxPlayerPrefKey);
            int currentCoinsAmount = PlayerPrefs.GetInt(coinsPlayerPrefKey);
            automation.Click(buyMysteryBoxButton);
            yield return seconds;
            Assert.AreEqual(currentCoinsAmount - mysteryBoxCostInCoins, PlayerPrefs.GetInt(coinsPlayerPrefKey));
            Assert.AreEqual(currentMysteryBoxAmount + mysteryBoxAmountToAdd, PlayerPrefs.GetInt(MysteryBoxPlayerPrefKey));
            // Future Assert to compare PlayerPref with displayed Text
        }

        [UnityTest]
        public IEnumerator OpenMysteryBoxTest()
        {
            // Check if Open Mystery Box Button is active or not
            GameObject openMysteryBoxButton = CustomID.testingInstance.GetGameObject(openMysteryBoxButtonID);
            Assert.IsNotNull(openMysteryBoxButton);

            // Click Open Mystery Box Button
            automation.Click(openMysteryBoxButton);
            yield return seconds;
            GameObject tapToReturnButton = CustomID.testingInstance.GetGameObject(tapToReturnButtonID);
            Assert.IsNull(tapToReturnButton);

            // Check if Open button is active or not and click the button
            GameObject openMysteryBox = CustomID.testingInstance.GetGameObject(openMysteryBoxID);
            Assert.IsNotNull(openMysteryBox);
            automation.Click(openMysteryBox);
            yield return seconds;
            GameObject tapToReturnButton1 = CustomID.testingInstance.GetGameObject(tapToReturnButtonID);
            Assert.IsNotNull(tapToReturnButton1);

            // Click TapToReturn
            automation.Click(tapToReturnButton1);
            yield return seconds;
            GameObject mysteryBoxPopUp1 = CustomID.testingInstance.GetGameObject(mysteryBoxPopUpID);
            Assert.IsNull(mysteryBoxPopUp1);

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
