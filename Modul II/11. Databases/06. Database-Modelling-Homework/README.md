## Database Modeling
### _Homework_

1. Create the following database diagram in SQL Server:

  ![Screenshot](https://raw.githubusercontent.com/TelerikAcademy/Databases/master/06.%20Database%20Modeling/Homework/imgs/diagram.png)

2. Fill some sample data in the tables with SQL Server Management Studio.

3. Typical universities have: faculties, departments, professors, students, courses, etc. Faculties have name and could have several departments. Each department has name, professors and courses. Each professor has name, a set of titles (Ph. D, academician, senior assistant, etc.) and a set of courses. Each course consists of several students. Each student belongs to some faculty and to several of the courses. Your task is to create a data model (E/R diagram) for the typical university in SQL Server using SQL Server Management Studio (SSMS).

4. Create the same data model in MySQL.

5. We should design a multilingual dictionary. We have a set of words in the dictionary.
	*	Each word can be in some language and can have synonyms and explanations in the same language and translation words and explanations in several other languages.
	*	The synonyms and translation words are sets of words from the dictionary. The explanations are textual descriptions.
	*	Design a database schema (a set of tables and relationships) to store the dictionary.