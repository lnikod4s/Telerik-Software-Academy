XML Representation & Usages
=========================


The main goal of this markdown document is to give a brief introduction to the XML Language.

----------

## Table of contents

[TOC]

----------

Representation
------------------

XML stands for Extensible Markup Language (presumably the original authors thought that sounded more exciting than EML) and its development and usage have followed a common path in the software and IT world. More accurately XML is a software- and hardware-independent tool for storing and transporting data.

#### What is XML?

+ XML stands for eXtensible Markup Language
+ XML is a markup language much like HTML
+ XML was designed to store and transport data
+ XML was designed to be self-descriptive
+ XML is a W3C Recommendation

#### The Difference Between XML and HTML

XML and HTML were designed with different goals:

+ XML was designed to carry data - with focus on what data is
+ HTML was designed to display data - with focus on how data looks
+ XML tags are not predefined like HTML tags are

Usage
-------

#### XML Does Not Use Predefined Tags

The XML language has no predefined tags.

The tags in the example above (like `<to>` and `<from>`) are not defined in any XML standard. These tags are "invented" by the author of the XML document.
HTML works with predefined tags like `<p>, <h1>, <table>`, etc.
With XML, the author must define both the tags and the document structure.

#### XML is Extensible

Most XML applications will work as expected even if new data is added (or removed).
Imagine an application designed to display the original version of note.xml (`<to> <from> <heading> <data>`).
Then imagine a newer version of note.xml with added `<date>` and `<hour>` elements, and a removed `<heading>`.
The way XML is constructed, older version of the application can still work:

    <note>
      <date>2015-09-01</date>
      <hour>08:30</hour>
      <to>Gosho</to>
      <from>Pesho</from>
      <body>Don't forget me this weekend!</body>
    </note>

#### XML Simplifies Things

+ It simplifies data sharing
+ It simplifies data transport
+ It simplifies platform changes
+ It simplifies data availability

Many computer systems contain data in incompatible formats. Exchange data between incompatible systems (or upgraded systems), is a time-consuming tasks for web developers Large amounts of data must be converted, and incompatible data is often lost.

XML stores data in plain text format. This provides a software- and hardware-independent way of storing, transporting, and sharing data.

XML also makes it easier to expand or upgrade to new operating systems, new applications, or new browsers, without losing data.

With XML, data can be available to all kinds of "reading machines" like people, computers, voice machines, news feeds, etc.


----------