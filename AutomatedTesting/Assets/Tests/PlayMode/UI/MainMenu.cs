using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Knights;

namespace Tests
{
    public class MainMenu
    {
        AutomationTool automation;
        float seconds = 1;
        // Scene Name
        string sceneName = "MainMenu";
        string gamePlaySceneName = "GamePlay";
        // Buttons and their respective texts
        string tapToPlayButtonID = "tapToPlay";
        string tapToPlayText = "Tap To Play";
        string settingButtonID = "settingButton";
        string settingButtonText = "";
        string carsButtonID = "carsButton";
        string carsButtonText = "CARS";
        string charactersButtonID = "charactersButton";
        string charactersButtonText = "CHARACTERS";
        string shopButtonID = "shopButton";
        string shopButtonText = "SHOP";
        string buyCurrencyButtonID = "buyCurrencyButton";
        string buyCurrencyButtonText = "";
        string buyBoostButtonID = "buyBoostButton";
        string buyBoostButtonText = "BUY BOOST";
        string leaderBoardButtonID = "leaderBoardButton";
        string leaderBoardButtonText = "LEADER BOARD";
        string goalsButtonID = "goalsButton";
        string goalsButtonText = "GOALS";
        string dailyBonusButtonID = "bonusButton";
        string dailyBonusButtonText = "DAILY BONUS";

        string settingsBackButtonID = "settingsBackButton";
        string goalsBackButtonID = "goalsBackButton";
        string leaderBoardBackButtonID = "leaderBoardBackButton";
        string carsBackButtonID = "carsBackButton";
        string charactersBackButtonID = "charactersBackButton";
        string shopBackButtonID = "shopBackButton";
        string openMysteryBoxButtonID = "openMysteryBoxButton";
        string tapToReturnButtonID = "tapToReturnButton";

        // Panels
        string mainMenuPanelID = "mainMenu";
        string settingPanelID = "settingPanel";
        string goalsPanelID = "goalsPanel";
        string leaderBoardPanelID = "leaderBoardPanel";
        string carsPanelID = "carsPanel";
        string characterPanelID = "characterPanel";
        string shopPanelID = "shopPanel";
        string mysteryBoxPopUpID = "mysteryBoxPopup";


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        [SetUp]
        public void SetUp()
        {
            
        }
        
        // Must Run at First
        [UnityTest]
        public IEnumerator A_MainMenuPanelTest()
        {
            GameObject mainMenuPanel = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            yield return null;
            Assert.IsNotNull(mainMenuPanel);
        }

        [UnityTest]
        public IEnumerator TapToPlayButtonTest()
        {
            GameObject tapToPlayButton = CustomID.testingInstance.GetGameObject(tapToPlayButtonID);
            Assert.IsNotNull(tapToPlayButton);
            string actualText = tapToPlayButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(tapToPlayText, actualText);

            automation.Click(tapToPlayButton);
            var time = Time.time;
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == gamePlaySceneName || Time.time > time + 10);
            Assert.AreEqual(gamePlaySceneName, SceneManager.GetActiveScene().name);
        }

        [UnityTest]
        public IEnumerator SettingButtonTest()
        {
            // Before Click Test
            GameObject settingButton = CustomID.testingInstance.GetGameObject(settingButtonID);
            Assert.IsNotNull(settingButton);
            string actualText = settingButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(settingButtonText, actualText);

            GameObject mainMenuPanelBeforeClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelBeforeClick);
            GameObject settingsPanelBeforeClick = CustomID.testingInstance.GetGameObject(settingPanelID);
            Assert.IsNull(settingsPanelBeforeClick);

            // OnClick Test
            automation.Click(settingButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(mainMenuPanelAfterClick);
            GameObject settingsPanelAfterClick = CustomID.testingInstance.GetGameObject(settingPanelID);
            Assert.IsNotNull(settingsPanelAfterClick);

            //On Clicking the back button
            GameObject settingBackButton = CustomID.testingInstance.GetGameObject(settingsBackButtonID);
            automation.Click(settingBackButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelOnBackButton = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelOnBackButton);
            GameObject settingsPanelOnBackButton = CustomID.testingInstance.GetGameObject(settingPanelID);
            Assert.IsNull(settingsPanelOnBackButton);

        }

        [UnityTest]
        public IEnumerator CarsButtonTest()
        {
            // Before Click Test
            GameObject carsButton = CustomID.testingInstance.GetGameObject(carsButtonID);
            Assert.IsNotNull(carsButton);
            string actualText = carsButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(carsButtonText, actualText);

            // OnClick Test
            automation.Click(carsButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(mainMenuPanelAfterClick);
            GameObject carsPanelAfterClick = CustomID.testingInstance.GetGameObject(carsPanelID);
            Assert.IsNotNull(carsPanelAfterClick);

            // On Clicking the back button in Cars Panel
            GameObject carsBackButton = CustomID.testingInstance.GetGameObject(carsBackButtonID);
            automation.Click(carsBackButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelOnBackButton = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelOnBackButton);
            GameObject carsPanelOnBackButton = CustomID.testingInstance.GetGameObject(carsPanelID);
            Assert.IsNull(carsPanelOnBackButton);
        }

        [UnityTest]
        public IEnumerator CharactersButtonTest()
        {
            // Before Click Test
            GameObject characterButton = CustomID.testingInstance.GetGameObject(charactersButtonID);
            Assert.IsNotNull(characterButton);
            string actualText = characterButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(charactersButtonText, actualText);

            // OnClick Test
            automation.Click(characterButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(mainMenuPanelAfterClick);
            GameObject charactersPanelAfterClick = CustomID.testingInstance.GetGameObject(characterPanelID);
            Assert.IsNotNull(charactersPanelAfterClick);

            // On Clicking the back button in characters Panel
            GameObject charactersBackButton = CustomID.testingInstance.GetGameObject(charactersBackButtonID);
            automation.Click(charactersBackButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelOnBackButton = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelOnBackButton);
            GameObject charactersPanelOnBackButton = CustomID.testingInstance.GetGameObject(characterPanelID);
            Assert.IsNull(charactersPanelOnBackButton);
        }

        [UnityTest]
        public IEnumerator ShopButtonTest()
        {
            // Before Click Test
            GameObject shopButton = CustomID.testingInstance.GetGameObject(shopButtonID);
            Assert.IsNotNull(shopButton);
            string actualText = shopButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(shopButtonText, actualText);

            // OnClick Test
            automation.Click(shopButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(mainMenuPanelAfterClick);
            GameObject shopPanelAfterClick = CustomID.testingInstance.GetGameObject(shopPanelID);
            Assert.IsNotNull(shopPanelAfterClick);

            // On Clicking the back button in shop Panel
            GameObject shopBackButton = CustomID.testingInstance.GetGameObject(shopBackButtonID);
            automation.Click(shopBackButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelOnBackButton = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelOnBackButton);
            GameObject shopPanelOnBackButton = CustomID.testingInstance.GetGameObject(shopPanelID);
            Assert.IsNull(shopPanelOnBackButton);
        }

        [UnityTest]
        public IEnumerator BuyBoostButtonTest()
        {
            // Before Click Test
            GameObject buyBoostButton = CustomID.testingInstance.GetGameObject(buyBoostButtonID);
            Assert.IsNotNull(buyBoostButton);
            string actualText = buyBoostButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(buyBoostButtonText, actualText);

            // OnClick Test
            automation.Click(buyBoostButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(mainMenuPanelAfterClick);
            GameObject shopPanelAfterClick = CustomID.testingInstance.GetGameObject(shopPanelID);
            Assert.IsNotNull(shopPanelAfterClick);

            // On Clicking the back button in shop Panel
            GameObject shopBackButton = CustomID.testingInstance.GetGameObject(shopBackButtonID);
            automation.Click(shopBackButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelOnBackButton = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelOnBackButton);
            GameObject shopPanelOnBackButton = CustomID.testingInstance.GetGameObject(shopPanelID);
            Assert.IsNull(shopPanelOnBackButton);
        }

        [UnityTest]
        public IEnumerator LeaderBoardButtonTest()
        {
            // Before Click Test
            GameObject leaderBoardButton = CustomID.testingInstance.GetGameObject(leaderBoardButtonID);
            Assert.IsNotNull(leaderBoardButton);
            //string actualText = leaderBoardButton.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
            string actualText = leaderBoardButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(leaderBoardButtonText, actualText);

            // OnClick Test
            automation.Click(leaderBoardButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelAfterClick);
            GameObject leaderBoardPanelAfterClick = CustomID.testingInstance.GetGameObject(leaderBoardPanelID);
            Assert.IsNotNull(leaderBoardPanelAfterClick);

            // On Clicking the back button in LeaderBoard Panel
            GameObject leaderBoardBackButton = CustomID.testingInstance.GetGameObject(leaderBoardBackButtonID);
            automation.Click(leaderBoardBackButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelOnBackButton = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelOnBackButton);
            GameObject leaderBoardPanelOnBackButton = CustomID.testingInstance.GetGameObject(leaderBoardPanelID);
            Assert.IsNull(leaderBoardPanelOnBackButton);
        }

        [UnityTest]
        public IEnumerator GoalsButtonTest()
        {
            // Before Click Test
            GameObject goalsButton = CustomID.testingInstance.GetGameObject(goalsButtonID);
            Assert.IsNotNull(goalsButton);
            string actualText = goalsButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(goalsButtonText, actualText);

            GameObject mainMenuPanelBeforeClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelBeforeClick);
            GameObject goalsPanelBeforeClick = CustomID.testingInstance.GetGameObject(goalsPanelID);
            Assert.IsNull(goalsPanelBeforeClick);

            // OnClick Test
            automation.Click(goalsButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(mainMenuPanelAfterClick);
            GameObject goalsPanelAfterClick = CustomID.testingInstance.GetGameObject(goalsPanelID);
            Assert.IsNotNull(goalsPanelAfterClick);

            // On Clicking the back button in Goals Panel
            GameObject goalsBackButton = CustomID.testingInstance.GetGameObject(goalsBackButtonID);
            automation.Click(goalsBackButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelOnBackButton = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelOnBackButton);
            GameObject goalsPanelOnBackButton = CustomID.testingInstance.GetGameObject(goalsPanelID);
            Assert.IsNull(goalsPanelOnBackButton);
        }

        [UnityTest]
        public IEnumerator DailyBonusButtonTest()
        {
            // Before Click Test
            GameObject dailyBonusButton = CustomID.testingInstance.GetGameObject(dailyBonusButtonID);
            Assert.IsNotNull(dailyBonusButton);
            string actualText = dailyBonusButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(dailyBonusButtonText, actualText);

            // On Click daily Bonus Button
            automation.Click(dailyBonusButton);
            yield return seconds;
            GameObject mysteryBoxPopUp = CustomID.testingInstance.GetGameObject(mysteryBoxPopUpID);
            Assert.IsNotNull(mysteryBoxPopUp);

            // Get Mystery Box Button
            GameObject openMysteryBoxButton = CustomID.testingInstance.GetGameObject(openMysteryBoxButtonID);
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
            GameObject mainMenu = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenu);
        }

        [UnityTest]
        public IEnumerator BuyCurrencyButtonTest()
        {
            // Before Click Test
            GameObject buyCurrencyButton = CustomID.testingInstance.GetGameObject(buyCurrencyButtonID);
            Assert.IsNotNull(buyCurrencyButton);
            string actualText = buyCurrencyButton.gameObject.GetComponentInChildren<Text>().text;
            yield return null;
            Assert.AreEqual(buyCurrencyButtonText, actualText);

            // OnClick Test
            automation.Click(buyCurrencyButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(mainMenuPanelAfterClick);
            GameObject shopPanelAfterClick = CustomID.testingInstance.GetGameObject(shopPanelID);
            Assert.IsNotNull(shopPanelAfterClick);

            // On Clicking the back button in shop Panel
            GameObject shopBackButton = CustomID.testingInstance.GetGameObject(shopBackButtonID);
            automation.Click(shopBackButton);
            yield return new WaitForSeconds(seconds);
            GameObject mainMenuPanelOnBackButton = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelOnBackButton);
            GameObject shopPanelOnBackButton = CustomID.testingInstance.GetGameObject(shopPanelID);
            Assert.IsNull(shopPanelOnBackButton);
        }
    }
}
