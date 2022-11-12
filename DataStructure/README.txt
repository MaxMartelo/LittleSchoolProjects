ReadMe TP03

For the stack part: 
I change a few things in the TestStack because when I construct my stack using an array with int, I push from left to right which mean that the last element of my array is the one at the top of my stack. 
eg: {0, 1, 2, 3}
I push 0, then 1, then 2 and finally 3. It implies that at the end 3 is my head and when I pop, I pop 3, 2, 1 and 0. 
That is why I change the order of the stack.Push in the test TestPush and why I add an int j at the test TestPop and IsArrayEqualStack



For the TestList:
I took similar test used for queue and stack. 