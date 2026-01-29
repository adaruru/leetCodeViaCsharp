namespace LeetCode
{
    //Todo
    class Leet083RemoveDuplicatesfromSortedList
    {
        // Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.
        public ListNode DeleteDuplicates(ListNode head)
        {
            return head;
        }
    }
    /// <summary>
    /// Definition for singly-linked list.
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}