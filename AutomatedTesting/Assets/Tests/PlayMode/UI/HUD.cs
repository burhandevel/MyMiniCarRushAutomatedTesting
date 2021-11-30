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
    public class HUD
    {
        WaitForSeconds seconds = new WaitForSeconds(1);
        string sceneName = "MainMenu";
        AutomationTool automation;

        string tapToPlayButtonID = "tapToPlay";
        string tapToPlayText = "Tap To Play";
        string gamePlaySceneName = "GamePlay";
        string pauseButtonID = "gamePlayPauseButton";
        string pauseButtonText = "Pause";
        string resumeButtonID = "resumeButton";
        string resumeButtonText = "Resume";

        string hudPanelID = "HUD_Panel";
        string pausePanelID = "pausePanel";

        [OneTimeSetUp]
        public void OneSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        // Must Run at First
        [UnityTest]
        public IEnumerator A_TapToPlayButtonTest()
        {
            GameObject tapToPlayButton = CustomID.testingInstance.GetGameObject(tapToPlayButtonID);
            Assert.IsNotNull(tapToPlayButton);
            string actualText = tapToPlayButton.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
            yield return null;
            Assert.AreEqual(tapToPlayText, actualText);

            automation.Click(tapToPlayButton);
            var time = Time.time;
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == gamePlaySceneName || Time.time > time + 10);
            Assert.AreEqual(gamePlaySceneName, SceneManager.GetActiveScene().name);
        }

        [UnityTest]
        public IEnumerator PauseButtonTest()
        {
            // Before Click Test
            GameObject pauseButton = CustomID.testingInstance.GetGameObject(pauseButtonID);
            Assert.IsNotNull(pauseButton);
            string actualText = pauseButton.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
            yield return null;
            Assert.AreEqual(pauseButtonText, actualText);

            GameObject hudPanel = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNotNull(hudPanel);
            GameObject pausePanel = CustomID.testingInstance.GetGameObject(pausePanelID);
            Assert.IsNull(pausePanel);

            // OnClick Test
            automation.Click(pauseButton);
            yield return seconds;
            GameObject hudPanelAfterClick = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNull(hudPanelAfterClick);
            GameObject pausePanelAfterClick = CustomID.testingInstance.GetGameObject(pausePanelID);
            Assert.IsNotNull(pausePanelAfterClick);

            //On Clicking the Resume button
            GameObject resumeButton = CustomID.testingInstance.GetGameObject(resumeButtonID);
            automation.Click(resumeButton);
            yield return seconds;
            GameObject hudPanelOnResume = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNotNull(hudPanelOnResume);
            GameObject pausePanelOnResume = CustomID.testingInstance.GetGameObject(pausePanelID);
            Assert.IsNull(pausePanelOnResume);

        }

        [UnityTest]
        public IEnumerator HeadStartButtonTest()
        {
            Assert.AreEqual(1, 2);
            yield return null;
        }
    }
}
