Distinction Between URI, URN and URL
==================================

----------

## Table of contents

[TOC]

----------

### URI (Uniform Resource Identifier)

In computing, a Uniform Resource Identifier (URI) is a string of characters used to identify the name of a resource. Such identification enables interaction with representations of the resource over a network, typically the World Wide Web, using specific protocols. Schemes specifying a concrete syntax and associated protocols define each URI. The most common form of URI is the Uniform Resource Locator (URL), frequently referred to informally as a web address. More rarely seen in usage is the Uniform Resource Name (URN), which was designed to complement URLs by providing a mechanism for the identification of resources in particular namespaces.

### URN (Uniform Resource Name)

A URN is a URI that identifies a resource by name in a particular namespace. A URN can be used to talk about a resource without implying its location or how to access it.

The International Standard Book Number (ISBN) system for uniquely identifying books provides a typical example of the use of URNs. ISBN 0-486-27557-4 cites unambiguously a specific edition of Shakespeare's play Romeo and Juliet. The URN for that edition would be urn:isbn:0-486-27557-4. To gain access to this object and read the book, its location is needed, for which a URL would have to be specified.

### URL (Uniform Resource Locator)

A URL is a URI that, in addition to identifying a web resource, specifies the means of acting upon or obtaining the representation of it, i.e. specifying both its primary access mechanism and network location. For example, the URL http://example.org/wiki/Main_Page refers to a resource identified as /wiki/Main_Page whose representation, in the form of HTML and related code, is obtainable via HyperText Transfer Protocol (http) from a network host whose domain name is example.org.

### Conceptual Distinctions

Technical publications, especially standards produced by the IETF and by the W3C, normally reflect a view outlined in a W3C Recommendation of 2001, which acknowledges the precedence of the term URI rather than endorsing any formal subdivision into URL and URN.

URL is a useful but informal concept: a URL is a type of URI that identifies a resource via a representation of its primary access mechanism (e.g., its network "location"), rather than by some other attributes it may have.
A URL is simply a URI that happens to point to a physical resource over a network.

However, in non-technical contexts and in software for the World Wide Web, the term URL remains widely used. Additionally, the term web address (which has no formal definition) often occurs in non-technical publications as a synonym for a URI that uses the 'http' or 'https' scheme. Such assumptions can lead to confusion, for example when viewing XML source: the normal means of identifying unique XML vocabularies within an XML document is to declare XML namespaces whose names are URIs that begin with 'http' and use the syntax of a genuine domain name followed by a file path, but which have no need to point to any specific file locations that actually exist.

While most URI schemes were originally designed to be used with a particular protocol, and often have the same name (such as the http scheme, which is generally used for interacting with web resources using HyperText Transfer Protocol), they should not be referred to as protocols. Some URI schemes are not associated with any specific protocol (e.g. file) and many others do not use the name of a protocol as their prefix (e.g. news).

----------