using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            // LCT01_SyntaxList();
            // LCT02_SyntaxLinkedList();
            // LCT03_SyntaxHashTable();
             LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_SyntaxLinkedList()
        {
            string[] playerNames = new string[1000];
            LinkedList<string> linkedList = new LinkedList<string>();

            linkedList.AddLast("Node 1");
            linkedList.AddLast("Node 2");
            linkedList.AddFirst("Node 0");
            
            LinkedListNode<string> node1 = linkedList.Find("Node 1");
            Debug.Log(node1.Value);
            Debug.Log(node1.Next.Value);
            Debug.Log(node1.Previous.Value);
            
            var firstNode = linkedList.First;
            var lastNode = linkedList.Last;
            Debug.Log(firstNode.Previous);
            Debug.Log(lastNode.Next);

            linkedList.AddAfter(node1, "Node 1.5");
            linkedList.AddBefore(node1, "Node 0.5");
            
            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            linkedList.Remove("Node 1.5");
            
            linkedList.Clear();
            
            Debug.Log("----");

            foreach (var item in linkedList)
            {
                Debug.Log(item.ToString());
            }
        }

        public void LCT03_SyntaxHashTable()
        {
            throw new System.NotImplementedException();
        }

        public void LCT04_SyntaxDictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            
            dictionary.Add("Potion", 5);
            dictionary.Add("Banana", 1);
            dictionary.Add("Apple", 10);
            
            dictionary["Apple"] = 0;
            
            dictionary["Apple1"] = 1;
            
            int potion = dictionary["Potion"];
            Debug.Log($"Potion: {potion}");
            
            bool hasPotion = dictionary.ContainsKey("Potion");
            Debug.Log($"Has Potion: {hasPotion}");
            
            dictionary.Remove("Banana");

            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                var key = kvp.Key;
                var value = kvp.Value;
                Debug.Log($"{key}: {value}");
            }
            
            dictionary.Clear();
        }

        #endregion
    }
}
