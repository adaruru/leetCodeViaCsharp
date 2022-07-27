using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    ///  字串相加
    /// </summary>
    public static class Leet002_QustAddTwoNumber
    {
        public static void main()
        {
            string[] numberStr1 = Console.ReadLine().Split();
            string[] numberStr2 = Console.ReadLine().Split();
            ListNode head1 = strArrToListNode(numberStr1);
            ListNode head2 = strArrToListNode(numberStr2);
            ListNode headResult = AddTwoNumber(head1, head2);
            while (headResult != null)
            {
                Console.Write(headResult.val + " ");
                headResult = headResult.next;
            }
        }

        static ListNode AddTwoNumber(ListNode l1, ListNode l2)
        {
            //往下進位暫存變數
            int carry = 0;
            ListNode Head = new ListNode(-1);
            ListNode tail = Head;
            //carry!=0暫存變數不為0要往下進位
            while (l1 != null || l2 != null || carry != 0)
            {
                //非null取值 null取0
                int l1val = l1 != null ? l1.val : 0;
                int l2val = l2 != null ? l2.val : 0;

                //值相加
                int rowSum = carry + l1val + l2val;

                //相加值附值於tail.next
                tail.next = new ListNode(rowSum % 10);
                //進位會在下一次while使用
                carry = rowSum / 10;

                //tail指向下一個
                tail = tail.next;

                //l1&l2往下一個
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            ListNode newHead = Head.next;
            return newHead;
        }
        static ListNode strArrToListNode(string[] str)
        {
            List<int> numList = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                numList.Add(int.Parse(str[i]));
            }
            ListNode head = new ListNode(-1);
            ListNode tail = head;
            foreach (int i in numList)
            {
                tail.next = new ListNode(i);
                tail = tail.next;
            }
            head = head.next;
            return head;
        }

        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
