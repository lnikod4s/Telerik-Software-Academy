# Incident Management Homework

1.We have a painting program like Paint.NET and we have the following bugs
*	Set Priority and Severity

| Bug description        | Severity           | Priority  |
| ------------- | :-------------: | :-----: |
| Tool for selection doesn't select exactly the same that it's marking (crops 10 pixels to the left). | Critical | Next Release |
| When selecting a color with the color picker it replaces the first color from the palette, not the chosen one. | Critical | Next Release |
| Shortcut for 'Create New Image' (Ctrl+N) doesn't work. | Medium | On Occasion |
| Spelling mistake in menu Select 'Transperent selection' instead of 'Transparent selection'. | Low | Immediate |
| While holding Ctrl+Z and drawing with the pencil the second color is used instead of the first one, and that's not a feature. | Low | Open |
| When using 'Magic Wand' tool the tolerance value is changing on every mouse click. | Medium | Next Release |
| While clicking 'Rotate 90 Clockwise' the image is rotating in counterclockwise direction. | Medium | Next Release |
| The button for increasing the Brush size doesn't work. It can be increased only from the drop down. | Medium | On Occasion |
| Program crash on clicking the OK button while resizing an image.| Critical | Next Release |

2.Imagine you have the following bug, mentioned by a customer and you have to describe it and log it in the bug tracking tool you use
*	Report the following bugs

| BUG REPORT |   #1   |
| ------------- | :-------------: |
| Description | When there's a page break in the page and you try to set dashed border on the page, the bottom border line doesn't show. |
| Steps to reproduce | <ol><li>User opens web page/application</li><li>User fills some data and reach the end of the page</li><li>By reaching the page end, page break is automatically set</li><li>Dashed border is set on the page</li><li>The bottom border line doesn't show</li></ol> Expected Result: The bottom border line should be visible |
| Acceptance criteria | All borders should be visible |
| Priority | Next Release |
| Severity | Low |

| BUG REPORT |   #2   |
| ------------- | :-------------: |
| Description | Application crash on clicking the Save button while creating a new user, hence unable to create a new user in the application. |
| Steps to reproduce | <ol><li>User opens application</li><li>User clicks on 'Create New User' button</li><li>User fills all required data in the form 'New User' and clicks on the 'Save' button</li><li>Application crashes and the newly created user is not saved in the database</li></ol>  Expected Result: After application crash the data for the requested new user is sent to the database and successfully saved |
| Acceptance criteria | Although application crashes, the new user is successfully created and can be used by application restart |
| Priority | Next Release |
| Severity | High |

* Prepare another bug report

| BUG REPORT |   Excel 2010 Bug   |
| ------------- | :-------------: |
| Description | Copying an unordered list in a Word 2010 document and pasting it to Excel 2010 sheet, shows the bullet signs before the list items. By trying to replace the bullet sign with an empty character, the list items were shown in greek letters. |
| Steps to reproduce | <ol><li>User opens a new Word 2010 document</li><li>User creates an simple unordered list</li><li>User marks the list items and copies them</li><li>User opens a new Excel 2010 sheet</li><li>User marks the first **n** rows from the Excel sheet, where **n** is the number of the list items from the Word 2010 document</li><li>User pastes the copied list items in the marked Excel sheet rows</li><li>The list items were pasted inclusive the bullet sign before them</li><li>User marks a single bullet sign and copies it</li><li>User tries to replace the copied bullet sign with an empty character through the 'Find and Replace' window in Excel 2010</li><li>Replacing the bullet sign follows with showing the list items in greek letters</li></ol> |
| Acceptance criteria | <ul><li>Copying list items from Word 2010 and pasting them to Excel 2010 without a bullet sign</li><li>Replacing the bullet sign in Excel 2010 with an empty character does not transform list items</li></ul> |
| Priority | On Occasion |
| Severity | Medium |

| BUG REPORT |   Gmail Navigation Bug  |
| ------------- | :-------------: |
| Description | After logging into Gmail application navigates to www.google.com |
| Steps to reproduce | <ol><li>User opens Gmail Sign In Page</li><li>User fills credentials in the login form and clicks on the 'Sign In' button</li><li>Application navigates to www.google.com</li></ol> Expected Result: Application navigates to https://mail.google.com/mail/u/0/#inbox after logging into Gmail |
| Acceptance criteria | After logging into Gmail the user should see his/her inbox |
| Priority | Immediate |
| Severity | Blocking |