using System.Collections;
using Knights;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class Cars
    {
        WaitForSeconds seconds = new WaitForSeconds(1);
        string sceneName = "MainMenu";
        AutomationTool automation;

        string carsSelectButtonID = "carsSelectButton";
        string carsSelectButtonText = "Select";
        string carsBuyButtonID = "carsBuyButton";
        string carsBackButtonID = "carsBackButton";
        string carsButtonID = "carsButton";
        string attemptedPurchaseID = "AttemptedPurchase";
        string attemptedNoButtonID = "AttemptedNo";
        string attemptedYesButtonID = "attemptedYesButton";

        string carsPanelID = "carsPanel";
        string mainMenuPanelID = "mainMenu";

        // Cars PlayerPrefs
        string ModularPlayerPref = "MODULAR";
        string DynamoPlayerPref = "DYNAMO";
        string AlloyPlayerPref = "ALLOY";
        string TazionPlayerPref = "TAZION";

        [OneTimeSetUp]
        public void OneSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        [UnityTest]
        public IEnumerator BuyButtonTest()
        {
            // Click the cars button
            GameObject carsButton = CustomID.testingInstance.GetGameObject(carsButtonID);
            Assert.IsNotNull(carsButton);
            automation.Click(carsButton);
            yield return seconds;
            GameObject carPanel = CustomID.testingInstance.GetGameObject(carsPanelID);
            Assert.IsNotNull(carPanel);

            // Click the cars buy button
            GameObject carBuyButton = CustomID.testingInstance.GetGameObject(carsBuyButtonID);
            Assert.IsNotNull(carBuyButton);
            automation.Click(carBuyButton);
            yield return seconds;
            GameObject attemptedPurchasePopup = CustomID.testingInstance.GetGameObject(attemptedPurchaseID);
            Assert.IsNotNull(attemptedPurchasePopup);

            // Click the NO button
            GameObject attemptedNoButton = CustomID.testingInstance.GetGameObject(attemptedNoButtonID);
            Assert.IsNotNull(attemptedNoButton);
            automation.Click(attemptedNoButton);
            yield return seconds;
            GameObject attemptedPurchasePopup1 = CustomID.testingInstance.GetGameObject(attemptedPurchaseID);
            Assert.IsNull(attemptedPurchasePopup1);

            // Click the buy button again
            GameObject carBuyButton1 = CustomID.testingInstance.GetGameObject(carsBuyButtonID);
            Assert.IsNotNull(carBuyButton1);
            automation.Click(carBuyButton1);
            yield return seconds;
            GameObject attemptedPurchasePopup2 = CustomID.testingInstance.GetGameObject(attemptedPurchaseID);
            Assert.IsNotNull(attemptedPurchasePopup2);

            // Click YES button
            GameObject attemptedYesButton = CustomID.testingInstance.GetGameObject(attemptedYesButtonID);
            Assert.IsNotNull(attemptedYesButton);
            automation.Click(attemptedYesButton);
            yield return seconds;
            GameObject attemptedPurchasePopup3 = CustomID.testingInstance.GetGameObject(attemptedPurchaseID);
            Assert.IsNull(attemptedPurchasePopup3);
            // Assert in future
            Assert.AreEqual(1, PlayerPrefs.GetInt(ModularPlayerPref));
        }

        [UnityTest]
        public IEnumerator SelectButtonTest()
        {
            GameObject carSelectButton = CustomID.testingInstance.GetGameObject(carsSelectButtonID);
            Assert.IsNotNull(carSelectButton);
            Assert.AreEqual(carsSelectButtonText, carSelectButton.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            yield return null;
            // Assert in future
        }

        // Must Run at the end
        [UnityTest]
        public IEnumerator Z_BackButtonTest()
        {
            GameObject carsBackButton = CustomID.testingInstance.GetGameObject(carsBackButtonID);
            Assert.IsNotNull(carsBackButton);
            automation.Click(carsBackButton);
            yield return seconds;
            GameObject mainMenu = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenu);
        }
    }
}
