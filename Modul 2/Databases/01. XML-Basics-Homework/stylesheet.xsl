<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://telerikacademy.com/Forum/Home/BestUsers">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Telerik Academy Best Students</h1>
        <ul>
          <xsl:for-each select="/">
            <li>
              <xsl:value-of select="name"/>
            </li>
            <li>
              <xsl:value-of select="sex"/>
            </li>
            <li>
              <xsl:value-of select="birthDate"/>
            </li>
            <li>
              <xsl:value-of select="phone"/>
            </li>
            <li>
              <xsl:value-of select="email"/>
            </li>
            <li>
              <xsl:value-of select="course"/>
            </li>
            <li>
              <xsl:value-of select="specialty"/>
            </li>
            <li>
              <xsl:value-of select="facultyNumber"/>
            </li>
            <li>
              <p>Taken Exams</p>
              <ul>
                <xsl:for-each select="/Exams">
                  <li>
                    <xsl:value-of select="examName"/>
                  </li>
                  <li>
                    <xsl:value-of select="date"/>
                  </li>
                  <li>
                    <xsl:value-of select="tutor"/>
                  </li>
                  <li>
                    <xsl:value-of select="tutorEndorsements"/>
                  </li>
                  <li>
                    <xsl:value-of select="score"/>
                  </li>
                </xsl:for-each>
              </ul>
            </li>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>