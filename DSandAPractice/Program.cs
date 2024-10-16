﻿// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Globalization;
using DSandAPractice;
using DSandAPractice.Algorithms;
using DSandAPractice.Structures;
using DSandAPractice.AlgorithmsAndConcepts;

Stopwatch watch = new Stopwatch();
watch.Start();

// (Singly) LinkedList practice
/*List<int> starterValues = new List<int> { 1, 14, 2, 4, 5, 6, 17, 3 };
DSA_LinkedList<int> linkedList = new DSA_LinkedList<int>(starterValues);
DSA_LinkedList<int> runnerLL = new DSA_LinkedList<int>(linkedList, 1, 2);
//ll.Insert(10, 0);
//ll.RemoveElementWithValue(17);
Console.WriteLine(linkedList.ToString());
Console.WriteLine(runnerLL.ToString());*/

/*List<int> testTreeValues = [40, 30, 50, 25, 35, 45, 46, 60];
DSA_BinarySearchTree bst = new DSA_BinarySearchTree(testTreeValues);
bst.PrintInOrderTraversal();
bst.Delete(40);
Console.WriteLine();
bst.PrintInOrderTraversal();
Console.WriteLine("\n"+ bst.Root.value);
Console.WriteLine(bst.MinValue(bst.Root).value);
Console.WriteLine(bst.MaxValue(bst.Root).value);
Console.WriteLine("\n" + bst.MinValue(bst.Search(35)).value);
Console.WriteLine(bst.Search(30));*/
Console.WriteLine("Working...");

/*DSA_Stack<int> stack = new DSA_Stack<int>(new List<int>{10, 4, 2, 5, 6});
Console.WriteLine(stack.Peek());
stack.Push(4);
stack.Push(23);
stack.Pop();
Console.WriteLine(stack.Peek());*/
/*<int> queue = new DSA_Queue<int>(new List<int>{10, 9, 8, 7, 4, 24});
Console.WriteLine(queue.Peek());
Console.WriteLine(queue.Dequeue());
queue.Dequeue();
queue.Enqueue(64);
Console.WriteLine(queue);*/
/*
DSA_Graph<int> graph = new DSA_Graph<int>();
graph.Add(6, graph.AddAdjacentUndirected(new List<int>{1, 2, 3, 4, 5, 7}), false);
graph.Add(24, new List<int>{7, 8, 9, 10, 11}, false);
Console.WriteLine(graph);
Console.WriteLine(graph.DepthFirstSearch(graph[7], 7));
*/
/*DSA_Tree<int> basicTree = new DSA_Tree<int>();
basicTree.Add(new List<int>{10, 5, 15, 3, 6, 12, 17});
basicTree.PrintInOrderTraversal(basicTree.Root);*/
/*Sorting.PrintList(PrimeNumbers.Sieve(327).ToArray());
Console.WriteLine(PrimeNumbers.IsPrime(113));*/
/*int[] num = {52, 168, 2, 53, 83, 1000, 625, 234, 51526, 1442, 1, 85};
Sorting.RadixSort(num);
Sorting.MergeSort(num);
Sorting.SelectionSort(num);
Sorting.BubbleSort(num);
Sorting.QuickSort(num, true);
Sorting.PrintList(num);*/
/*int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 42, 69 };
Sorting.PrintList(num);
Console.WriteLine(Searching.BinarySearchRecursive(num, 69));
Console.WriteLine(Searching.BinarySearchIterative(num, 69));*/

/*Console.WriteLine(BitManipulation.BitString(BitManipulation.ClearLSB(6, 1)));*/

/*DSA_HashMap<int> map = new DSA_HashMap<int>();
map.Add(new KeyValuePair<int, int>(6, 10));
Console.WriteLine(map.Get(6));*/

watch.Stop();
string text = watch.Elapsed.TotalSeconds.ToString(CultureInfo.InvariantCulture);
Console.WriteLine("Time Elapsed: " + text);