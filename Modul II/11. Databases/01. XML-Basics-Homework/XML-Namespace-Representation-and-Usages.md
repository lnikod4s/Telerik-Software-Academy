XML Namespace Representation & Usages
==================================


XML Namespaces provide a method to avoid element name conflicts.

----------

## Table of contents

[TOC]

----------

Representation
------------------

#### Name Conflicts

In XML, element names are defined by the developer. This often results in a conflict when trying to mix XML documents from different XML applications.

This XML carries HTML table information:

    <table>
      <tr>
        <td>Apples</td>
        <td>Bananas</td>
      </tr>
    </table>

This XML carries information about a table (a piece of furniture):

    <table>
      <name>African Coffee Table</name>
      <width>80</width>
      <length>120</length>
    </table>

If these XML fragments were added together, there would be a name conflict. Both contain a `<table>` element, but the elements have different content and meaning.

A user or an XML application will not know how to handle these differences.

#### Solving the Name Conflict Using a Prefix

Name conflicts in XML can easily be avoided using a name prefix.

This XML carries information about an HTML table, and a piece of furniture:

    <h:table>
      <h:tr>
        <h:td>Apples</h:td>
        <h:td>Bananas</h:td>
      </h:tr>
    </h:table>
    
    <f:table>
      <f:name>African Coffee Table</f:name>
      <f:width>80</f:width>
      <f:length>120</f:length>
    </f:table>

Usage
-------

#### XML Namespaces - The xmlns Attribute

When using prefixes in XML, a namespace for the prefix must be defined.

The namespace can be defined by an xmlns attribute in the start tag of an element.

The namespace declaration has the following syntax. xmlns:prefix="URI".

    <root>
    
    <h:table xmlns:h="http://www.w3.org/TR/html4/">
      <h:tr>
        <h:td>Apples</h:td>
        <h:td>Bananas</h:td>
      </h:tr>
    </h:table>
    
    <f:table xmlns:f="http://www.w3schools.com/furniture">
      <f:name>African Coffee Table</f:name>
      <f:width>80</f:width>
      <f:length>120</f:length>
    </f:table>
    
    </root>

In the example above:

The xmlns attribute in the first `<table>` element gives the h: prefix a qualified namespace.

The xmlns attribute in the second `<table>` element gives the f: prefix a qualified namespace.

When a namespace is defined for an element, all child elements with the same prefix are associated with the same namespace.

Namespaces can also be declared the XML root element:

    <root 
    xmlns:h="http://www.w3.org/TR/html4/"
    xmlns:f="http://www.w3schools.com/furniture">
    
    <h:table>
      <h:tr>
        <h:td>Apples</h:td>
        <h:td>Bananas</h:td>
      </h:tr>
    </h:table>
    
    <f:table>
      <f:name>African Coffee Table</f:name>
      <f:width>80</f:width>
      <f:length>120</f:length>
    </f:table>
    
    </root>

**Note**: The namespace URI is not used by the parser to look up information.

The purpose of using an URI is to give the namespace a unique name.

However, companies often use the namespace as a pointer to a web page containing namespace information.

#### Uniform Resource Identifier (URI)

A Uniform Resource Identifier (URI) is a string of characters which identifies an Internet Resource.

The most common URI is the Uniform Resource Locator (URL) which identifies an Internet domain address. Another, not so common type of URI is the Universal Resource Name (URN).

#### Default Namespaces

Defining a default namespace for an element saves us from using prefixes in all the child elements. It has the following syntax:

    xmlns="namespaceURI"
This XML carries HTML table information:

    <table xmlns="http://www.w3.org/TR/html4/">
      <tr>
        <td>Apples</td>
        <td>Bananas</td>
      </tr>
    </table>
This XML carries information about a piece of furniture:

    <table xmlns="http://www.w3schools.com/furniture">
      <name>African Coffee Table</name>
      <width>80</width>
      <length>120</length>
    </table>

#### Namespaces in Real Use

XSLT is a language that can be used to transform XML documents into other formats.

The XML document below, is a document used to transform XML into HTML.

The namespace "http://www.w3.org/1999/XSL/Transform" identifies XSLT elements inside an HTML document:

    <?xml version="1.0" encoding="UTF-8"?>
    
    <xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    
    <xsl:template match="/">
    <html>
    <body>
      <h2>My CD Collection</h2>
      <table border="1">
        <tr>
          <th style="text-align:left">Title</th>
          <th style="text-align:left">Artist</th>
        </tr>
        <xsl:for-each select="catalog/cd">
        <tr>
          <td><xsl:value-of select="title"/></td>
          <td><xsl:value-of select="artist"/></td>
        </tr>
        </xsl:for-each>
      </table>
    </body>
    </html>
    </xsl:template>
    
    </xsl:stylesheet>

----------