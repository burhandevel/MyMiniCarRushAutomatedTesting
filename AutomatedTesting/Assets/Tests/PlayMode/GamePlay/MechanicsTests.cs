using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Threading;
using Knights;

namespace Tests
{
    public class MechanicsTests
    {
        GameObject player = null;
        Mechanics mechanics = null;
        ReflectionTool reflection = null;
        string sceneName = "SampleScene";
        float delay = 5;
        // Player Testing ID
        string playerID = "playerCar";
        // Input Functions
        string SwipeLeft = "SwipeLeft";
        string SwipeRight = "SwipeRight";
        string SwipeUp = "SwipeUp";
        string SwipeDown = "SwipeDown";
        string Dash = "Dash";
        string Boost = "Boost";
        // Lanes Data
        float maxLanes = 3;
        float laneSwitchDistance = 1;
        float rightLaneBoundary;
        float leftLaneBoundary;

        float jumpHeight = 4;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            SceneManager.LoadSceneAsync(sceneName);
            if (maxLanes % 2 == 0)
            {
                rightLaneBoundary = maxLanes;
                leftLaneBoundary = 1;
                Debug.Log("Left Lane = " + leftLaneBoundary);
                Debug.Log("Right Lane = " + rightLaneBoundary);
            }
            else
            {
                rightLaneBoundary = (maxLanes / 2) - 0.5f;
                leftLaneBoundary = -rightLaneBoundary;
                Debug.Log("Left Lane = " + leftLaneBoundary);
                Debug.Log("Right Lane = " + rightLaneBoundary);

            }
        }

        [SetUp]
        public void SetUp()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////

        [UnityTest]
        public IEnumerator SwipeLeftTest()
        {
            if (player == null)
            {
                player = CustomID.testingInstance.GetGameObject(playerID);
                // Reference to input script
                mechanics = player.GetComponent<Mechanics>();
                reflection = new ReflectionTool();
            }

            yield return new WaitForSeconds(1);

            float xPosition = player.transform.position.x;

            if (xPosition == leftLaneBoundary)
            {
                // Call Swipe Left Method From Input Script
                reflection.CallMethod(mechanics, SwipeLeft);
                Assert.AreEqual(xPosition, player.transform.position.x);
            }
            else
            {
                // Call Swipe Left Method From Input Script
                reflection.CallMethod(mechanics, SwipeLeft);
                var time = Time.time;
                yield return new WaitUntil(() => player.transform.position.x == (xPosition - laneSwitchDistance) || Time.time >= time + delay);
                Assert.AreEqual((xPosition - laneSwitchDistance), player.transform.position.x);
            }

            //yield return new WaitForSeconds(1);
        }

        [UnityTest]
        public IEnumerator SwipeRightTest()
        {
            if (player == null)
            {
                player = CustomID.testingInstance.GetGameObject(playerID);
                mechanics = player.GetComponent<Mechanics>();
                reflection = new ReflectionTool();
            }

            yield return new WaitForSeconds(1);

            float xPosition = player.transform.position.x;
            if (xPosition == rightLaneBoundary)
            {
                // Call Swipe Right Method From Input Script
                reflection.CallMethod(mechanics, SwipeRight);
                Assert.AreEqual(xPosition, player.transform.position.x);
            }
            else
            {
                // Call Swipe Right Method From Input Script
                reflection.CallMethod(mechanics, SwipeRight);
                var time = Time.time;
                yield return new WaitUntil(() => player.transform.position.x == (xPosition + laneSwitchDistance) || Time.time >= time + delay);
                Assert.AreEqual(xPosition + laneSwitchDistance, player.transform.position.x);
            }
        }

        [UnityTest]
        public IEnumerator JumpTest()
        {
            if (player == null)
            {
                player = CustomID.testingInstance.GetGameObject(playerID);
                mechanics = player.GetComponent<Mechanics>();
                reflection = new ReflectionTool();
            }

            yield return new WaitForSeconds(1);

            float yPosition = player.transform.position.y;
            // Call SwipeUp Method from Input Script
            reflection.CallMethod(mechanics, SwipeUp);
            var time = Time.time;
            yield return new WaitUntil(() => player.transform.position.y == yPosition + jumpHeight || Time.time >= time + delay);
            Assert.AreEqual(yPosition + jumpHeight, player.transform.position.y);
        }

        [UnityTest]
        public IEnumerator DuckTest()
        {
            if (player == null)
            {
                player = CustomID.testingInstance.GetGameObject(playerID);
                mechanics = player.GetComponent<Mechanics>();
                reflection = new ReflectionTool();
            }

            yield return new WaitForSeconds(1);

            float yScale = player.transform.localScale.y;
            if (yScale < 1)
            {
                reflection.CallMethod(mechanics, SwipeDown);
                Assert.AreEqual(yScale, player.transform.localScale.y);
            }
            else if (yScale == 1)
            {
                reflection.CallMethod(mechanics, SwipeDown);
                var time = Time.time;
                yield return new WaitUntil(() => player.transform.localScale.y == (yScale - 0.5) || Time.time > time + 2);
                Assert.AreEqual(yScale - 0.5, player.transform.localScale.y);
                var time2 = Time.time;
                yield return new WaitUntil(() => player.transform.localScale.y == 1 || Time.time > time2 + 2);
                Assert.AreEqual(1, player.transform.localScale.y);
            }

            //yield return new WaitForSeconds(1);

        }

        [UnityTest]
        public IEnumerator DashTest()
        {
            if (player == null)
            {
                player = CustomID.testingInstance.GetGameObject(playerID);
                mechanics = player.GetComponent<Mechanics>();
                reflection = new ReflectionTool();
            }

            yield return new WaitForSeconds(1);

            float zPositionInitial = player.transform.position.z;
            reflection.CallMethod(mechanics, Dash);
            //Assert.AreEqual(8, reflection.GetValue<float>(mechanics, "speed"));
            yield return new WaitForSeconds(2);
            float zPositionFinal = player.transform.position.z;
            float distance = (float)System.Math.Round((zPositionFinal - zPositionInitial), 0);
            Assert.GreaterOrEqual(distance, 16);
            //Assert.AreEqual(5, reflection.GetValue<float>(mechanics, "speed"));
            Debug.Log("Dash Distance = " + distance);

            //yield return new WaitForSeconds(1);

        }

        [UnityTest]
        public IEnumerator BoostTest()
        {
            if (player == null)
            {
                player = CustomID.testingInstance.GetGameObject(playerID);
                mechanics = player.GetComponent<Mechanics>();
                reflection = new ReflectionTool();
            }

            yield return new WaitForSeconds(1);

            float zPositionInitial = player.transform.position.z;
            //mechanics.Boost();
            reflection.CallMethod(mechanics, Boost);
            Assert.AreEqual(12, reflection.GetValue<float>(mechanics, "speed"));
            yield return new WaitForSeconds(8);
            float zPositionFinal = player.transform.position.z;
            float distance = (float)System.Math.Round((zPositionFinal - zPositionInitial), 0);
            Assert.GreaterOrEqual(distance, 96);
            Assert.AreEqual(5, reflection.GetValue<float>(mechanics, "speed"));
            Debug.Log("Boost Distance = " + distance);

            //yield return new WaitForSeconds(1);

        }

        [UnityTest]
        public IEnumerator ShockWaveTest()
        {
            if (player == null)
            {
                player = CustomID.testingInstance.GetGameObject(playerID);
                mechanics = player.GetComponent<Mechanics>();
                reflection = new ReflectionTool();
            }

            yield return new WaitForSeconds(1);

            float yPosition = player.transform.position.y;
            float yLocalScale = player.transform.localScale.y;
            reflection.CallMethod(mechanics, SwipeUp);
            reflection.CallMethod(mechanics, SwipeDown);
            var time = Time.time;
            yield return new WaitUntil(() => (player.transform.position.y > yPosition) && (player.transform.localScale.y == yLocalScale - 0.5f) || Time.time > time + 3);
            Assert.IsTrue((player.transform.position.y > yPosition) && (player.transform.localScale.y == yLocalScale - 0.5f));

            if ((player.transform.position.y > yPosition) && (player.transform.localScale.y == yLocalScale - 0.5f))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

            //yield return new WaitForSeconds(1);

        }

        ////////////////////////////////////////////////////////////////////////////////////////

        [TearDown]
        public void TearDown()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            SceneManager.UnloadSceneAsync(0);
        }
    }
}
