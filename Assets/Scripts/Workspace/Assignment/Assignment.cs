using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.ReorderableList.Internal;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
             AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            Dictionary<string, int> countWords = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (countWords.ContainsKey(words[i]))
                {
                    int count = countWords[words[i]];
                    count++;
                    countWords[words[i]] = count;
                }
                else
                {
                    countWords.Add(words[i], 1);
                }
            }
            
            foreach (KeyValuePair<string, int> kvp in countWords)
            {
                var key = kvp.Key;
                var value = kvp.Value;
                Debug.Log($"word: '{key}' count: {value}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            Dictionary<int, int> countWords = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (countWords.ContainsKey(numbers[i]))
                {
                    int count = countWords[numbers[i]];
                    count++;
                    countWords[numbers[i]] = count;
                }
                else
                {
                    countWords.Add(numbers[i], 1);
                }
            }
            
            foreach (KeyValuePair<int, int> kvp in countWords)
            {
                var key = kvp.Key;
                var value = kvp.Value;
                Debug.Log($"number: {key} count: {value}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            Dictionary<char, char> characters = new Dictionary<char, char>
            {
                {'(', ')'}
            };
            LinkedList<char> letters = new LinkedList<char>();
            
            bool isValid = true;

            if (!string.IsNullOrEmpty(input))
            {
                foreach (char c in input)
                {
                    if (characters.ContainsKey(c))
                    {
                        letters.AddLast(c);
                    }
                    else if (characters.ContainsValue(c))
                    {
                        if (letters.Count == 0)
                        {
                            isValid = false;
                            break;
                        }
                    
                        char lastChar = letters.Last.Value;
                        if (characters[lastChar] == c)
                        {
                            letters.RemoveLast();
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
            }
            
            if (letters.Count > 0)
            {
                isValid = false;
            }
            
            Debug.Log($"{(isValid ? "Valid" : "Invalid")}");
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
            }
            
            var lastNode = list.Last;

            while (lastNode != null)
            {
                Debug.Log(lastNode.Value);
                lastNode = lastNode.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
            }
            
            var slow = list.First;
            var fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            
            Debug.Log(slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            
            Dictionary<string, int> mergeDictionnary = new Dictionary<string, int>(dict1);

            foreach (KeyValuePair<string, int> kvp in dict2)
            {
                if (mergeDictionnary.ContainsKey(kvp.Key))
                {
                    mergeDictionnary[kvp.Key] += kvp.Value;
                }
                else
                {
                    mergeDictionnary.Add(kvp.Key, kvp.Value);
                }
            }

            foreach (KeyValuePair<string, int> kvp in mergeDictionnary)
            {
                Debug.Log($"key: {kvp.Key} value: {kvp.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            if (list.Count <= 1)
            {
                Debug.Log(string.Join("", list));
            }
            
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            LinkedListNode<int> node = list.First;

            while (node != null)
            {
                LinkedListNode<int> nextNode = node.Next;
                if (dict.ContainsKey(node.Value))
                {
                    list.Remove(node);
                }
                else
                {
                    dict.Add(node.Value, true);
                }
                
                node = nextNode;
            }
            
            Debug.Log(string.Join("\n", list));
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
            }
            
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int i in numbers)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i]++;
                }
                else
                {
                    dict.Add(i, 1);
                }
            }
            
            int mostNumber = numbers[0];
            int mostCount = dict[mostNumber];

            foreach (int i in numbers)
            {
                int count = dict[i];

                if (count > mostCount)
                {
                    mostNumber = i;
                    mostCount = count;
                }
            }
            
            Debug.Log($"{mostNumber} count: {mostCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;

            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory.Add(itemName, quantity);
            }

            foreach (KeyValuePair<string, int> kvp in inventory)
            {
                Debug.Log($"{kvp.Key}: {kvp.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            if (eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
            }

            while (eventQueue.Count > 0)
            {
                GameEvent gameEvent = eventQueue.First.Value;
                eventQueue.RemoveFirst();
                Debug.Log($"Processing game event: {gameEvent.Name}");
                Debug.Log($"Remaining events: {eventQueue.Count}");
                Debug.Log($"{gameEvent.EventType} event processed - {gameEvent.Name}");
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;
            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
                Debug.Log($"Updated {statName}: {playerStats[statName]}");
            }
            else
            {
                playerStats.Add(statName, value);
                Debug.Log($"Updated {statName}: {value}");
            }

            Debug.Log("Current player statistics:");
            foreach (KeyValuePair<string, int> kvp in playerStats)
            {
                Debug.Log($"{kvp.Key}: {kvp.Value}");
            }
        }

        #endregion
    }
}
