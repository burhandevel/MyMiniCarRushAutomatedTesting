using Knights;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class Characters
    {
        WaitForSeconds seconds = new WaitForSeconds(1);
        string sceneName = "MainMenu";
        AutomationTool automation;

        string charactersButtonID = "charactersButton";
        string characterBuyButtonID = "charactersBuyButton";
        string attemptedPurchaseID = "AttemptedPurchase";
        string attemptedNoButtonID = "AttemptedNo";
        string attemptedYesButtonID = "attemptedYesButton";

        string characterPanelID = "characterPanel";

        // Characters PlayerPrefs
        string AriPlayerPref = "ARI";
        string ZadePlayerPref = "ZADE";

        [OneTimeSetUp]
        public void OneSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        [UnityTest]
        public IEnumerator BuyButtonTest()
        {
            // Click the Characters button
            GameObject charactersButton = CustomID.testingInstance.GetGameObject(charactersButtonID);
            Assert.IsNotNull(charactersButton);
            automation.Click(charactersButton);
            yield return seconds;
            GameObject characterPanel = CustomID.testingInstance.GetGameObject(characterPanelID);
            Assert.IsNotNull(characterPanel);

            // Click the Characters buy button
            GameObject characterBuyButton = CustomID.testingInstance.GetGameObject(characterBuyButtonID);
            Assert.IsNotNull(characterBuyButton);
            automation.Click(characterBuyButton);
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
            GameObject characterBuyButton1 = CustomID.testingInstance.GetGameObject(characterBuyButtonID);
            Assert.IsNotNull(characterBuyButton1);
            automation.Click(characterBuyButton1);
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
        }

        [UnityTest]
        public IEnumerator SelectButtonTest()
        {
            yield return null;
        }


        // Must run at the end
        [UnityTest]
        public IEnumerator Z_BackButtonTest()
        {
            yield return null;
        }
    }
}
