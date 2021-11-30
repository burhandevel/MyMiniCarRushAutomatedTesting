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
    public class Goals
    {
        WaitForSeconds seconds = new WaitForSeconds(1);
        string sceneName = "MainMenu";
        AutomationTool automation;

        string goalsButtonID = "goalsButton";
        string goalsButtonText = "GOALS";
        string mainMenuPanelID = "mainMenu";
        string goalsPanelID = "goalsPanel";
        string goalsBackButtonID = "goalsBackButton";

        [OneTimeSetUp]
        public void OneSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            automation = new AutomationTool();
        }

        [UnityTest]
        public IEnumerator GoalsButtonTest()
        {

            // Before Click Test
            GameObject goalsButton = CustomID.testingInstance.GetGameObject(goalsButtonID);
            Assert.IsNotNull(goalsButton);
            string actualText = goalsButton.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
            yield return null;
            Assert.AreEqual(goalsButtonText, actualText);

            GameObject mainMenuPanelBeforeClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(mainMenuPanelBeforeClick);
            GameObject goalsPanelBeforeClick = CustomID.testingInstance.GetGameObject(goalsPanelID);
            Assert.IsNull(goalsPanelBeforeClick);

            // OnClick Test
            automation.Click(goalsButton);
            yield return seconds;
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(mainMenuPanelAfterClick);
            GameObject goalsPanelAfterClick = CustomID.testingInstance.GetGameObject(goalsPanelID);
            Assert.IsNotNull(goalsPanelAfterClick);
        }

        // Must Run at the end
        [UnityTest]
        public IEnumerator Z_BackButtonTest()
        {
            GameObject goalsBackButton = CustomID.testingInstance.GetGameObject(goalsBackButtonID);
            Assert.IsNotNull(goalsBackButton);

            GameObject goalsPanel = CustomID.testingInstance.GetGameObject(goalsPanelID);
            GameObject mainMenuPanel = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNotNull(goalsPanel);
            Assert.IsNull(mainMenuPanel);
            automation.Click(goalsBackButton);
            yield return seconds;
            GameObject goalsPanelAfterClick = CustomID.testingInstance.GetGameObject(goalsPanelID);
            GameObject mainMenuPanelAfterClick = CustomID.testingInstance.GetGameObject(mainMenuPanelID);
            Assert.IsNull(goalsPanelAfterClick);
            Assert.IsNotNull(mainMenuPanelAfterClick);
        }
    }
}
