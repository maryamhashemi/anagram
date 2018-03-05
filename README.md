What is an anagram?
An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

What is my method?
I use c# language and add moien dictionary to my project that is about 33000 words.
The naive approach is to calculate all permutation of letters in word and then search it in dictionary, so if it exists in dictionary, we find the answer. But calculating the permutation takes a lot of time and this is not a proper solution. As a result, I must use a method to hash the words of dictionary in order to reduce the time. One of the hash method is to map each character to a prime number and multiply the prime numbers. But I used another method. At first, I store all the dictionary words in DataTable and simultaneously sort the letters of each word and save the sorted form of the word in another column in DatTable. So, different anagrams of a specific word have a same sort and finally, by a simple search in DataTable, I find all anagrams of the input word and show in a listview.
