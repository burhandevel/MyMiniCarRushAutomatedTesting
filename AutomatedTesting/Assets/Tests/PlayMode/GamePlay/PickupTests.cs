using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Knights;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class PickupTests
    {
        string sceneName = "SampleScene";
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            SceneManager.LoadScene(sceneName);
        }

        [UnityTest]
        public IEnumerator CoinsPickupTest()
        {
            GameObject player = CustomID.testingInstance.GetGameObject("playerCar");
            GameObject coin = CustomID.testingInstance.GetGameObject("Coin");
            int coinsAmount = PlayerPrefs.GetInt("COINS");
            yield return new WaitUntil(() => player.GetComponent<BoxCollider>().bounds.Intersects(coin.GetComponent<BoxCollider>().bounds) == true);
            Assert.IsFalse(coin.gameObject.activeSelf);
            Assert.AreEqual(coinsAmount + 1, PlayerPrefs.GetInt("COINS"));


            yield return null;
            List<GameObject> allCoins = CustomTag.testingTagInstance.GetGameObjectsList("CoinPickup");
            Debug.Log(allCoins.Count);

            /*List<GameObject> allCoins = CustomTag.testingTagInstance.GetGameObjectsList("CoinPickup");
            float[] distances = null;
            for (int j = 0; j < allCoins.Count; j++)
            {
                float d = Vector3.Distance(player.transform.position, j.transform.position);
                distances[j] = d;
            }

            System.Array.Sort(distances);

            foreach (GameObject g in allCoins)
            {
                Debug.Log(g.name);
                int coinsAmount = PlayerPrefs.GetInt("COINS");
                yield return new WaitUntil(() => player.GetComponent<BoxCollider>().bounds.Intersects(g.GetComponent<BoxCollider>().bounds) == true);
                if (g.GetComponent<BoxCollider>().bounds.Intersects(player.GetComponent<BoxCollider>().bounds))
                {
                    Assert.IsFalse(g.gameObject.activeSelf);
                    Assert.AreEqual(coinsAmount + 1, PlayerPrefs.GetInt("COINS"));
                }
            }*/
        }
    }
}
