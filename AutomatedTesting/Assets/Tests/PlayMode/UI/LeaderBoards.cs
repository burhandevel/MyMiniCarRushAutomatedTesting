using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Knights;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tests
{
    public class LeaderBoards
    {
        WaitForSeconds seconds = new WaitForSeconds(1);
        string sceneName = "MainMenu";
        AutomationTool automation;

        string leaderBoardBackButtonID = "leaderBoardBackButton";
        string leaderBoardPanelID = "leaderBoardPanel";
        string mainMenuPanelID = "mainMenu";
        string leaderBoardButtonText = "LEADER BOARD";
        string leaderBoardButtonID = "leaderBoardButton";

        [OneTimeSetUp]
        public void OneSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        // Must Run at First
        [UnityTest]
        public IEnumerator A_LeaderBoardButtonTest()
        {
            // Before Click Test
            GameObject leaderBoardButton = CustomID.testingInstance.GetGameObject(leaderBoardButtonID);
            Assert.IsNotNull(leaderBoardButton);
            string actualText = leaderBoardButton.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
            yield return null;
            Assert.AreEqual(leaderBoardButtonText, actualText);

            // OnClick Test
            automation.Click(leaderBoardButton);
            yield return seconds;
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelAfterClick);
            GameObject leaderBoardPanelAfterClick = CustomID.testingInstance.GetGameObject(leaderBoardPanelID);
            Assert.IsNotNull(leaderBoardPanelAfterClick);
        }

        [UnityTest]
        public IEnumerator SocialMediaButton()
        {
            Assert.AreEqual(2, 3);
            yield return null;
        }


        // Must Run at the end
        [UnityTest]
        public IEnumerator Z_BackButtonTest()
        {
            GameObject leaderBoardBackButton = CustomID.testingInstance.GetGameObject(leaderBoardBackButtonID);
            Assert.IsNotNull(leaderBoardBackButton);

            GameObject leaderBoardPanel = CustomID.testingInstance.GetGameObject(leaderBoardPanelID);
            GameObject mainMenuPanel = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(leaderBoardPanel);
            Assert.IsNotNull(mainMenuPanel);
            automation.Click(leaderBoardBackButton);
            yield return seconds;
            GameObject leaderBoardPanelAfterClick = CustomID.testingInstance.GetGameObject(leaderBoardPanelID);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(leaderBoardPanelAfterClick);
            Assert.IsNotNull(mainMenuPanelAfterClick);
        }
    }
}
