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
    public class GameOver
    {
        WaitForSeconds seconds = new WaitForSeconds(1);
        string sceneName = "MainMenu";
        string gamePlaySceneName = "GamePlay";
        AutomationTool automation;

        string tapToPlayButtonID = "tapToPlay";
        string tapToPlayText = "Tap To Play";
        string revivePanelID = "revivePanel";
        string gameOverPlayButtonID = "gameOverPlayButton";
        string gameOverHomeButtonID = "gameOverHomeButton";


        string hudPanelID = "HUD_Panel";
        string gameOverPanelID = "gameOverPanel";

        [OneTimeSetUp]
        public void OneSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        // Should Run at first
        [UnityTest]
        public IEnumerator A_PlayButtonTest()
        {
            // Click Tap to play to go in gameplay first
            GameObject tapToPlayButton = CustomID.testingInstance.GetGameObject(tapToPlayButtonID);
            Assert.IsNotNull(tapToPlayButton);
            string actualText = tapToPlayButton.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
            yield return null;
            Assert.AreEqual(tapToPlayText, actualText);

            automation.Click(tapToPlayButton);
            var time = Time.time;
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == gamePlaySceneName || Time.time > time + 10);
            Assert.AreEqual(gamePlaySceneName, SceneManager.GetActiveScene().name);
            GameObject hudPanel = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNotNull(hudPanel);

            // Wait for game to be over and appear revive panel
            GameObject revivePanel = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNull(revivePanel);
            var time1 = Time.time;
            yield return new WaitUntil(() => Time.time > time1 + 12);
            GameObject revivePanel1 = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNotNull(revivePanel1);
            GameObject hudPanel1 = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNull(hudPanel1);

            // Wait for disapearing revive panel and appearing GameOver Panel
            GameObject gameOverPanel = CustomID.testingInstance.GetGameObject(gameOverPanelID);
            Assert.IsNull(gameOverPanel);
            var time2 = Time.time;
            yield return new WaitUntil(() => Time.time > time2 + 7);
            GameObject gameOverPanel1 = CustomID.testingInstance.GetGameObject(gameOverPanelID);
            Assert.IsNotNull(gameOverPanel1);
            GameObject hudPanel2 = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNull(hudPanel2);
            GameObject revivePanel2 = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNull(revivePanel2);

            // Clicking the play button test
            GameObject playButton = CustomID.testingInstance.GetGameObject(gameOverPlayButtonID);
            Assert.IsNotNull(playButton);
            automation.Click(playButton);
            yield return seconds;
            GameObject hudPanel3 = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNotNull(hudPanel3);
        }

        [UnityTest]
        public IEnumerator HomeButtonTest()
        {
            // Wait for game to be over and appear revive panel
            GameObject revivePanel = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNull(revivePanel);
            var time1 = Time.time;
            yield return new WaitUntil(() => Time.time > time1 + 12);
            GameObject revivePanel1 = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNotNull(revivePanel1);
            GameObject hudPanel1 = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNull(hudPanel1);

            // Wait for disapearing revive panel and appearing GameOver Panel
            GameObject gameOverPanel = CustomID.testingInstance.GetGameObject(gameOverPanelID);
            Assert.IsNull(gameOverPanel);
            var time2 = Time.time;
            yield return new WaitUntil(() => Time.time > time2 + 7);
            GameObject gameOverPanel1 = CustomID.testingInstance.GetGameObject(gameOverPanelID);
            Assert.IsNotNull(gameOverPanel1);
            GameObject hudPanel2 = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNull(hudPanel2);
            GameObject revivePanel2 = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNull(revivePanel2);

            // Clicking the play button test
            GameObject homeButton = CustomID.testingInstance.GetGameObject(gameOverHomeButtonID);
            Assert.IsNotNull(homeButton);
            automation.Click(homeButton);
            yield return seconds;
            Assert.AreEqual(sceneName, SceneManager.GetActiveScene().name);
        }

        [UnityTest]
        public IEnumerator SocialMediaLeaderBoardTest()
        {
            yield return null;
        }
    }
}
