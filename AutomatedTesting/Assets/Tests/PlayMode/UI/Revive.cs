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
    public class Revive
    {
        WaitForSeconds seconds = new WaitForSeconds(1);
        string sceneName = "MainMenu";
        string gamePlaySceneName = "GamePlay";
        AutomationTool automation;

        string tapToPlayButtonID = "tapToPlay";
        string tapToPlayText = "Tap To Play";
        string revivePanelID = "revivePanel";
        string reviveByAdButtonID = "reviveByAdButton";
        string reviveByDiamondButtonID = "reviveByDiamondButton";

        string hudPanelID = "HUD_Panel";
        string gameOverPanelID = "gameOverPanel";

        [OneTimeSetUp]
        public void OneSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        [UnityTest]
        public IEnumerator ReviveViaAdTest()
        {
            // Click Tap to play to go in gameplay first
            GameObject tapToPlayButton = CustomID.testingInstance.GetGameObject(tapToPlayButtonID);
            Assert.IsNotNull(tapToPlayButton);
            string actualText = tapToPlayButton.gameObject.GetComponentInChildren<Text>().text;
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

            // Click the Revive Via Ad Button
            GameObject reviveByAdButton = CustomID.testingInstance.GetGameObject(reviveByAdButtonID);
            Assert.IsNotNull(reviveByAdButton);
            automation.Click(reviveByAdButton);
            yield return seconds;
            GameObject revivePanel2 = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNull(revivePanel2);
            GameObject hudPanel2 = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNotNull(hudPanel2);
        }

        [UnityTest]
        public IEnumerator ReviveViaDiamondsTest()
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

            // Click the Revive Via Diamond Button
            GameObject reviveByDiamondButton = CustomID.testingInstance.GetGameObject(reviveByDiamondButtonID);
            Assert.IsNotNull(reviveByDiamondButton);
            automation.Click(reviveByDiamondButton);
            yield return seconds;
            GameObject revivePanel2 = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNull(revivePanel2);
            GameObject hudPanel2 = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNotNull(hudPanel2);
        }

        // Must Run at the end

        [UnityTest]
        public IEnumerator Z_RevivePanelToGameOverTest()
        {
            // Wait for game to be over and appear revive panel
            GameObject revivePanel = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNull(revivePanel);
            var time = Time.time;
            yield return new WaitUntil(() => Time.time > time + 12);
            GameObject revivePanel1 = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNotNull(revivePanel1);
            GameObject hudPanel = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNull(hudPanel);

            // Wait for disapearing revive panel and appearing GameOver Panel
            GameObject gameOverPanel = CustomID.testingInstance.GetGameObject(gameOverPanelID);
            Assert.IsNull(gameOverPanel);
            var time1 = Time.time;
            yield return new WaitUntil(() => Time.time > time1 + 7);
            GameObject gameOverPanel1 = CustomID.testingInstance.GetGameObject(gameOverPanelID);
            Assert.IsNotNull(gameOverPanel1);
            GameObject hudPanel1 = CustomID.testingInstance.GetGameObject(hudPanelID);
            Assert.IsNull(hudPanel1);
            GameObject revivePanel2 = CustomID.testingInstance.GetGameObject(revivePanelID);
            Assert.IsNull(revivePanel2);
        }
    }
}
