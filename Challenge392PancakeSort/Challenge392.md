# Challenge #392 Pancake sort
## Warmup
Implement the flipfront function. Given an array of integers and a number n between 2 and the length of the array (inclusive), return the array with the order of the first n elements reversed.
```
flipfront([0, 1, 2, 3, 4], 2) => [1, 0, 2, 3, 4]
flipfront([0, 1, 2, 3, 4], 3) => [2, 1, 0, 3, 4]
flipfront([0, 1, 2, 3, 4], 5) => [4, 3, 2, 1, 0]
flipfront([1, 2, 2, 2], 3) => [2, 2, 1, 2]
```
Optionally, as an optimization, modify the array in-place (in which case you don't need to return it). It's also fine to have the array be a global variable or member variable, in which case you only need to pass in the argument n.

## Challenge
Given an array of integers, sort the array (smallest to largest) using the flipfront function on the entire array. For example, the array:
```
[3, 1, 2, 1]
```
may be sorted with three calls to flipfront:
```
flipfront([3, 1, 2, 1], 4) => [1, 2, 1, 3]
flipfront([1, 2, 1, 3], 2) => [2, 1, 1, 3]
flipfront([2, 1, 1, 3], 3) => [1, 1, 2, 3]
```
Make sure you correctly handle elements that appear more than once in the array!

You may not modify the array by any other means, but you may examine it however you want. You can even make a copy of the array and manipulate the copy, including sorting it using some other algorithm.

## Optional bonus (hard!)
Try to minimize the number of times you call flipfront while sorting. Note that this is different from minimizing the runtime of your program.

How many flipfront calls do you require to sort this list of 10,000 integers? My record is 11,930. Can you do better?