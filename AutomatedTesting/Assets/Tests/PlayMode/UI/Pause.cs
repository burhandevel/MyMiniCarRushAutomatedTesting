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
    public class Pause
    {
        WaitForSeconds seconds = new WaitForSeconds(1);
        string sceneName = "MainMenu";
        AutomationTool automation;

        // GameObjects IDs
        string tapToPlayButtonID = "tapToPlay";
        string tapToPlayText = "Tap To Play";
        string gamePlaySceneName = "GamePlay";
        string pauseButtonID = "gamePlayPauseButton";
        string pauseButtonText = "Pause";
        string resumeButtonID = "resumeButton";
        string resumeButtonText = "Resume";
        string buyBoostButtonID = "pauseBuyBoostButton";
        string buyCurrencyButtonID = "pauseBuyCurrencyButton";
        string buyViaCoinsButtonID = "buyViaCoinsButton";
        string buyViaAdsButtonID = "buyViaAdsButton";
        string buyCoinsButtonID = "buyCoinsButton";
        string buyDiamondsButtonID = "buyDiamondsButton";
        string pauseSettingButtonID = "pauseSettingButton";
        string pauseSettingRumbleSliderID = "pauseSettingRumbleSlider";
        string pauseSettingMusicSliderID = "pauseSettingMusicSlider";
        string pauseSettingSoundSliderID = "pauseSettingSoundSlider";
        string pauseSettingBackButtonID = "pauseSettingBackButton";
        string quitButtonID = "QuitButton";
        string quitYesButtonID = "QuitYesButton";
        string quitNoButtonID = "QuitNoButton";

        // Panel IDs
        string hudPanelID = "HUD_Panel";
        string pausePanelID = "pausePanel";
        string buyBoostPopupPanelID = "buyBoostPopupPanel";
        string buyCurrencyPopupPanelID = "buyCurrencyPopupPanel";
        string pauseSettingPanelID = "pauseSettingPanel";
        string quitPopupPanelID = "QuitPopup";

        [OneTimeSetUp]
        public void OneSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        // Must Run at First
        [UnityTest]
        public IEnumerator A_ResumeButtonTest()
        {
            // Click tap to play
            GameObject tapToPlayButton = CustomID.testingInstance.GetGameObject(tapToPlayButtonID);
            Assert.IsNotNull(tapToPlayButton);
            string actualText = tapToPlayButton.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
            yield return null;
            Assert.AreEqual(tapToPlayText, actualText);

            automation.Click(tapToPlayButton);
            var time = Time.time;
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == gamePlaySceneName || Time.time > time + 10);
            Assert.AreEqual(gamePlaySceneName, SceneManager.GetActiveScene().name);
            yield return null;

            // Click Pause Button

            // Before Click Test
            GameObject pauseButton = CustomID.testingInstance.GetGameObject(pauseButtonID);
            Assert.IsNotNull(pauseButton);
            yield return null;
            Assert.AreEqual(pauseButtonText, pauseButton.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);

            GameObject hudPanel = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNotNull(hudPanel);
            GameObject pausePanel = CustomID.testingInstance.GetGameObject(pausePanelID);
            Assert.IsNull(pausePanel);

            // OnClicking the Pause Button
            // OnClick Test
            automation.Click(pauseButton);
            yield return seconds;
            GameObject hudPanelAfterClick = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNull(hudPanelAfterClick);
            GameObject pausePanelAfterClick = CustomID.testingInstance.GetGameObject(pausePanelID);
            Assert.IsNotNull(pausePanelAfterClick);

            //On Clicking the Resume button
            // OnClick Test
            GameObject resumeButton = CustomID.testingInstance.GetGameObject(resumeButtonID);
            Assert.IsNotNull(resumeButton);
            Assert.AreEqual(resumeButtonText, resumeButton.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            automation.Click(resumeButton);
            yield return seconds;
            GameObject hudPanelOnResume = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNotNull(hudPanelOnResume);
            GameObject pausePanelOnResume = CustomID.testingInstance.GetGameObject(pausePanelID);
            Assert.IsNull(pausePanelOnResume);

            // Again Click the pause Button to go back on pause panel
            // OnClick Test
            automation.Click(pauseButton);
            yield return seconds;
            GameObject hudPanelAfterClick1 = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNull(hudPanelAfterClick1);
            GameObject pausePanelAfterClick1 = CustomID.testingInstance.GetGameObject(pausePanelID);
            Assert.IsNotNull(pausePanelAfterClick1);
        }

        [UnityTest]
        public IEnumerator SettingsTest()
        {
            // Before Click Test
            GameObject pauseSettingButton = CustomID.testingInstance.GetGameObject(pauseSettingButtonID);
            Assert.IsNotNull(pauseSettingButton);
            GameObject pausePanel = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject pauseSettingPanel = CustomID.testingInstance.GetGameObject(pauseSettingPanelID);
            Assert.IsNotNull(pausePanel);
            Assert.IsNull(pauseSettingPanel);


            // On Click the Setting button
            automation.Click(pauseSettingButton);
            yield return seconds;
            GameObject pausePanelAfterClick = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject pauseSettingPanelAfterClick = CustomID.testingInstance.GetGameObject(pauseSettingPanelID);
            Assert.IsNull(pausePanelAfterClick);
            Assert.IsNotNull(pauseSettingPanelAfterClick);

            GameObject rumbleSlider = CustomID.testingInstance.GetGameObject(pauseSettingRumbleSliderID);
            Assert.IsNotNull(rumbleSlider);
            float rumbleSliderValue = Random.Range(0.0f, 1.0f);
            automation.SetSliderValue(rumbleSlider, rumbleSliderValue);
            yield return seconds;
            // Assert in future

            GameObject musicSlider = CustomID.testingInstance.GetGameObject(pauseSettingMusicSliderID);
            Assert.IsNotNull(musicSlider);
            float musicSliderValue = Random.Range(0.0f, 1.0f);
            automation.SetSliderValue(musicSlider, musicSliderValue);
            yield return seconds;
            // Assert in future

            GameObject soundSlider = CustomID.testingInstance.GetGameObject(pauseSettingSoundSliderID);
            Assert.IsNotNull(soundSlider);
            float soundSliderValue = Random.Range(0.0f, 1.0f);
            automation.SetSliderValue(soundSlider, soundSliderValue);
            yield return seconds;
            // Assert in future

            // Click the back button
            GameObject pauseSettingBackButton = CustomID.testingInstance.GetGameObject(pauseSettingBackButtonID);
            Assert.IsNotNull(pauseSettingBackButton);
            automation.Click(pauseSettingBackButton);
            yield return seconds;
            GameObject pausePanelOnBack = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject pauseSettingPanelOnBack = CustomID.testingInstance.GetGameObject(pauseSettingPanelID);
            Assert.IsNotNull(pausePanelOnBack);
            Assert.IsNull(pauseSettingPanelOnBack);
        }

        [UnityTest]
        public IEnumerator BuyCurrencyButtonTest()
        {
            // Before Click Test
            GameObject buyCurrencyButton = CustomID.testingInstance.GetGameObject(buyCurrencyButtonID);
            Assert.IsNotNull(buyCurrencyButton);
            GameObject pausePanel = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject buyCurrencyPopupPanel = CustomID.testingInstance.GetGameObject(buyCurrencyPopupPanelID);
            Assert.IsNotNull(pausePanel);
            Assert.IsNull(buyCurrencyPopupPanel);

            // On Click the buy boost button
            automation.Click(buyCurrencyButton);
            yield return seconds;
            GameObject pausePanelAfterClick = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject buyCurrencyPopupPanelAfterClick = CustomID.testingInstance.GetGameObject(buyCurrencyPopupPanelID);
            Assert.IsNotNull(pausePanelAfterClick);
            Assert.IsNotNull(buyCurrencyPopupPanelAfterClick);

            // Click Buy Coins Button
            GameObject buyCoinsButton = CustomID.testingInstance.GetGameObject(buyCoinsButtonID);
            automation.Click(buyCoinsButton);
            yield return seconds;
            GameObject currentPopupOnCoinsClick = CustomID.testingInstance.GetGameObject(buyCurrencyPopupPanelID);
            Assert.IsNull(currentPopupOnCoinsClick);

            // Again Click the buy currency button
            automation.Click(buyCurrencyButton);
            yield return seconds;
            GameObject pausePanelAfterClick1 = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject buyCurrencyPopupPanelAfterClick1 = CustomID.testingInstance.GetGameObject(buyCurrencyPopupPanelID);
            Assert.IsNotNull(pausePanelAfterClick1);
            Assert.IsNotNull(buyCurrencyPopupPanelAfterClick1);

            // Click Buy Diamonds Button
            GameObject buyDiamondButton = CustomID.testingInstance.GetGameObject(buyDiamondsButtonID);
            automation.Click(buyDiamondButton);
            yield return seconds;
            GameObject currentPopupOnDiamondsClick = CustomID.testingInstance.GetGameObject(buyCurrencyPopupPanelID);
            Assert.IsNull(currentPopupOnDiamondsClick);
        }

        [UnityTest]
        public IEnumerator BuyBoostButtonTest()
        {
            // Before Click Test
            GameObject buyBoostButton = CustomID.testingInstance.GetGameObject(buyBoostButtonID);
            Assert.IsNotNull(buyBoostButton);
            GameObject pausePanel = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject buyBoostPopupPanel = CustomID.testingInstance.GetGameObject(buyBoostPopupPanelID);
            Assert.IsNotNull(pausePanel);
            Assert.IsNull(buyBoostPopupPanel);

            // On Click the buy boost button
            automation.Click(buyBoostButton);
            yield return seconds;
            GameObject pausePanelAfterClick = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject buyBoostPopupPanelAfterClick = CustomID.testingInstance.GetGameObject(buyBoostPopupPanelID);
            Assert.IsNotNull(pausePanelAfterClick);
            Assert.IsNotNull(buyBoostPopupPanelAfterClick);

            // Click Buy Via Coins Button
            GameObject buyViaCoinsButton = CustomID.testingInstance.GetGameObject(buyViaCoinsButtonID);
            Assert.IsNotNull(buyViaCoinsButton);
            automation.Click(buyViaCoinsButton);
            yield return seconds;
            GameObject currentPopupOnCoinsClick = CustomID.testingInstance.GetGameObject(buyBoostPopupPanelID);
            Assert.IsNull(currentPopupOnCoinsClick);

            // Again Click the buy boost button
            automation.Click(buyBoostButton);
            yield return seconds;
            GameObject pausePanelAfterClick1 = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject buyBoostPopupPanelAfterClick1 = CustomID.testingInstance.GetGameObject(buyBoostPopupPanelID);
            Assert.IsNotNull(pausePanelAfterClick1);
            Assert.IsNotNull(buyBoostPopupPanelAfterClick1);

            // Click Buy Via Coins Ad
            GameObject buyViaAdsButton = CustomID.testingInstance.GetGameObject(buyViaAdsButtonID);
            Assert.IsNotNull(buyViaAdsButton);
            automation.Click(buyViaAdsButton);
            yield return seconds;
            GameObject currentPopupOnAdsClick = CustomID.testingInstance.GetGameObject(buyBoostPopupPanelID);
            Assert.IsNull(currentPopupOnAdsClick);
        }

        // Must Run at last
        [UnityTest]
        public IEnumerator Z_QuitButtonTest()
        {
            // Before Click Test
            GameObject quitButton = CustomID.testingInstance.GetGameObject(quitButtonID);
            Assert.IsNotNull(quitButton);
            GameObject pausePanel = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject quitPopupPanel = CustomID.testingInstance.GetGameObject(quitPopupPanelID);
            Assert.IsNotNull(pausePanel);
            Assert.IsNull(quitPopupPanel);

            // On Click the Quit button
            automation.Click(quitButton);
            yield return seconds;
            GameObject pausePanelAfterClick = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject quitPopupPanelAfterClick = CustomID.testingInstance.GetGameObject(quitPopupPanelID);
            Assert.IsNotNull(pausePanelAfterClick);
            Assert.IsNotNull(quitPopupPanelAfterClick);

            // Click No Button
            GameObject quitNoButton = CustomID.testingInstance.GetGameObject(quitNoButtonID);
            Assert.IsNotNull(quitNoButton);
            automation.Click(quitNoButton);
            yield return seconds;
            GameObject currentPopupOnNoClick = CustomID.testingInstance.GetGameObject(quitPopupPanelID);
            Assert.IsNull(currentPopupOnNoClick);

            // Again Click Quit button
            automation.Click(quitButton);
            yield return seconds;
            GameObject pausePanelAfterClick1 = CustomID.testingInstance.GetGameObject(pausePanelID);
            GameObject quitPopupPanelAfterClick1 = CustomID.testingInstance.GetGameObject(quitPopupPanelID);
            Assert.IsNotNull(pausePanelAfterClick1);
            Assert.IsNotNull(quitPopupPanelAfterClick1);

            // Click Yes Button
            GameObject quitYesButton = CustomID.testingInstance.GetGameObject(quitYesButtonID);
            Assert.IsNotNull(quitYesButton);
            automation.Click(quitYesButton);
            yield return seconds;
            GameObject currentPopupOnYesClick = CustomID.testingInstance.GetGameObject(quitPopupPanelID);
            Assert.IsNull(currentPopupOnYesClick);

            yield return new WaitForSeconds(5);
            Assert.AreEqual(sceneName, SceneManager.GetActiveScene().name);
        }
    }
}
