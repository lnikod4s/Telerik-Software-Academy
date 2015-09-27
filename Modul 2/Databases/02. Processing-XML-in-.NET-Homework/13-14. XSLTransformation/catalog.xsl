<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method='html' version='1.0' encoding='UTF-8' indent='yes' />

  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">
      &lt;!DOCTYPE html&gt;
    </xsl:text>
    <html>
      <body>
        <h2>My Albums Collection</h2>
        <table border="1">
          <tr bgcolor="#CCCCCC">
            <th align="left">Title</th>
            <th align="left">Artist</th>
            <th align="left">Year</th>
          </tr>
          <xsl:for-each select="catalog/album">
            <tr>
              <td>
                <xsl:value-of select="name" />
              </td>
              <td>
                <xsl:value-of select="artist" />
              </td>
              <td>
                <xsl:value-of select="year" />
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>