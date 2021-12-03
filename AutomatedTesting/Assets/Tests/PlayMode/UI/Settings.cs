using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using Knights;

namespace Tests
{
    public class Settings
    {
        bool independentTest = false;
        WaitForSeconds seconds = new WaitForSeconds(1);
        string sceneName = "MainMenu";
        AutomationTool automation;

        string rumbleSliderID = "rumbleSlider";
        string musicSliderID = "musicSlider";
        string soundSliderID = "soundSlider";
        string settingButtonID = "settingButton";
        string settingPanelID = "settingPanel";
        string mainMenuPanelID = "mainMenu";
        string settingBackButtonID = "settingsBackButton";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        [UnityTest]
        public IEnumerator RumbleSliderTest()
        {
            if (independentTest)
            {
                GameObject settingButton = CustomID.testingInstance.GetGameObject(settingButtonID);
                GameObject settingPanel = CustomID.testingInstance.GetGameObject(settingPanelID);
                GameObject mainMenuPanel = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
                Assert.IsNotNull(mainMenuPanel);
                Assert.IsNull(settingPanel);
                automation.Click(settingButton);
                yield return seconds;
                GameObject settingPanelAfterClick = CustomID.testingInstance.GetGameObject(settingPanelID);
                GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
                Assert.IsNull(mainMenuPanelAfterClick);
                Assert.IsNotNull(settingPanelAfterClick);

                GameObject rumbleSlider = CustomID.testingInstance.GetGameObject(rumbleSliderID);
                Assert.IsNotNull(rumbleSlider);
                float sliderValue = Random.Range(0.0f, 1.0f);
                automation.SetSliderValue(rumbleSlider, sliderValue);
                yield return seconds;
                // Assert in future
            }
            else
            {
                GameObject rumbleSlider = CustomID.testingInstance.GetGameObject(rumbleSliderID);
                Assert.IsNotNull(rumbleSlider);
                float sliderValue = Random.Range(0.0f, 1.0f);
                automation.SetSliderValue(rumbleSlider, sliderValue);
                yield return seconds;
                // Assert in future
            }

        }

        [UnityTest]
        public IEnumerator MusicSliderTest()
        {

            if (independentTest)
            {
                GameObject settingButton = CustomID.testingInstance.GetGameObject(settingButtonID);
                GameObject settingPanel = CustomID.testingInstance.GetGameObject(settingPanelID);
                GameObject mainMenuPanel = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
                Assert.IsNotNull(mainMenuPanel);
                Assert.IsNull(settingPanel);
                automation.Click(settingButton);
                yield return seconds;
                GameObject settingPanelAfterClick = CustomID.testingInstance.GetGameObject(settingPanelID);
                GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
                Assert.IsNull(mainMenuPanelAfterClick);
                Assert.IsNotNull(settingPanelAfterClick);

                GameObject musicSlider = CustomID.testingInstance.GetGameObject(musicSliderID);
                Assert.IsNotNull(musicSlider);
                float sliderValue = Random.Range(0.0f, 1.0f);
                automation.SetSliderValue(musicSlider, sliderValue);
                yield return seconds;
                // Assert in future
            }
            else
            {
                GameObject settingButton = CustomID.testingInstance.GetGameObject(settingButtonID);
                GameObject settingPanel = CustomID.testingInstance.GetGameObject(settingPanelID);
                GameObject mainMenuPanel = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
                Assert.IsNotNull(mainMenuPanel);
                Assert.IsNull(settingPanel);
                automation.Click(settingButton);
                yield return seconds;
                GameObject settingPanelAfterClick = CustomID.testingInstance.GetGameObject(settingPanelID);
                GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
                Assert.IsNull(mainMenuPanelAfterClick);
                Assert.IsNotNull(settingPanelAfterClick);

                GameObject musicSlider = CustomID.testingInstance.GetGameObject(musicSliderID);
                Assert.IsNotNull(musicSlider);
                float sliderValue = Random.Range(0.0f, 1.0f);
                automation.SetSliderValue(musicSlider, sliderValue);
                yield return seconds;
                // Assert in future
            }
        }

        [UnityTest]
        public IEnumerator SoundSliderTest()
        {

            if (independentTest)
            {
                GameObject settingButton = CustomID.testingInstance.GetGameObject(settingButtonID);
                GameObject settingPanel = CustomID.testingInstance.GetGameObject(settingPanelID);
                GameObject mainMenuPanel = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
                Assert.IsNotNull(mainMenuPanel);
                Assert.IsNull(settingPanel);
                automation.Click(settingButton);
                yield return seconds;
                GameObject settingPanelAfterClick = CustomID.testingInstance.GetGameObject(settingPanelID);
                GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
                Assert.IsNull(mainMenuPanelAfterClick);
                Assert.IsNotNull(settingPanelAfterClick);

                GameObject soundSlider = CustomID.testingInstance.GetGameObject(soundSliderID);
                Assert.IsNotNull(soundSlider);
                float sliderValue = Random.Range(0.0f, 1.0f);
                automation.SetSliderValue(soundSlider, sliderValue);
                yield return seconds;
                // Assert in future
            }
            else
            {
                GameObject soundSlider = CustomID.testingInstance.GetGameObject(soundSliderID);
                Assert.IsNotNull(soundSlider);
                float sliderValue = Random.Range(0.0f, 1.0f);
                automation.SetSliderValue(soundSlider, sliderValue);
                yield return seconds;
                // Assert in future
            }
        }

        // Must Run at the end
        [UnityTest]
        public IEnumerator Z_BackButtonTest()
        {
            GameObject settingBackButton = CustomID.testingInstance.GetGameObject(settingBackButtonID);
            Assert.IsNotNull(settingBackButton);

            GameObject settingPanel = CustomID.testingInstance.GetGameObject(settingPanelID);
            GameObject mainMenuPanel = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(settingPanel);
            Assert.IsNull(mainMenuPanel);
            automation.Click(settingBackButton);
            yield return seconds;
            GameObject settingPanelAfterClick = CustomID.testingInstance.GetGameObject(settingPanelID);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(settingPanelAfterClick);
            Assert.IsNotNull(mainMenuPanelAfterClick);
        }
    }
}
