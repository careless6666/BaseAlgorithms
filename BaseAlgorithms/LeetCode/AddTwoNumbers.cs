using System.Linq;

namespace BaseAlgorithms.LeetCode
{
    //https://leetcode.com/problems/add-two-numbers/
    
    
    public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int val=0, ListNode next=null) {
             this.val = val;
             this.next = next;
         }
    }
    
    public class AddTwoNumbersTask
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            var result = new ListNode(0);
            var head = result;
            int borrow = 0;
            while(true){
                if(l1 == null && l2 == null){
                    break;   
                }
            
                var val1 = l1?.val ?? 0;
                var val2 = l2?.val ?? 0;
                var sum = val1 + val2 + borrow;

                borrow = sum/10;

                head.next = new ListNode(sum%10);
                head = head.next;

                l1 = l1?.next;
                l2 = l2?.next;
            }
        
            if(borrow != 0)
                head.next = new ListNode(borrow);
        
            return result.next;
        }
    }
}