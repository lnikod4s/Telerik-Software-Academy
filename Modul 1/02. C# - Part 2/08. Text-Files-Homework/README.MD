Homework: Text Files
====================

### Problem 1. Odd lines
*	Write a program that reads a text file and prints on the console its odd lines.

### Problem 2. Concatenate text files
*	Write a program that concatenates two text files into another text file.

### Problem 3. Line numbers
*	Write a program that reads a text file and inserts line numbers in front of each of its lines.
*	The result should be written to another text file.

### Problem 4. Compare text files
*	Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
*	Assume the files have equal number of lines.

### Problem 5. Maximal area sum
*	Write a program that reads a text file containing a square matrix of numbers.
*	Find an area of size `2 x 2` in the matrix, with a maximal sum of its elements.
	*	The first line in the input file contains the size of matrix `N`.
	*	Each of the next `N` lines contain `N` numbers separated by space.
	*	The output should be a single number in a separate text file.

_Example:_

| input | output |
|-------|--------|
| 4 <br> 2 3 3 4 <br> 0 2 3 4 <br> 3 7 1 2 <br> 4 3 3 2 | 17 |

### Problem 6. Save sorted names
*	Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.

_Example:_

|  input.txt | output.txt |
|:----------:|:----------:|
| Ivan <br> Peter <br> Maria <br> George | George <br> Ivan <br> Maria <br> Peter |

### Problem 7. Replace sub-string
*	Write a program that replaces all occurrences of the sub-string `start` with the sub-string `finish` in a text file.
*	Ensure it will work with large files (e.g. `100 MB`).

### Problem 8. Replace whole word
*	Modify the solution of the previous problem to replace only **whole words** (not strings).

### Problem 9. Delete odd lines
*	Write a program that deletes from given text file all odd lines.
*	The result should be in the same file.

### Problem 10. Extract text from XML
*	Write a program that extracts from given XML file all the text without the tags.

_Example:_

`<?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3"><interest>Games</interest><interest>C#</interest><interest>Java</interest></interests></student>`

### Problem 11. Prefix "test"
*	Write a program that deletes from a text file all words that start with the prefix `test`.
*	Words contain only the symbols `0…9`, `a…z`, `A…Z`, `_`.

### Problem 12. Remove words
*	Write a program that removes from a text file all words listed in given another text file.
*	Handle all possible exceptions in your methods.

### Problem 13. Count words
*	Write a program that reads a list of words from the file `words.txt` and finds how many times each of the words is contained in another file `test.txt`.
*	The result should be written in the file `result.txt` and the words should be sorted by the number of their occurrences in descending order.
*	Handle all possible exceptions in your methods.
