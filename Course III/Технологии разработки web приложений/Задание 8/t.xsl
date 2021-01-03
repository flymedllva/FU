<?xml version="1.1" encoding="UTF-8"?>
<xsl:stylesheet version="1.1" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <html lang="ru">
            <head>
                <meta charset="utf-8"/>
            </head>
            <body>
                <table>
                    <thead>
                        <tr>
                            <th>Наименование</th>
                            <th>Источник</th>
                        </tr>
                    </thead>
                    <tbody>
                        <xsl:for-each select="catalog/array">
                            <xsl:sort select="NameInInformationSource"/>
                            <xsl:if test="Source = 'Мосгорстат'">
                                <tr>
                                    <td>
                                        <xsl:value-of select="Name"/>
                                    </td>
                                    <td>
                                        <xsl:value-of select="Source"/>
                                    </td>
                                </tr>
                            </xsl:if>
                        </xsl:for-each>
                    </tbody>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>