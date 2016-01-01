Homework: Multidimensional Arrays
=================================

### Problem 1. Fill the matrix
*	Write a program that fills and prints a matrix of size `(n, n)` as shown below:

_Example for `n=4`:_

| a) | b) | c) | d)* |
|:--:|:--:|:--:|:---:|
|  <table><tbody><tr><td>1</td><td>5</td><td>9</td><td>13</td></tr><tr><td>2</td><td>6</td><td>10</td><td>14</td></tr><tr><td>3</td><td>7</td><td>11</td><td>15</td></tr><tr><td>4</td><td>8</td><td>12</td><td>16</td></tr></tbody></table>  |  <table><tbody><tr><td>1</td><td>8</td><td>9</td><td>16</td></tr><tr><td>2</td><td>7</td><td>10</td><td>15</td></tr><tr><td>3</td><td>6</td><td>11</td><td>14</td></tr><tr><td>4</td><td>5</td><td>12</td><td>13</td></tr></tbody></table>  |  <table><tbody><tr><td>7</td><td>11</td><td>14</td><td>16</td></tr><tr><td>4</td><td>8</td><td>12</td><td>15</td></tr><tr><td>2</td><td>5</td><td>9</td><td>13</td></tr><tr><td>1</td><td>3</td><td>6</td><td>10</td></tr></tbody></table>  |  <table><tbody><tr><td>1</td><td>12</td><td>11</td><td>10</td></tr><tr><td>2</td><td>13</td><td>16</td><td>9</td></tr><tr><td>3</td><td>14</td><td>15</td><td>8</td></tr><tr><td>4</td><td>5</td><td>6</td><td>7</td></tr></tbody></table>  |

### Problem 2. Maximal sum
*	Write a program that reads a rectangular matrix of size `N x M` and finds in it the square `3 x 3` that has maximal sum of its elements.

### Problem 3. Sequence n matrix
*	We are given a matrix of strings of size `N x M`. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal.
*	Write a program that finds the longest sequence of equal strings in the matrix.

_Example:_

| matrix |   result   |   | matrix |   result   |
|:------:|:----------:|:-:|:------:|:----------:|
| <table><tbody><tr><td><b>ha</b></td><td>fifi</td><td>ho</td><td>hi</td></tr><tr><td>fo</td><td><b>ha</b></td><td>hi</td><td>xx</td></tr><tr><td>xxx</td><td>ho</td><td><b>ha</b></td><td>xx</td></tr></tbody></table> | ha, ha, ha |   | <table><tbody><tr><td>s</td><td>qq</td><td><b>s</b></td></tr><tr><td>pp</td><td>pp</td><td><b>s</b></td></tr><tr><td>pp</td><td>qq</td><td><b>s</b></td></tr></tbody></table> | s, s, s |

### Problem 4. Binary search
*	Write a program, that reads from the console an array of `N` integers and an integer `K`, sorts the array and using the method `Array.BinSearch()` finds the largest number in the array which is &#8804; `K`. 

### Problem 5. Sort by string length
*	You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

### Problem 6.* Matrix class
*	Write a class `Matrix`, to hold a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and `ToString()`.

### Problem 7.* Largest area in matrix
*	Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.

_Example:_

| matrix |   result   |
|:------:|:----------:|
| <table><tbody><tr><td>1</td><td><b>3</b></td><td>2</td><td>2</td><td>2</td><td>4</td></tr><tr><td><b>3</b></td><td><b>3</b></td><td><b>3</b></td><td>2</td><td>4</td><td>4</td></tr><tr><td>4</td><td><b>3</b></td><td>1</td><td>2</td><td><b>3</b></td><td><b>3</b></td></tr><tr><td>4</td><td><b>3</b></td><td>1</td><td><b>3</b></td><td><b>3</b></td><td>1</td></tr><tr><td>4</td><td><b>3</b></td><td><b>3</b></td><td><b>3</b></td><td>1</td><td>1</td></tr></tbody></table> | 13 |

_Hint: you can use the algorithm [Depth-first search](http://en.wikipedia.org/wiki/Depth-first_search) or [Breadth-first search](http://en.wikipedia.org/wiki/Breadth-first_search)._
