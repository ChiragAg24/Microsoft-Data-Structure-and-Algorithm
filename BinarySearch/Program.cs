using System;

class BinarySearch{
    public static int BinaryS(int[] arr, int target){
        int left = 0;
        int right = arr.Length-1;

        while(left <=right){
            int mid = left +(right-left)/2;
            // searching mid, left and right halves respectively
            if (arr[mid]==target)
                return mid;
            if (arr[mid]<target)
                left = mid+1;
            else
                right = mid-1;
        }
        return -1;
    }
    // Example usage
    static void Main(){
        int[] sortedArray={10,4,6,8,11,12,14};
        int target = 10;

        int result = BinaryS(sortedArray,target); // calling the binary search function
        
        // Output the result
        if (result != -1)
            Console.WriteLine($"Element {target} found at index {result}");
        else
            Console.WriteLine($"Element {target} not found in array");
    }
}